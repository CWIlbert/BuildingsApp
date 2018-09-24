<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="BuildingsApp.CreateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Employee</h1>
    <hr />
    <h3>Create Employee:</h3>
    <table class="table table-bordered table-hover table-condensed">
        <tr>
            <td><asp:Label ID="lblAddFirstName" runat="server">First Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Employee first name required." ControlToValidate="AddFirstName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAddLastName" runat="server">Last Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Employee last name required." ControlToValidate="AddLastName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAddSalary" runat="server">Salary:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddSalary" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Employee salary required." ControlToValidate="AddSalary" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Valid employee salary required." ControlToValidate="AddSalary" ValidationExpression="[\$]*\$?\d+((,\d{1,12})+)?(\.\d{1,2})?" 
                    SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAddBuilding" runat="server">Building:</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlBuilding" runat="server" DataTextField="Name" DataValueField="BuildingID" CssClass="dropdown-toggle btn-default focus">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddBuildingButton" runat="server" Text="Add Employee" OnClick="AddEmployeeButton_Click"  CausesValidation="true" CssClass="btn-primary active"/>
    <asp:Label ID="lblAddStatus" runat="server" Text=""></asp:Label>
</asp:Content>
