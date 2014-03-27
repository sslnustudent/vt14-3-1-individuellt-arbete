<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividueltArbete.Pages.PatientPages.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="OkDiv" runat="server" visible="false">
            <asp:Label ID="LabelOk" runat="server" Text="Label"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=PatientListing %>'>
                <asp:Image  ImageUrl="~/DeleteRed.png" Width="20px" ID="Delete" runat="server" /></asp:HyperLink>
        </div>
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel har inträffat" runat="server" />
    <asp:ListView ID="PatientListView" runat="server" ItemType="IndividueltArbete.Model.Patient" SelectMethod="PatientListView_GetData">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Namn
                    </th>
                    <th>Adress
                    </th>
                    <th>Postnr
                    </th>
                    <th>Ort
                    </th>
                    <th>Läkare
                    </th>
                    <th>Typ av läkare
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>

                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("PatientDetails", new { id = Item.PatientID })  %>' Text='<%# Item.Name %>' />
                </td>
                <td>
                    <%#: Item.Address %>
                </td>
                <td>
                    <%#: Item.PostalCode %>
                </td>
                <td>
                    <%#: Item.City %>
                </td>
                <td>
                    <%#: Item.Doctor %>
                </td>
                <td>
                    <%#: Item.DoctorType %>
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>
    

</asp:Content>
