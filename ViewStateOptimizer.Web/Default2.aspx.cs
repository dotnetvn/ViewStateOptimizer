using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewStateOptimizer.Web
{
	public partial class Default2 : System.Web.UI.Page
	{
		private List<Person> GetPersons()
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
			return personList;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				gv1.DataSource = GetPersons();
				gv1.DataBind();
			}
		}
	}
}