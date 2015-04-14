namespace ViewStateOptimizer
{
	using System.Configuration;
	using ViewStateOptimizer.FileStorage;

	/// <summary>
	/// This class implements the custom section configuration for the library in Web.config
	/// </summary>
	public class ViewStateOptimizerConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Gets or sets the StorageType property. This property indicates that this is the storage type for optimizing the ViewState.
		/// </summary>
		[ConfigurationProperty("type", DefaultValue = ViewStateOptimizerStorageType.FileStorage, IsRequired = false)]
		public ViewStateOptimizerStorageType StorageType
		{
			get
			{
				return (ViewStateOptimizerStorageType)this["type"];
			}
			set
			{
				this["type"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the FileViewStateOptimizerConfiguration property. This property indicates that this is the configuration element for storing file.
		/// </summary>
		[ConfigurationProperty("fileStorageViewStateOptimizer")]
		public FileViewStateOptimizerConfigurationElement FileViewStateOptimizerConfiguration
		{
			get
			{
				return (FileViewStateOptimizerConfigurationElement)this["fileStorageViewStateOptimizer"];
			}
			set
			{
				this["fileStorageViewStateOptimizer"] = value;
			}
		}
	}
}
