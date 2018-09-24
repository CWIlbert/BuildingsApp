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
    public partial class UpdateBuilding : System.Web.UI.Page
    {
        private BuildingContext buildingContext = new BuildingContext();
        private string rawId = string.Empty;
        private int buildingId = 0;
        private Building filteredBuilding;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["buildingID"]))
                {
                    rawId = Request.QueryString["buildingID"];
                    buildingId = Convert.ToInt16(rawId);

                    var query = buildingContext.Buildings.Where(b => b.BuildingID == buildingId);
                    if (query.Any())
                    {
                        filteredBuilding = query.SingleOrDefault();
                        PopulateBuilding(filteredBuilding);
                    }
                    else
                    {
                        this.lblUpdateStatus.Text = "Unable to find Building.";
                        this.UpdateBuildingButton.Enabled = false;
                        this.DeleteBuildingButton.Enabled = false;
                    }
                }
            }
        }

        private void PopulateBuilding(Building filteredBuilding)
        {
            this.UpdateName.Text = filteredBuilding.Name;
            this.UpdateAddress.Text = filteredBuilding.Address;
        }

        protected void UpdateBuildingButton_Click(object sender, EventArgs e)
        {
            int updateBuildingId = Convert.ToInt16(Request.QueryString["buildingID"]);

            bool updateSuccess = ModifyBuilding(updateBuildingId, this.UpdateName.Text, this.UpdateAddress.Text);

            if (updateSuccess)
            {
                Response.Redirect("ViewBuildings.aspx");
            }
            else
            {
                this.lblUpdateStatus.Text = "Unable to update building in database.";
            }
        }

        protected void DeleteBuildingButton_Click(object sender, EventArgs e)
        {
            int deleteBuildingId = Convert.ToInt16(Request.QueryString["buildingID"]);

            bool updateSuccess = DeleteBuilding(deleteBuildingId);

            if (updateSuccess)
            {
                Response.Redirect("ViewBuildings.aspx");
            }
            else
            {
                this.lblUpdateStatus.Text = "Unable to delete building from database.";
            }
        }

        private bool ModifyBuilding(int buildingId, string buildingName, string buildingAddress)
        {
            using (BuildingContext buildingContext = new BuildingContext())
            {

                var originalBuilding = buildingContext.Buildings.Find(buildingId);

                if (originalBuilding == null)
                {
                    return false;
                }

                originalBuilding.Name = buildingName;
                originalBuilding.Address = buildingAddress;

                buildingContext.SaveChanges();
            }
            return true;
        }
        
        private bool DeleteBuilding(int buildingID)
        {
            using (BuildingContext buildingContext = new BuildingContext())
            {
                var originalBuilding = buildingContext.Buildings.Find(buildingID);

                if (originalBuilding == null)
                {
                    return false;
                }

                buildingContext.Buildings.Remove(originalBuilding);
                buildingContext.SaveChanges();
            }
            return true;
        }
    }
}