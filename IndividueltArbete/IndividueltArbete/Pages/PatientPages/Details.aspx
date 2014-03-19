<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="IndividueltArbete.Pages.PatientPages.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h1>
                Patientdetaljer
            </h1>
            <div id="OkDiv" runat="server" visible="false">
            <asp:Label ID="LabelOk" runat="server" Text="Label"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=PatientListing %>'>
                <asp:Image  ImageUrl="~/DeleteRed.png" Width="20px" ID="Delete" runat="server" /></asp:HyperLink>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel har inträffat" runat="server" />
            <asp:FormView ID="PatientFormView" runat="server"
                ItemType="IndividueltArbete.Model.Patient"
                SelectMethod="PatientFormView_GetItem"
                RenderOuterTable="false"
                DataKeyNames="PatientID"
                DeleteMethod="PatientFormView_DeleteItem">
                <ItemTemplate>
                    <h3>
                        <label for="Name">Namn</label>
                    </h3>
                    <p>
                        <%#: (Item.FirstName + " " + Item.LastName) %> 
                    </p>
                    <h3>
                        <label for="Address">Adress</label>
                    </h3>
                    <p>
                        <%#: Item.Address %>
                    </p>
                    <h3>
                        <label for="PostalCode">Postnummer</label>
                    </h3>
                    <p>
                        <%#: Item.PostalCode %>
                    </p>
                    <h3>
                        <label for="City">Ort</label>
                    </h3>
                    <p>
                        <%#: Item.City %>
                    </p>
                    <h3>
                        <label for="City">Läkare</label>
                    </h3>
                    <p>
                        <%#: Item.Doctor %>
                    </p>
                    <h3>
                        <label for="City">Typ av läkare</label>
                    </h3>
                    <p>
                        <%#: Item.DoctorType %>
                    </p>


                    <div>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("PatientEdit", new { id = Item.PatientID }) %>' />
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                          OnClientClick='<%# String.Format("return confirm(\"Ta bort Patienten {0} {1}?\")", Item.FirstName, Item.LastName) %>' />
                        <asp:HyperLink ID="HyperLink3" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("PatientListing", null)%>' />
                    </div>
                </ItemTemplate>
            </asp:FormView>
</asp:Content>
