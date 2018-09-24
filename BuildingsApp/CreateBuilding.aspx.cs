using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuildingsApp.Models;

namespace BuildingsApp
{
    public partial class CreateBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBuildingButton_Click(object sender, EventArgs e)
        {
            bool addSuccess = AddBuilding(this.AddName.Text, this.AddAddress.Text);
            if (addSuccess)
            {
                Response.Redirect("ViewBuildings.aspx");
            }
            else
            {
                this.lblAddStatus.Text = "Unable to add new building to database.";
            }
        }

        private bool AddBuilding(string buildingName, string buildingAddress)
        {
            using (BuildingContext buildingContext = new BuildingContext())
            {
                var newBuilding = new Building();
                newBuilding.Name = buildingName;
                newBuilding.Address = buildingAddress;

                buildingContext.Buildings.Add(newBuilding);
                buildingContext.SaveChanges();
            }
            return true;
        }
    }
}