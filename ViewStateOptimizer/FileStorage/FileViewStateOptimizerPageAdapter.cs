namespace ViewStateOptimizer.FileStorage
{
	using System.Web.UI;
	using System.Web.UI.Adapters;

	/// <summary>
	/// This class implements customizing the default PageStatePersister to FileViewStateOptimizer.
	/// </summary>
	public class FileViewStateOptimizerPageAdapter : PageAdapter
	{
		/// <summary>
		/// Gets the file state persister.
		/// </summary>
		/// <returns>Returns the PageStatePersister type as FileViewStateOptimizer</returns>
		public override PageStatePersister GetStatePersister()
		{
			return (new FileViewStateOptimizer(this.Page));
		}
	}
}
