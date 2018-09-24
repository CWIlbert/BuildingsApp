using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuildingsApp.Models;
using System.Web.ModelBinding;

namespace BuildingsApp
{
    public partial class ViewBuildings : System.Web.UI.Page
    {
        private BuildingContext buildingContext = new BuildingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Building> GetBuildings()
        {
            IQueryable<Building> query = buildingContext.Buildings;
            return query;
        }

        protected void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateBuilding.aspx");
        }
    }
}