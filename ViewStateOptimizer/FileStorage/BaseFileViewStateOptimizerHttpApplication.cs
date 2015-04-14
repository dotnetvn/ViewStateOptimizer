namespace ViewStateOptimizer.FileStorage
{
	using System;
	using System.IO;
	using System.Web;

	/// <summary>
	/// This abstract class implements removing the *.vso files that store the ViewState contents.
	/// Be able to inherit this class to implement your custom own.
	/// </summary>
	public abstract class BaseFileViewStateOptimizerHttpApplication : HttpApplication
	{
		/// <summary>
		/// This event will be fired and then will remove the *.vso files that store the ViewState contents
		/// when the session timeout has expired.
		/// </summary>
		/// <param name="sender">object that raised this event</param>
		/// <param name="e">event data</param>
		protected virtual void Session_End(object sender, EventArgs e)
		{
			// --- Remove the *.vso files that store the ViewState contents.
			foreach (string key in Session.Keys)
			{
				if (key.StartsWith(ViewStateOptimizerHelper.Section.FileViewStateOptimizerConfiguration.ViewStatePrefixValue))
				{
					var salt = Session[key].ToString();
					var vsFile = Session[ViewStateOptimizerSecurity.GenerateHashStringBySalt(key, salt)].ToString();
					if(File.Exists(vsFile))
					{
						File.Delete(vsFile);
					}
				}
			}
			// --- End
		}
	}
}
