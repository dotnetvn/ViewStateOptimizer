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
		}
	}
}
