namespace ViewStateOptimizer.Web
{
	using System;
	using System.Web;
	using System.Web.Security;
	using System.Web.SessionState;
	using ViewStateOptimizer.FileStorage;

	public class Global : BaseFileViewStateOptimizerHttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			/*************************************************************
			 * NOTES: change own options for the FileViewStateOptimizer here
			 *************************************************************/
			// --- Change the ViewState configuration for the file storage
			/*FileViewStateOptimizerOptions.ViewStateKey = "_YourViewState";
			FileViewStateOptimizerOptions.ViewStatePrefixValue = "_your";
			FileViewStateOptimizerOptions.ViewStateStorageRelativeFolder = "~/vso";*/
			// --- End
		}
	}
}