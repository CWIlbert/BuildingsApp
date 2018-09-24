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
    public partial class ViewEmployees : System.Web.UI.Page
    {
        private BuildingContext buildingContext = new BuildingContext();
        private string rawId = string.Empty;
        private int? buildingId = null;
        private IQueryable<Employee> filteredEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["buildingID"]))
                {
                    rawId = Request.QueryString["buildingID"];
                    buildingId = Convert.ToInt16(rawId);
                }

                filteredEmployees = buildingContext.Employees.Where(b => b.BuildingID == buildingId);

                BuildDropDown(rawId);
                BindList();
                DisplayTotal();
                DisplayMax();
                DisplayMin();
                DisplayAvg();
            }
        }

        private void BuildDropDown(string selectedId)
        {
            var query = from b in buildingContext.Buildings
                          orderby b.Name
                          select new { b.BuildingID, b.Name };

            this.ddlBuilding.DataSource = query.ToList();
            this.ddlBuilding.Items.Add(new ListItem("Home Office",string.Empty));
            this.ddlBuilding.AppendDataBoundItems = true;
            this.ddlBuilding.DataTextField = "Name";
            this.ddlBuilding.DataValueField = "BuildingID";
            this.ddlBuilding.DataBind();
            this.ddlBuilding.Items.FindByValue(selectedId).Selected = true;
        }

        private void BindList()
        {
            this.employeeList.DataSource = filteredEmployees.ToList();
            this.employeeList.DataBind();
        }

        private void DisplayTotal()
        {
            if (filteredEmployees.Any())
                this.lblTotal.Text = String.Format("{0:C}", filteredEmployees.Sum(t => t.Salary));
            else
                this.lblTotal.Text = "0";
        }

        private void DisplayMax()
        {
            if (filteredEmployees.Any())
                this.lblMaxText.Text = String.Format("{0:C}", filteredEmployees.Max(t => t.Salary));
            else
                this.lblMaxText.Text = "0";
        }

        private void DisplayMin()
        {
            if (filteredEmployees.Any())
                this.lblMinText.Text = String.Format("{0:C}", filteredEmployees.Min(t => t.Salary));
            else
                this.lblMinText.Text = "0";
        }

        private void DisplayAvg()
        {
            if (filteredEmployees.Any())
                this.lblAvgText.Text = String.Format("{0:C}", filteredEmployees.Average(t => t.Salary));
            else
                this.lblAvgText.Text = "0";
        }

        protected void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEmployee.aspx?" + Request.QueryString);
        }
    }
}