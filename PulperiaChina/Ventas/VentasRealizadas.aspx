<%@ Page Title="" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="VentasRealizadas.aspx.cs" Inherits="PulperiaChina.Ventas.VentasRealizadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .vent {
            margin-left: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:MultiView ID="MvVentas" runat="server">
        <asp:View ID="Viewfactura" runat="server">
            <div class="container">
                <div class="row">
                    <h1 class="vent">Ventas Realizadas -- Pulperia China</h1>
                    <div class="col-md-12">
                        <br />
                        <hr />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <asp:Button ID="btnirfactura" OnClick="btnirfactura_Click" CssClass="btn btn-success" runat="server" Text="Nueva Factura" />
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtbuscar" placeHolder="Ingresa el nombre del Cliente" CssClass="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnbuscar" OnClick="btnbuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="GvFactura" runat="server" CssClass="table table-bordered" OnRowCommand="GvFactura_RowCommand"
                            DataKeyNames="ID_Venta" AllowPaging="true" PageSize="5" OnDataBound="GvFactura_DataBound1" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="YellowGreen" />
                            <Columns>
                                <asp:BoundField DataField="ID_Venta" HeaderText="Nº Factura" />
                                <asp:BoundField DataField="NombreEmpleado" HeaderText="Empleado" />
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDetalle" CommandName="detalle" CssClass="btn btn-info" runat="server" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-lg-1" style="text-align: right;">
                                        <h5>
                                            <asp:Label ID="lblPaginaMedidas" runat="server" Text="Pagina: " CssClass="label label-info"></asp:Label>
                                        </h5>
                                    </div>
                                    <div class="col-lg-1" style="text-align: left;">
                                        <asp:DropDownList ID="DropArto" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropArto_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-10" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label></h3>
                                    </div>
                                </div>
                            </PagerTemplate>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="Viewdetalle" runat="server">
            <div class="container">
                <div class="row">
                    <h1 class="vent">Detalle de la Venta Realizada -- Pulperia China</h1>
                    <div class="col-md-12">
                        <br />
                        <hr />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btndetRegresar" OnClick="btndetRegresar_Click" CssClass="btn btn-danger pull-right" runat="server" Text="Regresar" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnFacturanueva" OnClick="btnFacturanueva_Click" CssClass="btn btn-success pull-right" runat="server" Text="Nueva Factura" />
                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <br />
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="GvDetalle" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered"
                            DataKeyNames="ID_Venta, ID_Articulo, ID_DetalleTemp">
                            <HeaderStyle BackColor="YellowGreen" />
                            <Columns>
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Nombre_Articulo" HeaderText="Articulo" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="precioventa" HeaderText="Precio" />
                                <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                                <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>




</asp:Content>
