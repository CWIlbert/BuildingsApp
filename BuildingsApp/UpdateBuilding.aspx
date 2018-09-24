<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateBuilding.aspx.cs" Inherits="BuildingsApp.UpdateBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Building</h1>
    <hr />
    <h3>Update Building:</h3>
    <table class="table table-bordered table-hover table-condensed">
        <tr>
            <td><asp:Label ID="lblUpdateName" runat="server">Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Building name required." ControlToValidate="UpdateName" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblUpdateAddress" runat="server">Address:</asp:Label></td>
            <td>
                <asp:TextBox ID="UpdateAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Building address required." ControlToValidate="UpdateAddress" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="UpdateBuildingButton" runat="server" Text="Update Building" OnClick="UpdateBuildingButton_Click"  CausesValidation="true" CssClass="btn-primary active"/>
    <asp:Button ID="DeleteBuildingButton" runat="server" Text="Delete Building" OnClick="DeleteBuildingButton_Click"  CausesValidation="true" CssClass="btn-danger"/>
    <asp:Label ID="lblUpdateStatus" runat="server" Text=""></asp:Label>
</asp:Content>
