namespace ViewStateOptimizer.FileStorage
{
	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using System.Web.UI;

	/// <summary>
	/// This class implements storing the ViewState contents in the files.
	/// </summary>
	public class FileViewStateOptimizer : BaseViewStateOptimizer
	{
		/// <summary>
		/// Initializes a new instance of the ViewStateOptimizer.FileViewStateOptimizer class.
		/// </summary>
		/// <param name="page">The System.Web.UI.Page that the view state persistence mechanism is created for.</param>
		public FileViewStateOptimizer(Page page)
			: base(page)
		{
		}

		/// <summary>
		/// Load the ViewState contents into string using the Session for storing the file path.
		/// </summary>
		/// <returns>Returns the ViewState contents</returns>
		public override string LoadViewStateContents()
		{
			// Don't make anything at the first postback
			if (!Page.IsPostBack) return null;

			// Get the hashed key from the form
			string vsHashedKey = Page.Request.Form[ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStateKey];

			// Checks the existed the hashed key or not?
			if (String.IsNullOrEmpty(vsHashedKey) ||
				!vsHashedKey.StartsWith(ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStatePrefixValue))
			{
				throw new ViewStateException();
			}

			// --- Gets the file path which stored the ViewState contents.
			IStateFormatter frmt = StateFormatter;
			var salt = Page.Session[vsHashedKey].ToString();
			var vsFile = Page.Session[ViewStateOptimizerSecurity.GenerateHashStringBySalt(vsHashedKey, salt)].ToString();
			// --- End

			// --- Reads the file and return all ViewState contents
			if (!String.IsNullOrEmpty(vsFile))
			{
				if (File.Exists(vsFile))
				{
					return File.ReadAllText(vsFile);
				}
			}
			// --- End

			return null;
		}

		/// <summary>
		/// Save the ViewState contents to the specified file path which stored in the Session.
		/// </summary>
		/// <param name="viewStateContents">ViewState contents</param>
		/// <returns>Returns true if saving OK, otherwise will be false</returns>
		public override bool SaveViewStateContents(string viewStateContents)
		{
			try
			{
				if (ViewState != null || ControlState != null)
				{
					// Checks the existed session or not?
					if (Page.Session == null)
					{
						throw new InvalidOperationException("Session is required for FilePageStatePersister.");
					}

					string vsFile, vsHashedKey, salt;

					if (!Page.IsPostBack) // For the first postback
					{
						// --- Create the unique key for each session each user
						var sessionId = Page.Session.SessionID;
						var pageUrl = Page.Request.Path;
						var vsKey = string.Format("{0}_{1}_{2}_{3}", Guid.NewGuid(), pageUrl, sessionId,
							DateTime.Now.Ticks);
						vsKey = vsKey.Replace("/", String.Empty);
						var vsFileName = vsKey + ".vso";
						// --- End

						// --- Create a new directory with the specified path if no exists.
						var vsPath = Page.MapPath(ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStateStorageRelativeFolder);
						if (!Directory.Exists(vsPath))
						{
							Directory.CreateDirectory(vsPath);
						}
						vsFile = Path.Combine(vsPath, vsFileName);
						// --- End

						// --- Create new session based upon hash key to secure the viewstate contents
						vsHashedKey = ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStatePrefixValue + "_" + Convert.ToBase64String(ViewStateOptimizerSecurity.GenerateHash(vsKey));
						salt = ViewStateOptimizerSecurity.GenerateSaltString(50);
						Page.Session[vsHashedKey] = salt;
						Page.Session[ViewStateOptimizerSecurity.GenerateHashStringBySalt(vsHashedKey, salt)] = vsFile;
						// --- End
					}
					else // For the postbacks later
					{
						// --- Gets the hashed key from the form
						vsHashedKey = Page.Request.Form[ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStateKey];
						if (String.IsNullOrEmpty(vsHashedKey))
						{
							throw new ViewStateException();
						}
						// --- End

						// --- Gets the specified file path which stored in the Session
						salt = Page.Session[vsHashedKey].ToString();
						vsFile = Page.Session[ViewStateOptimizerSecurity.GenerateHashStringBySalt(vsHashedKey, salt)].ToString();
						if (string.IsNullOrEmpty(vsFile))
						{
							throw new ViewStateException();
						}
						// --- End
					}

					// Write all ViewState contents to the specified file
					File.WriteAllText(vsFile, viewStateContents);

					// Register a new hidden field to the client-side with the ViewState key and hashed key
					Page.ClientScript.RegisterHiddenField(ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStateKey, vsHashedKey);

					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}
	}
}
