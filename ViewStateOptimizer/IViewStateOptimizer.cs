namespace ViewStateOptimizer
{
	/// <summary>
	/// This interface defines the implements for optimizing the ViewState.
	/// </summary>
    public interface IViewStateOptimizer
    {
		/// <summary>
		/// Loads the ViewState contents.
		/// </summary>
		void Load();

		/// <summary>
		/// Saves the ViewState contents.
		/// </summary>
		void Save();
    }
}
