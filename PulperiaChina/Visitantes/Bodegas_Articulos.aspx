<%@ Page Title="Bodega-Artículo" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Bodegas_Articulos.aspx.cs" Inherits="PulperiaChina.Visitantes.Bodegas_Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
    <style type="text/css">
        .panel {
            background-color:azure;
        }

        .a {
            margin-left:40%;
        }

    </style>
    <%-----Banner-----%>
    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="../Imagenes/Slider/PulperiaBanner.jpg" alt="..." />
                <div class="carousel-caption">
                    <h1>Los Mejores Electrodomésticos</h1>
                </div>
            </div>
            <div class="item">
                <img src="../Imagenes/Slider/PulperiaBanner01.jpg" alt="..." />
                <div class="carousel-caption">
                    <h1>El Material Ferretero que Necesite</h1>
                </div>
            </div>
            <div class="item">
                <img src="../Imagenes/Slider/PulperiaBanner02.jpg" alt="..." />
                <div class="carousel-caption">
                    <h1>Pulperia China, A Su Servicio Siempre</h1>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Anterior</span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Siguiente</span>
        </a>
    </div>
    <%-----Banner-----%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:MultiView ID="MultiViewBodegaArticulo" runat="server">
        
        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                <div class="col-md-12">
                    <center><h1 class="text-success">Bodegas-Artículos Almacenados</h1></center>
                    <%--<a href="/Bodegas_Articulos" class=""> <span class="glyphicon glyphicon-plus-sign"></span></a>--%>
                    <asp:Button ID="btnagregarnuevo" CssClass="btn btn-success pull-right" OnClick="btnagregarnuevo_Click" runat="server" Text="Agregar Bodega-Artículo" />
                    <div class="col-md-12">
                        <br />
                        <br />
                        <div class="input-group">
                            <asp:TextBox ID="txtbuscar" placeHolder="Ingresa el Artículo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                            </span>
                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                    <hr />
                    <asp:Literal ID="LiteralEliminar" runat="server"></asp:Literal>
                    <asp:GridView ID="GridViewBodegaArticulo" OnRowCommand="GridViewBodegaArticulo_RowCommand" OnDataBound="GridViewBodegaArticulo_DataBound"
                        runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" DataKeyNames="ID_BodegaArticulo">
                        <HeaderStyle BackColor="#6c9ed7" />
                        <Columns>
                            <%--<asp:BoundField HeaderText="Codigo" DataField="ID_BodegaArticulo" />--%>
                            <asp:BoundField HeaderText="Artículo" DataField="NombreArticulo" />
                            <asp:BoundField HeaderText="Bodega" DataField="NombreBodega" />
                            <asp:BoundField HeaderText="Precio Compra" DataField="Precio_Compra" />
                            <asp:BoundField HeaderText="Precio Venta" DataField="Precion_Venta" />
                            <asp:BoundField HeaderText="Existencia" DataField="Existencia" />
                            <%--<asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" CommandName="cmdeditar" runat="server" CssClass="btn btn-info" Text="Editar" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminar" CommandName="cmdeliminar" OnClientClick="return confirm('Esta Seguro de Eliminar la Bodega');" CssClass="btn btn-danger" runat="server" Text="Eliminar" />

                                    <ajaxToolkit:ConfirmButtonExtender ID="cbeeliminar" DisplayModalPopupID="mpe" TargetControlID="btnEliminar" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Pnppopup" TargetControlID="btnEliminar" 
                                        OkControlID="btnsi" CancelControlID="btnno" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
                                    <asp:Panel ID="Pnppopup" CssClass="panel panel-green" Style="display: none" runat="server">
                                        <div class="modal-header">
                                            ¿Desea Eliminar El Artículo "<%#Eval ("NombreArticulo") %>"?
                                        </div>
                                        <div class="panel-body">
                                            <asp:Button ID="btnsi" runat="server" Text="Si" CssClass="a btn btn-danger" />
                                            <asp:Button ID="btnno" runat="server" Text="No" CssClass="b btn btn-info" />
                                        </div>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-1" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblmedida" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                                    </h3>
                                </div>
                                <div class="col-lg-1" style="text-align: left;">
                                    <br />
                                    <asp:DropDownList ID="Dropbodeart" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="Dropbodeart_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-lg-2" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblborart" runat="server" CssClass="label label-warning"></asp:Label>
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

        <asp:View ID="VistaEdicion" runat="server">
            <div class="col-md-12">
                <div class="col-md-8">
                    <center><h1 class="text-success">Nueva Bodega-Artículo</h1></center>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:Button ID="btnLista" OnClick="btnLista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Bodegas-Articulos" />
                </div>
            </div>
            <div class="col-md-12">
                <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <%--<label>Código</label>--%>
                        <asp:TextBox ID="txtcodigo" Visible="false" Enabled="false" CssClass="form-control" runat="server" ToolTip="Codigo Autonumerico"></asp:TextBox>
                    </div>
                    <br />
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Artículo</label>
                            <%--<asp:DropDownList ID="DropArticulo" runat="server" CssClass="form-control"></asp:DropDownList>--%>
                            <div class="col-md-12">
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtart" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncargaart" Font-Bold="true" OnClick="btncargaart_Click" Height="29px" Width="40px" CssClass="btn btn-success" runat="server" Text="..." />
                                </div>
                            </div>
                            <asp:HiddenField ID="Hiddenarticulo" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Bodega</label>
                            <%--<asp:DropDownList ID="DropBodega" runat="server" CssClass="form-control"></asp:DropDownList>--%>
                            <div class="col-md-12">
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtbod" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncargabid" Font-Bold="true" OnClick="btncargabid_Click" Height="29px" Width="40px" CssClass="btn btn-success" runat="server" Text="..." />
                                </div>
                            </div>
                            <asp:HiddenField ID="HiddenBodega" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <%--<label>Precio Compra</label>--%>
                        <asp:TextBox ID="txtcompra" Visible="false" Width="50%" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <%--<label>Precio Venta</label>--%>
                        <asp:TextBox ID="txtventa" Visible="false" runat="server" Width="50%" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <%--<label>Existencia</label>--%>
                        <asp:TextBox ID="txtexistencia" Visible="false" runat="server" Width="50%" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-3"></div>
                    <div class="col-md-3">
                        <br />
                        <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guarda Bodega-Artículo" />
                    </div>
                    <div class="col-md-3">
                        <br />
                        <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" Visible="false" CssClass="btn btn-default" runat="server" Text="Actualiza Bodega-Articulo" />
                    </div>
                    <div class="col-md-3">
                        <br />
                        <asp:Button ID="btncancactu" OnClick="btncancactu_Click" CssClass="btn btn-danger" Visible="false" runat="server" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="VistaArticulo" runat="server">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:TextBox ID="txtbuscaart" placeHolder="Ingresa el Articulo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnbuscarart" OnClick="btnbuscarart_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                        </span>
                    </div>
                </div>

                <center><h1>Lista de los Artículos</h1></center>

                <asp:GridView ID="GridArticulos" OnRowCommand="GridArticulos_RowCommand" Width="80%" DataKeyNames="ID_Articulo" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="5" runat="server" OnDataBound="GridArticulos_DataBound" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" AutoPostBack="false" CommandName="seleccionar"
                                    Height="38px" runat="server" ImageUrl="~/Imagenes/Iconos/check.png" ToolTip="seleccionar" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Artículo" DataField="Nombre_Articulo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <%--<FooterStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />--%>
                    <HeaderStyle BackColor="#00a600" ForeColor="White" Height="25px" Font-Bold="True" HorizontalAlign="Center" />
                    <%--Color De Arriba de la grid Verdfe--%>
                    <PagerStyle ForeColor="White"
                        HorizontalAlign="Center" BackColor="#006c00" />
                    <%--Color De abago de la grid  la paginaCION--%>
                    <RowStyle BackColor="#E3EAEB" BorderColor="Black" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    <PagerTemplate>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-lg-2" style="text-align: right;">
                                <h5>
                                    <asp:Label ID="lblmedia" Text="Pagina:" CssClass="label label-info" runat="server"></asp:Label>
                                </h5>
                            </div>
                            <div class="col-lg-2" style="text-align: right;">
                                <asp:DropDownList ID="Droparticulos" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="Droparticulos_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-8" style="text-align: right;">
                                <h3>
                                    <asp:Label ID="lblfin" CssClass="label label-warning" runat="server" Text="Label"></asp:Label>
                                </h3>
                            </div>
                        </div>

                    </PagerTemplate>
                </asp:GridView>
                <asp:Button ID="btnCancel" CssClass="btn btn-danger pull-right" OnClick="btnCancel_Click" runat="server" Text="Cancelar" Height="40px" Width="120px" />
            </div>
            <div class="col-md-2"></div>
        </asp:View>
        <asp:View ID="VistaBodega" runat="server">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:TextBox ID="txtbodega" placeHolder="Ingresa la Bodega que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnbuscabod" OnClick="btnbuscabod_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                        </span>
                    </div>
                </div>

                <center><h1>Lista de las Bodegas</h1></center>

                <asp:GridView ID="GridBodega" OnRowCommand="GridBodega_RowCommand" OnDataBound="GridBodega_DataBound" HorizontalAlign="Center"
                    runat="server" Width="50%" DataKeyNames="ID_Bodega" AutoGenerateColumns="false" AllowPaging="true" PageSize="5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" AutoPostBack="false" CommandName="seleccionar"
                                    Height="38px" ImageUrl="~/Imagenes/Iconos/check.png" ToolTip="seleccionar" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Bodega" DataField="Nombre_Bodega">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />
                    <HeaderStyle BackColor="#00a600" ForeColor="White" Height="25px" Font-Bold="True" HorizontalAlign="Center" />
                    <%--Color De Arriba de la grid Verdfe--%>
                    <PagerStyle ForeColor="White"
                        HorizontalAlign="Center" BackColor="#006c00" />
                    <%--Color De abago de la grid  la paginaCION--%>
                    <RowStyle BackColor="#E3EAEB" BorderColor="Black" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    <PagerTemplate>
                        <div class="row" style="margin-top: 20px;">
                            <div class="col-lg-1" style="text-align: right;">
                                <h5>
                                    <asp:Label ID="lblmedia" Text="Pagina:" CssClass="label label-info" runat="server"></asp:Label>
                                </h5>
                            </div>
                            <div class="col-lg-1" style="text-align: right;">
                                <asp:DropDownList ID="DropBodegas" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropBodegas_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-10" style="text-align: right;">
                                <h3>
                                    <asp:Label ID="lblfinal" CssClass="label label-warning" runat="server" Text="Label"></asp:Label>
                                </h3>
                            </div>
                        </div>
                    </PagerTemplate>
                </asp:GridView>
                <asp:Button ID="btncancelar" OnClick="btncancelar_Click" CssClass="btn btn-danger pull-right" runat="server" Text="Cancelar" />
            </div>
            <div class="col-md-2"></div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
