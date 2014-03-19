<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IndividueltArbete.Pages.DoctorPages.Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Style.css" rel="stylesheet" />
    <div id="OkDiv" runat="server" visible="false">
        <asp:Label ID="LabelOk" runat="server" Text="Label"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='~/Pages/DoctorPages/Listing.aspx'>
            <asp:Image ImageUrl="~/DeleteRed.png" Width="20px" ID="Delete" runat="server" />
        </asp:HyperLink>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Ett fel har uppståt" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary2" HeaderText="Ett fel har uppståt" runat="server"  ValidationGroup="EditG"/>
    <asp:ListView ID="PatientListView" runat="server" ItemType="IndividueltArbete.Model.Doctor" 
        SelectMethod="PatientListView_GetData"
        InsertMethod="PatientListView_InsertItem"
        InsertItemPosition="FirstItem"
        DataKeyNames="DoctorID, DoctorTypeId"
        DeleteMethod="PatientListView_DeleteItem"
        UpdateMethod="PatientListView_UpdateItem">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Förnamn
                    </th>
                    <th>Efternamn
                    </th>
                    <th>Typ av läkare
                    </th>
                    <th></th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#: Item.FirstName %>
                </td>
                <td>
                    <%#: Item.LastName %>
                </td>
                <td>
                    <%#: Item.DoctorTypes %>
                </td>
            
            <td class="command">
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                    OnClientClick='<%# String.Format("return confirm(\"Ta bort läkaren {0} {1}?\")", Item.FirstName, Item.LastName) %>' />
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
            </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
                <tr>

                    <td>
                        <asp:TextBox ID="FirstName1" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50" />
                        <asp:RequiredFieldValidator ControlToValidate="FirstName1" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName1" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50"/>
                        <asp:RequiredFieldValidator ControlToValidate="LastName1" ID="RequiredFieldValidator21" runat="server" ErrorMessage="Ange ett Efternamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            ItemType="IndividueltArbete.Model.DoctorType"
                            SelectMethod="DoctorTypeDropDownList_GetData"
                            DataTextField="DoctorTypes"
                            DataValueField="DoctorTypeId"
                            SelectedValue='<%# BindItem.DoctorTypes %>'>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>
            </InsertItemTemplate>
        <EditItemTemplate>
                <tr>

                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.FirstName %>' MaxLength="50" ValidationGroup="EditG" />
                        <asp:RequiredFieldValidator ValidationGroup="EditG" ControlToValidate="FirstName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange ett förnamn" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ValidationGroup="EditG" ID="LastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50" />
                        <asp:RequiredFieldValidator ValidationGroup="EditG" ControlToValidate="LastName" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange ett Efternamn" Display="None"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                        <asp:DropDownList ID="DoctorTypeDropDownList" runat="server" 
                            ItemType="IndividueltArbete.Model.DoctorType"
                            SelectMethod="DoctorTypeDropDownList_GetData"
                            DataTextField="DoctorTypes"
                            DataValueField="DoctorTypeId"
                            SelectedValue='<%# BindItem.DoctorTypeId %>'>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton5" ValidationGroup="EditG" runat="server" CommandName="Update" Text="Spara" />
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>



    </asp:ListView>
    



</asp:Content>
