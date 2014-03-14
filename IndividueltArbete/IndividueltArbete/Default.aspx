<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IndividueltArbete.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />
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
                    <%#: Item.Name %>
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
