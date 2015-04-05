namespace ViewStateOptimizer
{
	using System.Web.UI;
	using System.Web.UI.Adapters;

	/// <summary>
	/// This class implements customizing the default PageStatePersister to SessionViewStateOptimizer.
	/// </summary>
	public class SessionViewStateOptimizerPageAdapter : PageAdapter
	{
		/// <summary>
		/// Gets the session state persister.
		/// </summary>
		/// <returns>Returns the PageStatePersister type as SessionPageStatePersister</returns>
		public override PageStatePersister GetStatePersister()
		{
			return (new SessionPageStatePersister(this.Page));
		}
	}
}
