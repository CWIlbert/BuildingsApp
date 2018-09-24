using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using BuildingsApp.Models;

namespace BuildingsApp
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        private BuildingContext buildingContext = new BuildingContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildDropDown(Request.QueryString["buildingID"]);
        }

        protected void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            bool addSuccess = AddEmployee(this.AddFirstName.Text, this.AddLastName.Text, this.AddSalary.Text, this.ddlBuilding.SelectedValue);
            if (addSuccess)
            {
                Response.Redirect("ViewEmployees.aspx?buildingID=" + this.ddlBuilding.SelectedValue);
            }
            else
            {
                this.lblAddStatus.Text = "Unable to add new employee to database.";
            }
        }

        private void BuildDropDown(string selectedId)
        {
            var query = from b in buildingContext.Buildings
                        orderby b.Name
                        select new { b.BuildingID, b.Name };

            this.ddlBuilding.DataSource = query.ToList();
            this.ddlBuilding.Items.Add(new ListItem("Home Office", string.Empty));
            this.ddlBuilding.AppendDataBoundItems = true;
            this.ddlBuilding.DataTextField = "Name";
            this.ddlBuilding.DataValueField = "BuildingID";
            this.ddlBuilding.DataBind();
            this.ddlBuilding.Items.FindByValue(selectedId).Selected = true;
        }

        private bool AddEmployee(string firstName, string lastName, string salary, string buildingId)
        {
            using (buildingContext)
            {
                var newEmployee = new Employee();
                newEmployee.FirstName = firstName;
                newEmployee.LastName = lastName;
                newEmployee.Salary = Convert.ToDouble(salary);
                newEmployee.BuildingID = Int32.TryParse(buildingId, out var tempVal) ? tempVal : (int?)null;

                buildingContext.Employees.Add(newEmployee);
                buildingContext.SaveChanges();
            }
            return true;
        }
    }
}