<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IndividueltArbete.Pages.PatientPages.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel har inträffat" runat="server" />
    <asp:FormView ID="PatientFormView" runat="server"
        ItemType="IndividueltArbete.Model.Patient"
        DataKeyNames="PatientID, DoctorID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="PatientFormView_GetItem"
        UpdateMethod="PatientFormView_UpdateItem">
        <EditItemTemplate>
            <div class="editor-label">
                <label for="Name">Förnamn</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ControlToValidate="FirstName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="editor-label">
                <label for="FirstName">Efternamn</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50" />
                <asp:RequiredFieldValidator ControlToValidate="LastName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange ett efternamn" Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="editor-label">
                <label for="Address">Adress</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
                <asp:RequiredFieldValidator ControlToValidate="Address" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ange en adress" Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="editor-label">
                <label for="PostalCode">Postnummer</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.PostalCode %>' MaxLength="5"/>
                <asp:RegularExpressionValidator ControlToValidate="PostalCode" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Postnummret är inte korrekt" ValidationExpression="[0-9][0-9][0-9][0-9][0-9]" Display="None"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ControlToValidate="PostalCode" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ange ett postnummer" Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="editor-label">
                <label for="City">Ort</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' MaxLength="25"/>
                <asp:RequiredFieldValidator ControlToValidate="City" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ange en ort" Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="editor-label">
                <label for="Doctor">Läkare</label>
            </div>
            <div class="editor-field">

                                <asp:DropDownList ID="Doctor" runat="server"
                    ItemType="IndividueltArbete.Model.Doctor"
                    SelectMethod="DoctorDropDownList_GetData"
                    DataTextField="Name"
                    DataValueField="DoctorID"
                    SelectedValue='<%# BindItem.DoctorID %>'>
                </asp:DropDownList>
                    
                </div>
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" />
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("PatientDetails", new { id = Item.PatientID }) %>' />
                </div>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
