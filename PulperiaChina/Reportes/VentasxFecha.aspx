<%@ Page Title="" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="VentasxFecha.aspx.cs" Inherits="PulperiaChina.Reportes.VentasxFecha" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .top {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="top container">
        <div class="col-md-12">
            <div class="col-md-2"></div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Fecha Inicio</label>
                    <asp:TextBox ID="txtinicio" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Fecha Aun No Registrada" ControlToValidate="txtinicio" ValidationGroup="ver"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>Fecha Final</label>
                    <asp:TextBox ID="txtfinal" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Fecha Aun No Registrada" ControlToValidate="txtfinal" ValidationGroup="ver"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="btnver" OnClick="btnver_Click" CssClass="btn btn-warning" runat="server" Text="Ver Reporte" ValidationGroup="ver" />
            </div>
        </div>

    </div>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="margin-left: 53px; margin-right: 563px" Width="1193px">
        <LocalReport ReportEmbeddedResource="PulperiaChina.Reportes.VentasxFecha.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ReporteTableAdapters.VentasxFehaTableAdapter"></asp:ObjectDataSource>

</asp:Content>
