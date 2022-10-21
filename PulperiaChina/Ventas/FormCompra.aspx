<%@ Page Title="" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="PulperiaChina.Ventas.FormCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
    <style>
        .btni {
            width: 20%;
            height: 25%;
            margin-left: 10%;
            margin-top: 10%;
            margin-bottom: 10%;
        }

        .texto {
            position: absolute;
            top: 73%;
            font-size: 30px;
            color: yellowgreen;
            margin-left: 13%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:MultiView ID="MVCompra" runat="server">
        <asp:View ID="VistaEdicion" runat="server">
            <center><h1 style="font-family:Arial, sans-serif;">Compra de Artículos</h1></center>
            <h4>Información de la Compra</h4>
            <hr />
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Fecha</label>
                            <asp:TextBox ID="txtfecha" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-12">
                            <div class="col-md-1"></div>
                            <div class="col-md-9">
                                <div class="form-group">
                                    <label>Proveedor</label>
                                    <asp:TextBox ID="txtproveedor" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2"></div>
                            <%--<div class="col-md-1">
                                <br />
                                <asp:Button ID="btnprov" OnClick="btnprov_Click" CssClass="btn btn-default" runat="server" Text="..." />
                            </div>--%>
                            <%--<div class="col-md-3">
                                <br />
                                <asp:Button ID="btnagregarprov" OnClick="btnagregarprov_Click" CssClass="btn btn-info" runat="server" Text="Add Proveedor" />
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Aun No Hay Proveedor Seleccionado" ControlToValidate="txtproveedor" ValidationGroup="Agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="Hdproveedor" runat="server" />--%>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Nº de Factura</label>
                            <asp:TextBox ID="txtnumfac" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <hr />
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="col-md-12">
                                <div class="col-md-8">
                                    <label>Artículo</label>
                                    <asp:TextBox ID="txtarticulo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Aun No Hay Articulo Seleccionado" ControlToValidate="txtarticulo" ValidationGroup="Agregar" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <br />
                                    <asp:Button ID="btnart" OnClick="btnart_Click" CssClass="btn btn-warning" runat="server" Text="..." />
                                </div>
                                <div class="col-md-3">
                                    <br />
                                    <asp:Button ID="btnnuevoart" OnClick="btnnuevoart_Click" CssClass="btn btn-primary" runat="server" Text="Add Artículo" />
                                </div>
                            </div>
                            <asp:HiddenField ID="HdArticulo" runat="server" />
                            <asp:HiddenField ID="Hdproveedor" runat="server" />
                            <asp:HiddenField ID="Hdbodega" runat="server" />
                            <asp:HiddenField ID="Hdmarca" runat="server" />
                        </div>
                        <div class="col-md-2">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtcantidad" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="Validation" ValidationGroup="Agregar" ControlToValidate="txtcantidad" runat="server" ErrorMessage="* Cantidad Requerida"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <label>Precio Compra</label>
                            <asp:TextBox ID="txtprecio" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" CssClass="Validation" ValidationGroup="Agregar" ControlToValidate="txtprecio" runat="server" ErrorMessage="* Precio de Compra Requerido"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-6"></div>
                        <div class="col-md-3">
                            <label>Bodega</label>
                            <asp:TextBox ID="txtbodega" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            <%--<asp:DropDownList ID="DropBodega" CssClass="form-control" runat="server">
                                <asp:ListItem>--Seleccione Una Bodega--</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                        <div class="col-md-3">
                            <label>Marca</label>
                            <asp:TextBox ID="txtmarca" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                            <%--<asp:DropDownList ID="DropMarca" CssClass="form-control" runat="server">
                                <asp:ListItem>--Seleccione Una Marca--</asp:ListItem>
                            </asp:DropDownList>--%>
                        </div>
                        <%--<div class="col-md-2"></div>--%>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <div class="col-md-12">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar" ValidationGroup="Agregar" />
                </div>
            </div>
            <br />
            <hr />
            <center><h1><i class="glyphicon glyphicon-list"> Detalle de la Compra</i></h1></center>
            <asp:GridView ID="GvDetalleCompra" CssClass="table table-bordered" OnRowCommand="GvDetalleCompra_RowCommand"
                AutoGenerateColumns="false" DataKeyNames="ID_ComraTmp" runat="server">
                <HeaderStyle BackColor="YellowGreen" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="NombreArticulo" HeaderText="Articulo" />
                    <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="Precio_Compra" HeaderText="Precio Compra" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Existencia" />
                    <asp:BoundField DataField="Fecha_Entrega" HeaderText="Fecha Entrega" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnquitar" CommandName="eliminar" CssClass="btn btn-danger" runat="server" Text="Quitar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <div class="col-md-12">
                <div class="col-md-6"></div>
                <div class="col-md-2">
                    <label>Total Compra</label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txttotal" ReadOnly="true" CssClass="form-control pull-right" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btningresar" OnClick="btningresar_Click" CssClass="btn btn-warning pull-right" runat="server" Text="Ingresar" />
                </div>
            </div>
            
        </asp:View>

        <%--<asp:View ID="VistaBotones" runat="server">
            <label class="texto">Linea Blanca</label>
            <asp:ImageButton ID="ImgbtnFerrateria" OnClick="ImgbtnFerrateria_Click" CssClass="btni" ToolTip="Linea Blanca" ImageUrl="~/Imagenes/Iconos/page2-img2.png" runat="server" />

            <label class="texto">Muebles</label>
            <asp:ImageButton ID="ImgbtnElectrodomesticos" OnClick="ImgbtnElectrodomesticos_Click" CssClass="btni" ToolTip="Muebles" ImageUrl="~/Imagenes/Iconos/page2-img5.png" runat="server" />

            <label class="texto">Material de Construccion</label>
            <asp:ImageButton ID="imgmat" OnClick="imgmat_Click" CssClass="btni" ToolTip="Material Ferretro" ImageUrl="~/Imagenes/Iconos/page2-img3.png" runat="server" />

            <div class="col-md-12">
                <div class="col-md-5"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnAtraBotones" CssClass="btn btn-info" OnClick="btnAtraBotones_Click" runat="server" Text="Atras" />
                </div>
                <div class="col-md-5"></div>
            </div>
        </asp:View>--%>

        <asp:View ID="VistaLineaBlanca" runat="server">
            <div class="container">
            <center><h1>Artículos & Electrodomésticos</h1></center>

            <asp:Button ID="btnatrasln" OnClick="btnatrasln_Click" CssClass="btn btn-info pull-right" runat="server" Text="Regresar" />
            <div class="row">
            <div class="col-md-12">
                <br />
                    <asp:GridView ID="GvlineaBlanca" AutoGenerateColumns="false" CssClass="table table-bordered"
                        OnRowCommand="GvlineaBlanca_RowCommand" OnDataBound="GvlineaBlanca_DataBound" AllowPaging="true" PageSize="7" DataKeyNames="ID_Articulo" runat="server">
                        <HeaderStyle BackColor="#6c9ed7" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="img" CommandName="estelinea" Height="50px" ImageUrl="~/Imagenes/Iconos/check.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre_Articulo" HeaderText="Nombre" />
                            <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" />
                        </Columns>
                        <PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-1" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblPaginaMedidas" runat="server" Text="Página: " CssClass="label label-info"></asp:Label>
                                    </h3>
                                </div>
                                <div class="col-lg-1" style="text-align: right;">
                                    <br />
                                    <asp:DropDownList ID="DropArto" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropArto_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-lg-2" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label>

                                    </h3>
                                </div>
                                <div class="col-lg-4"></div>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
                </div>
                </div>
        </asp:View>

        <asp:View ID="VistaMuebles" runat="server">
            <br />
            <center><h1>Electrodomésticos</h1></center>
            <hr />
            <asp:GridView ID="GvMuebles" AutoGenerateColumns="false" Width="60%" OnRowCommand="GvMuebles_RowCommand" DataKeyNames="ID_Articulo"
                runat="server" CssClass="table table-bordered">
                <HeaderStyle BackColor="YellowGreen" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="Imagebtnfoto" CommandName="mueble" Height="38px" ImageUrl="~/Imagenes/Iconos/check.png" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre_Articulo" HeaderText="Nombre" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnatraselec" OnClick="btnatraselec_Click" CssClass="btn btn-info" runat="server" Text="Regresar" />
        </asp:View>

        <%--<asp:View ID="VistaProveedor" runat="server">
            <asp:GridView ID="GvProveedor" AutoGenerateColumns="false" Width="60%" CssClass="table table-bordered" OnRowCommand="GvProveedor_RowCommand" DataKeyNames="ID_Proveedor" runat="server">
                <HeaderStyle BackColor="YellowGreen" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" CommandName="esteprov" Height="38px" ImageUrl="~/Imagenes/Iconos/check.png" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre_Proveedor" HeaderText="Proveedor" />
                </Columns>
            </asp:GridView>
        </asp:View>--%>

        <asp:View ID="VistaContruccion" runat="server">
            <asp:GridView ID="GvContruccion" AutoGenerateColumns="false" OnRowCommand="GvContruccion_RowCommand" Width="60%"
                DataKeyNames="ID_Articulo" CssClass="table table-bordered" runat="server">
                <HeaderStyle BackColor="YellowGreen" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" CommandName="extecontr" ImageUrl="~/Imagenes/Iconos/check.png" Height="38px" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre_Articulo" HeaderText="Nombre" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnatrascon" OnClick="btnatrascon_Click" CssClass="btn btn-info" runat="server" Text="Regresar" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
