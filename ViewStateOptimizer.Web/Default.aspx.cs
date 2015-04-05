namespace ViewStateOptimizer.Web
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using ViewStateOptimizer.FileStorage;

	public partial class Default : System.Web.UI.Page
	{
		private List<Person> GetPersons(string vsKey)
		{
			if(ViewState[vsKey] == null)
			{
				var personList = new List<Person>();

				personList.Add(new Person { FirstName = "Phat", LastName = "Ly" });
				personList.Add(new Person { FirstName = "Lam", LastName = "Ly" });
				personList.Add(new Person { FirstName = "Tam", LastName = "Chieu" });

				personList.Add(new Person { FirstName = "Phuc", LastName = "To" });
				personList.Add(new Person { FirstName = "Phuong", LastName = "Tran" });
				personList.Add(new Person { FirstName = "Phuong", LastName = "Pham" });

				personList.Add(new Person { FirstName = "Phuong", LastName = "Nguyen" });
				personList.Add(new Person { FirstName = "Khanh", LastName = "Pham" });
				personList.Add(new Person { FirstName = "Viet", LastName = "Pham" });

				personList.Add(new Person { FirstName = "Minh", LastName = "Ly" });
				ViewState.Add(vsKey, personList);

			}
			return ViewState[vsKey] as List<Person>;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				gv1.DataSource = GetPersons("Persons1");
				gv2.DataSource = GetPersons("Persons2");

				Page.DataBind();
			}
		}

		// --- NOTES:
		// --- Configure here for the Page level.
		// --- Please configure the global using Page Adapters.
		/*protected override PageStatePersister PageStatePersister
		{
			get
			{
				return new FileViewStateOptimizer(Page);
			}
		}*/

		protected void btnSubmit1_Click(object sender, EventArgs e)
		{
			(ViewState["Persons1"] as List<Person>).Add(new Person()
			{
				FirstName = "Thanh",
				LastName = "Ly"
			});
			gv1.DataSource = GetPersons("Persons1");
			gv1.DataBind();
		}

		protected void btnSubmit2_Click(object sender, EventArgs e)
		{
			(ViewState["Persons2"] as List<Person>).Add(new Person()
			{
				FirstName = "Son",
				LastName = "Ly"
			});
			gv2.DataSource = GetPersons("Persons2");
			gv2.DataBind();
		}
	}
}
