<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="BuildingsApp.ViewEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Currently viewing employees in Building: &nbsp;
            <asp:DropDownList ID="ddlBuilding" runat="server" DataTextField="Name" DataValueField="BuildingID" CssClass="dropdown-toggle btn-default focus"
                onChange="window.document.location.href='ViewEmployees?buildingID=' + this.options[this.selectedIndex].value;">
            </asp:DropDownList>
    <br />
    <br />
            <asp:ListView ID="employeeList" runat="server" DataKeyNames="EmployeeID" ItemType="BuildingsApp.Models.Employee" 
                GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1">
                <LayoutTemplate>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-4">Name</div>
                            <div class="col-sm-4">Salary</div>
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
                            <a href="UpdateEmployee.aspx?employeeID=<%#:Item.EmployeeID%>">
                                <span>
                                    <%# Item.LastName %>, <%# Item.FirstName %>
                                </span>
                            </a>
                        </div>
                        <div class="col-sm-4"><%# String.Format("{0:c}", Item.Salary) %></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
    <br />
    <div>
        <p>
            <strong>
                <asp:Label ID="LabelTotalText" runat="server" Text="Total Salary: "></asp:Label>
                <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            </strong> 
            <br />
            <strong>
                <asp:Label ID="LabelMaxText" runat="server" Text="Max. Salary: "></asp:Label>
                <asp:Label ID="lblMaxText" runat="server" EnableViewState="false"></asp:Label>
            </strong>
            <br />
            <strong>
                <asp:Label ID="LabelMinText" runat="server" Text="Min. Salary: "></asp:Label>
                <asp:Label ID="lblMinText" runat="server" EnableViewState="false"></asp:Label>
            </strong> 
            <br />
            <strong>
                <asp:Label ID="LabelAvgText" runat="server" Text="Avg. Salary: "></asp:Label>
                <asp:Label ID="lblAvgText" runat="server" EnableViewState="false"></asp:Label>
            </strong> 
        </p>
    </div>
    <br />
    <br />
    <p>
        <asp:Button ID="AddEmployeeButton" runat="server" Text="Create Employee" OnClick="AddEmployeeButton_Click"  CssClass="btn-primary active"/>
    </p>
</asp:Content>
