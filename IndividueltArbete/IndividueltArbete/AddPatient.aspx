﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="IndividueltArbete.AddPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Förnamn</p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <p>Efternamn</p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <p>Adress</p>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <p>Postnr</p>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <p>Ort</p>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <p>Läkare</p>
    <asp:DropDownList ID="DoctorDropDownList" runat="server">

    </asp:DropDownList>
</asp:Content>
