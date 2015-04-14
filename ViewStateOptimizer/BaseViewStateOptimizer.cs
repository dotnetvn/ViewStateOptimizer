namespace ViewStateOptimizer
{
	using System;
	using System.Web.UI;

	/// <summary>
	/// This abstract class implements as base class for implementing the custom page state persister.
	/// </summary>
	public abstract class BaseViewStateOptimizer : PageStatePersister, IViewStateOptimizer
	{
		/// <summary>
		/// Initializes a new instance of the ViewStateOptimizer.BaseViewStateOptimizer class.
		/// </summary>
		/// <param name="page">The System.Web.UI.Page that the view state persistence mechanism is created for.</param>
		protected BaseViewStateOptimizer(Page page)
            : base(page)
        {
        }

		/// <summary>
		/// Loads the ViewState contents into a string.
		/// </summary>
		/// <returns>Returns the ViewState contents</returns>
		public abstract string LoadViewStateContents();

		/// <summary>
		/// Saves the ViewState contents.
		/// </summary>
		/// <param name="viewStateContents">ViewState contents</param>
		/// <returns>Returns true if saving OK, otherwise will be false</returns>
		public abstract bool SaveViewStateContents(string viewStateContents);

		/// <summary>
		/// Loads the ViewState contents into ViewState and ControlState.
		/// </summary>
		public override void Load()
		{
			IStateFormatter formatter = this.StateFormatter;
			var viewStateContents = LoadViewStateContents();
			var statePair = (Pair)formatter.Deserialize(viewStateContents);
			if (Page.Session != null)
			{
				if (statePair != null)
				{
					this.ViewState = statePair.First;
					this.ControlState = statePair.Second;
				}
			}
			else
			{
				throw new InvalidOperationException("The Session is required for ViewStateOptimizer.");
			}
		}

		/// <summary>
		/// Saves the ViewState contents.
		/// </summary>
		public override void Save()
		{
			if (ViewState != null || ControlState != null)
			{
				if (Page.Session != null)
				{
					// --- Serialize the ViewState contents into a string
					var formatter = this.StateFormatter;
					var statePair = new Pair(ViewState, ControlState);
					var serializedState = formatter.Serialize(statePair);
					// --- End

					// Saves to the ViewSate contents with the specified string
					if (!SaveViewStateContents(serializedState))
					{
						throw new InvalidOperationException("Can't save the ViewState contents to the specified location. Please ensure all configurations are correct.");
					}
				}
				else
				{
					throw new InvalidOperationException("The Session is required for ViewStateOptimizer.");
				}
			}
		}
	}
}
