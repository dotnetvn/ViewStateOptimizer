namespace ViewStateOptimizer.FileStorage
{
	/// <summary>
	/// The static class stored the options for the FileViewStateOptimizer.
	/// </summary>
	public static class FileViewStateOptimizerOptions
	{
		/// <summary>
		/// Gets or sets the ViewStateStorageRelativeFolder field. This field indicates that it's a relative folder
		/// for the ViewState storage on the server-side
		/// </summary>
		public static string ViewStateStorageRelativeFolder = "~/App_Data/VsFiles";

		/// <summary>
		/// Gets or sets the ViewStateKey field. This field indicates that it's a ViewState key stored on the hidden field.
		/// </summary>
		public static string ViewStateKey = "_ViewStateOptimizer";

		/// <summary>
		/// Gets or sets the ViewStatePrefixValue field. This field indicates that it's a ViewState prefix value stored as the value of hidden field.
		/// </summary>
		public static string ViewStatePrefixValue = "_vso";
	}
}
