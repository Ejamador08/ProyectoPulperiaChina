<%@ Page Title="" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="PulperiaChina.Reportes.Reporte1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnmasvendidos" OnClick="btnmasvendidos_Click" CssClass="btn btn-warning" runat="server" Text="Articulos Mas Vendidos" />

</asp:Content>
