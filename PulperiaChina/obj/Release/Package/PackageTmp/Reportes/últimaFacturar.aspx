<%@ Page Title="" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="últimaFacturar.aspx.cs" Inherits="PulperiaChina.Reportes.últimaFacturar" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div  class="row">
            <div class="col-md-12">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnnuevafactura" OnClick="btnnuevafactura_Click" CssClass="btn btn-success" runat="server" Text="Nueva Factura" />
                </div>
                <br />
                <br />
                <br />
                <hr />
            </div>
            <div class="col-md-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="margin-left: 106px" Width="1009px">
                    <LocalReport ReportEmbeddedResource="PulperiaChina.Reportes.últimaFactura.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ReporteTableAdapters.últimaFacturaTableAdapter"></asp:ObjectDataSource>
            </div>
            <div class="col-md-12">
                <hr />
                <br />
                <br />
                <br />
            </div>
        </div>
    </div>




</asp:Content>
