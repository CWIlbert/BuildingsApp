<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateBuilding.aspx.cs" Inherits="BuildingsApp.CreateBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Building</h1>
    <hr />
    <h3>Add Building:</h3>
    <table class="table table-bordered table-hover table-condensed">
        <tr>
            <td><asp:Label ID="lblAddName" runat="server">Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Building name required." ControlToValidate="AddName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblAddAddress" runat="server">Address:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Building address required." ControlToValidate="AddAddress" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddBuildingButton" runat="server" Text="Add Building" OnClick="AddBuildingButton_Click"  CausesValidation="true" CssClass="btn-primary active"/>
    <asp:Label ID="lblAddStatus" runat="server" Text=""></asp:Label>
</asp:Content>
