using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Data.Entity;
using BuildingsApp.Models;

namespace BuildingsApp
{
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        private BuildingContext buildingContext = new BuildingContext();
        private string rawId = string.Empty;
        private int? employeeId = 0;
        private Employee filteredEmployee;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuildDropDown();

                if (!String.IsNullOrEmpty(Request.QueryString["employeeID"]))
                {
                    rawId = Request.QueryString["employeeID"];
                    employeeId = Convert.ToInt16(rawId);

                    var query = buildingContext.Employees.Where(b => b.EmployeeID == employeeId);
                    if (query.Any())
                    {
                        filteredEmployee = query.SingleOrDefault();
                        PopulateEmployee(filteredEmployee);
                    }
                    else
                    {
                        this.lblUpdateStatus.Text = "Unable to find Employee.";
                        this.UpdateEmployeeButton.Enabled = false;
                        this.DeleteEmployeeButton.Enabled = false;
                    }
                }
            }
        }

        protected void UpdateEmployeeButton_Click(object sender, EventArgs e)
        {
            int updateEmployeeId = Convert.ToInt16(Request.QueryString["employeeID"]);

            bool updateSuccess = ModifyEmployee(updateEmployeeId, this.UpdateFirstName.Text, this.UpdateLastName.Text, this.UpdateSalary.Text, this.ddlBuilding.SelectedValue);

            if (updateSuccess)
            {
                Response.Redirect("ViewEmployees.aspx?buildingID=" + this.ddlBuilding.SelectedValue);
            }
            else
            {
                this.lblUpdateStatus.Text = "Unable to update employee in database.";
            }
        }

        protected void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt16(Request.QueryString["employeeID"]);

            bool updateSuccess = DeleteEmployee(employeeId);

            if (updateSuccess)
            {
                Response.Redirect("ViewEmployees.aspx?buildingID=" + this.ddlBuilding.SelectedValue);
            }
            else
            {
                this.lblUpdateStatus.Text = "Unable to delete employee from database.";
            }
        }

        private void BuildDropDown()
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
          }
        
        private void PopulateEmployee(Employee filteredEmployee)
        {
            this.UpdateFirstName.Text = filteredEmployee.FirstName;
            this.UpdateLastName.Text = filteredEmployee.LastName;
            this.UpdateSalary.Text = filteredEmployee.Salary.ToString();
            this.ddlBuilding.Items.FindByValue(filteredEmployee.BuildingID.ToString()).Selected = true;
        }

        private bool ModifyEmployee(int updateEmployeeId, string firstName, string lastName, string salary, string buildingId)
        {
            using (BuildingContext buildingContext = new BuildingContext())
            {
                var originalEmployee = buildingContext.Employees.Find(updateEmployeeId);

                if (originalEmployee == null)
                {
                    return false;
                }

                originalEmployee.FirstName = firstName;
                originalEmployee.LastName = lastName;
                originalEmployee.Salary = Convert.ToDouble(salary);
                originalEmployee.BuildingID = Int32.TryParse(buildingId, out var tempVal) ? tempVal : (int?)null;

                buildingContext.SaveChanges();
            }
            return true;
        }

        private bool DeleteEmployee(int employeeID)
        {
            using (BuildingContext buildingContext = new BuildingContext())
            {
                var originalEmployee = buildingContext.Employees.Find(employeeID);

                if (originalEmployee == null)
                {
                    return false;
                }

                buildingContext.Employees.Remove(originalEmployee);
                buildingContext.SaveChanges();
            }
            return true;
        }
    }
}