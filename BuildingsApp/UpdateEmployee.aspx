<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="BuildingsApp.UpdateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Employee</h1>
    <hr />
    <h3>Update Employee:</h3>
    <table class="table table-bordered table-hover table-condensed">
        <tr>
            <td><asp:Label ID="lblUpdateFirstName" runat="server">First Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Employee first name required." ControlToValidate="UpdateFirstName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblUpdateLastName" runat="server">Last Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Employee last name required." ControlToValidate="UpdateLastName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblUpdateSalary" runat="server">Salary:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateSalary" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Employee salary required." ControlToValidate="UpdateSalary" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Valid employee salary required." ControlToValidate="UpdateSalary" ValidationExpression="[\$]*\$?\d+((,\d{1,12})+)?(\.\d{1,2})?" 
                    SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblUpdateBuilding" runat="server">Building:</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlBuilding" runat="server" DataTextField="Name" DataValueField="BuildingID" CssClass="dropdown-toggle btn-default focus">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="UpdateEmployeeButton" runat="server" Text="Update Employee" OnClick="UpdateEmployeeButton_Click"  CausesValidation="true" CssClass="btn-primary active"/>
    <asp:Button ID="DeleteEmployeeButton" runat="server" Text="Delete Employee" OnClick="DeleteEmployeeButton_Click"  CausesValidation="true" CssClass="btn-danger"/>
    <asp:Label ID="lblUpdateStatus" runat="server" Text=""></asp:Label>
</asp:Content>
