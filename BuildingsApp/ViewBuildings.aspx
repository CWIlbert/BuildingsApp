<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBuildings.aspx.cs" Inherits="BuildingsApp.ViewBuildings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="BuildingID"
                ItemType="BuildingsApp.Models.Building" SelectMethod="GetBuildings" GroupPlaceholderID="groupPlaceHolder1"
                ItemPlaceholderID="itemPlaceHolder1">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-4">Name</div>
                            <div class="col-sm-4">Address</div>
                            <div class="col-sm-4"></div>
                        </div>
                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                     <div class="row">
                        <div class="col-sm-4">
                            <a href="UpdateBuilding.aspx?buildingID=<%#:Item.BuildingID%>">
                                <span>
                                    <%#:Item.Name%>
                                </span>
                            </a></div>
                        <div class="col-sm-4" ><%#:Item.Address%></div>
                        <div class="col-sm-4">
                            <a href="ViewEmployees.aspx?buildingID=<%#:Item.BuildingID%>">
                                <span>
                                    View Employees
                                </span>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <br />
        <p>
                <a href="ViewEmployees.aspx?buildingID=">
                    <span>
                        View Work From Home Employees
                    </span>
                </a>
        </p>
        <p>
            <asp:Button ID="AddBuildingButton" runat="server" Text="Create Employee" OnClick="AddEmployeeButton_Click"  CssClass="btn-primary active"/>
        </p>
    </section>
</asp:Content>