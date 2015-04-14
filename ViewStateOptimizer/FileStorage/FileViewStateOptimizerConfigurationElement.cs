namespace ViewStateOptimizer.FileStorage
{
	using System.Configuration;

	/// <summary>
	/// This class defines the custom element for the storage file type in Web.config.
	/// </summary>
	public class FileViewStateOptimizerConfigurationElement : ConfigurationElement
	{
		/// <summary>
		/// Gets or sets the ViewStateKey property. This property indicates that it's a ViewState key stored on the hidden field.
		/// </summary>
		[ConfigurationProperty("viewStateKey", DefaultValue = "_ViewStateOptimizer", IsRequired = false)]
		public string ViewStateKey
		{
			get
			{
				return this["viewStateKey"].ToString();
			}
			set
			{
				this["viewStateKey"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the ViewStateStorageRelativeFolder property. This property indicates that it's a relative folder
		/// for the ViewState storage on the server-side
		/// </summary>
		[ConfigurationProperty("viewStateStorageRelativeFolder", DefaultValue = "~/App_Data/VsFiles", IsRequired = false)]
		public string ViewStateStorageRelativeFolder
		{
			get
			{
				return this["viewStateStorageRelativeFolder"].ToString();
			}
			set
			{
				this["viewStateStorageRelativeFolder"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the ViewStatePrefixValue field. This field indicates that it's a ViewState prefix value stored as the value of hidden field.
		/// </summary>
		[ConfigurationProperty("viewStatePrefixValue", DefaultValue = "_vso", IsRequired = false)]
		public string ViewStatePrefixValue
		{
			get
			{
				return this["viewStatePrefixValue"].ToString();
			}
			set
			{
				this["viewStatePrefixValue"] = value;
			}
		}
	}
}
