namespace ViewStateOptimizer
{
	using System.Configuration;

	/// <summary>
	/// This class acts as a helper for handling the general things related this library.
	/// </summary>
	public static class ViewStateOptimizerHelper
	{
		/// <summary>
		/// Gets or sets the _section field. This field indicates that this stores the viewStateOptimizer section from Web.config file.
		/// </summary>
		private static ViewStateOptimizerConfigurationSection _section;

		/// <summary>
		/// Gets the Section property. This property indicates that this gets the viewStateOptimizer section from Web.config file.
		/// </summary>
		public static ViewStateOptimizerConfigurationSection Section
		{
			get
			{
				if (_section == null)
				{
					var sectionObj = ConfigurationManager.GetSection("viewStateOptimizer");
					if(sectionObj is ViewStateOptimizerConfigurationSection)
					{
						_section = (ViewStateOptimizerConfigurationSection)sectionObj;
					}
					else
					{
						throw new ConfigurationErrorsException("The viewStateOptimizer section is required for configuring the ViewStateOptimizer library in Web.config.");
					}
				}
				return _section;
			}
		}
	}
}
