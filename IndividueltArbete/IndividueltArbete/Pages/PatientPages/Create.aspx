<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IndividueltArbete.Pages.PatientPages.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Style.css" rel="stylesheet" />
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel har inträffat" runat="server" />
    <asp:FormView ID="FormView1" runat="server"
        ItemType="IndividueltArbete.Model.Patient"
        InsertMethod="FormView1_InsertItem"
         DefaultMode="Insert"
         RenderOuterTable="false">
        <InsertItemTemplate>
    <p>Förnamn</p>
    <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="FirstName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>

    <p>Efternamn</p>
    <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="LastName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange ett efternamn" Display="None"></asp:RequiredFieldValidator>

    <p>Adress</p>
    <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' MaxLength="30"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="Address" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ange en adress" Display="None"></asp:RequiredFieldValidator>

    <p>Postnr</p>
    <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' MaxLength="5"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="PostalCode" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ange ett postnummer" Display="None"></asp:RequiredFieldValidator>

    <p>Ort</p>
    <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' MaxLength="25"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="City" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ange en ort" Display="None"></asp:RequiredFieldValidator>

    <p>Läkare</p>
            <asp:DropDownList ID="DropDownList1" runat="server"
                 ItemType="IndividueltArbete.Model.Doctor"
                 SelectMethod="DoctorDropDownList_GetData"
                 DataTextField="Name"
                 DataValueField="DoctorId"
                 SelectedValue='<%# BindItem.Doctor %>'>

            </asp:DropDownList>
            <asp:Button ID="OkButton" runat="server" Text="Spara"  CommandName="Insert" />
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>

