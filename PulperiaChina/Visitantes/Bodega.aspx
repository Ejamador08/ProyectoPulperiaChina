<%@ Page Title="Bodegas" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Bodega.aspx.cs" Inherits="PulperiaChina.Visitantes.Bodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
    <%-----Banner-----%>
    <%--<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
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
    </div>--%>
    <%-----Banner-----%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:MultiView ID="MultiViewBodega" runat="server">

        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Bodegas Almacenadas</h1></center>
                        <%--<a href="/Bodega" class="btn btn-success">Agregar Bodega <span class="glyphicon glyphicon-plus-sign"></span></a>--%>
                        <div class="col-md-12">
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btninactivos" OnClick="btninactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Bodegas Inactivas" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" class="btn btn-success pull-right" runat="server" Text="Agregar Bodega" />
                            </div>
                        </div>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtbuscar" placeHolder="Ingresa la Bodega que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnbuscar" OnClick="btnbuscar_Click" CssClass="btn btn-warning" runat="server" ValidationGroup="agregar" Text="Buscar" />
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ControlToValidate="txtbuscar" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>
                        <br />
                        <hr />
                        <asp:Literal ID="LiteralEliminar" runat="server"></asp:Literal>
                        <asp:GridView ID="GridViewBodegas" OnRowCommand="GridViewBodegas_RowCommand" AllowPaging="true" PageSize="5" OnDataBound="GridViewBodegas_DataBound" CssClass="table table-bordered"
                            runat="server" AutoGenerateColumns="false" DataKeyNames="ID_Bodega">
                            <HeaderStyle BackColor="#6c9ed7" />
                            <Columns>
                                <%--<asp:BoundField HeaderText="Código" DataField="ID_Bodega" />--%>
                                <asp:BoundField HeaderText="Bodega" DataField="Nombre_Bodega" />
                                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditar" CommandName="cmdeditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dar de baja">
                                    <ItemTemplate>
                                        <%--OnClientClick="return confirm('Esta Seguro de Eliminar la Bodega');"--%>
                                        <asp:Button ID="btnEliminar" CommandName="cmdeliminar" CssClass="btn btn-danger" runat="server" Text="Dar de Baja" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-1" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="lblinicio" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-1" style="text-align: left;">
                                        <br />
                                        <asp:DropDownList ID="DropBodega" Width="70px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DropBodega_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="lblfin" CssClass="label label-warning" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-4"></div>
                            </PagerTemplate>
                        </asp:GridView>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:View>

        <asp:View ID="VistaEdicion" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <center><h1 class="text-success" style="font-size:50px;">Nueva Bodega</h1></center>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnlista" OnClick="btnlista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Bodegas" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <hr />
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <%--<label>Código</label>--%>
                                        <asp:TextBox ID="txtcodigo" Visible="false" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ValidationGroup="Guardar" ErrorMessage="* El nombre es necesario"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Descripción</label>
                                        <asp:TextBox ID="txtdescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Estado</label>
                                        <br />
                                        <asp:CheckBox ID="CheckEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <br />
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar Bodega" ValidationGroup="Guardar" />
                                </div>
                                <div class="col-md-2">
                                    <br />
                                    <asp:Button ID="btnActualizar" Visible="false" OnClick="btnActualizar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar Bodega" />
                                </div>
                                <div class="col-md-2">
                                    <br />
                                    <asp:Button ID="btncancact" Visible="false" OnClick="btncancact_Click" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <hr />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:View>

        <asp:View ID="VistaInactivos" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Bodegas Dadas de Baja</h1></center>
                        <%--<div class="col-md-12">--%>
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Bodegas Activos" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Bodega" />
                        </div>
                        <%--</div>--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtbuscainactivos" CssClass="form-control" PlaceHolder="Ingrese la Bodega que desea Buscar" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnbuscainactivos" OnClick="btnbuscainactivos_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" ValidationGroup="agregar" />
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Bold="true" ControlToValidate="txtbuscainactivos" ValidationGroup="agregar" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>

                        <asp:GridView ID="GVInactivos" OnRowCommand="GVInactivos_RowCommand" OnDataBound="GVInactivos_DataBound" AutoGenerateColumns="false" CssClass="table table-bordered"
                            DataKeyNames="ID_Bodega" AllowPaging="true" PageSize="5" runat="server">
                            <HeaderStyle BackColor="#6c9ed7" />
                            <Columns>
                                <asp:BoundField HeaderText="Bodega" DataField="Nombre_Bodega" />
                                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                                <asp:TemplateField HeaderText="Restaurar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnrestaurar" CommandName="cmdrestaurar" CssClass="btn btn-info" runat="server" Text="Restaurar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnexterminar" CommandName="cmdexterminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" />

                                        <ajaxToolkit:ConfirmButtonExtender ID="cbeeliminar" DisplayModalPopupID="mpe" TargetControlID="btnexterminar" runat="server" />
                                        <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Pnppopup" TargetControlID="btnexterminar"
                                            OkControlID="btnsi" CancelControlID="btnno" BackgroundCssClass="modalBackground" runat="server">
                                        </ajaxToolkit:ModalPopupExtender>
                                        <asp:Panel ID="Pnppopup" CssClass="panel" Style="display: none" runat="server">
                                            <div class="modal-header">
                                                ¿Desea Eliminar La Bodega "<%#Eval("Nombre_Bodega") %>"?
                                            </div>
                                            <div class="panel-body">
                                                <asp:Button ID="btnsi" runat="server" Text="Si" CssClass="btn btn-danger" />
                                                <asp:Button ID="btnno" runat="server" Text="No" CssClass="btn btn-info" />
                                            </div>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-1">
                                        <h3>
                                            <asp:Label ID="lblinicioinac" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:DropDownList ID="DropInactivos" CssClass="form-control" AutoPostBack="true" Width="70px" OnSelectedIndexChanged="DropInactivos_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2">
                                        <h3>
                                            <asp:Label ID="lblfininactivos" CssClass="label label-warning" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="col-lg-4"></div>
                            </PagerTemplate>
                        </asp:GridView>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:View>
    </asp:MultiView>
</asp:Content>
