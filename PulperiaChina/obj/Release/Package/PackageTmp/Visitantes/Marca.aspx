<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="PulperiaChina.Visitantes.Marca" %>

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

    <asp:MultiView ID="MultiViewMarca" runat="server">

        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Marcas Almacenadas</h1></center>
                        <%--<a href="/Marca" class="btn btn-success">Agregar Marca <span class="glyphicon glyphicon-plus-sign"></span></a>--%>
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btninactivos" OnClick="btninactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Marcas Inactivas" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Marca" />
                        </div>
                        <%--<asp:UpdatePanel ID="prim" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbuscar" placeHolder="Ingresa la Marca que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnbuscar" ValidationGroup="agregar" OnClick="btnbuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Bold="true" ControlToValidate="txtbuscar" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <br />
                                <hr />
                                <asp:Literal ID="LiteralEliminar" runat="server"></asp:Literal>
                                <asp:GridView ID="GridViewMarca" AllowPaging="true" PageSize="5" OnDataBound="GridViewMarca_DataBound" OnRowCommand="GridViewMarca_RowCommand" CssClass="table table-bordered"
                                    runat="server" AutoGenerateColumns="false" DataKeyNames="IDMarca">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Código" DataField="IDMarca" />--%>
                                        <asp:BoundField HeaderText="Marca" DataField="Nombre_Marca" />
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="cmdeditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dar de Baja">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEliminar" CommandName="cmdeliminar" CssClass="btn btn-danger" runat="server" Text="Dar de Baja" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-lg-4"></div>
                                            <div class="col-lg-1" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="lblPaginaMedidas" runat="server" Text="Página:" CssClass="label label-info"></asp:Label>
                                                </h3>
                                            </div>
                                            <div class="col-lg-1" style="text-align: left;">
                                                <br />
                                                <asp:DropDownList ID="DropMArca" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropMArca_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </br>
                                            </div>
                                            <div class="col-lg-2" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label></h3>
                                                </h3>
                                            </div>
                                                <div class="col-lg-2"></div>
                                            </div>
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

        <asp:View ID="ViEdicion" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <center><h1 class="text-success" style="font-size:50px;">Nueva Marca</h1></center>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnLista" OnClick="btnLista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Marcas" />
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <%--<label>Código</label>--%>
                                        <asp:TextBox ID="txtcodigo" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Nombre Requerido" ControlToValidate="txtnombre" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Estado</label>
                                        <br />
                                        <asp:CheckBox ID="CheckEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-5"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-3"></div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" Text="Guardar Marca" ValidationGroup="guardar" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnActualizar" Visible="false" CssClass="btn btn-warning" OnClick="btnActualizar_Click" runat="server" Text="Actualizar Marca" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncancelar" OnClick="btncancelar_Click" Visible="false" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                </div>
                                <div class="col-md-3"></div>
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
                        <center><h1 class="text-success" style="font-size:50px;">Marcas Dadas de Baja</h1></center>
                        <%--<div class="col-md-12">--%>
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Marcas Activas" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Marca" />
                            </div>
                        <%--</div>--%>
                        <%--<asp:UpdatePanel ID="seg" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbuscainactivos" CssClass="form-control" PlaceHolder="Ingrese la Marca que desee Buscar" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnbuscainactivos" ValidationGroup="agregar" OnClick="btnbuscainactivos_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ControlToValidate="txtbuscainactivos" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <asp:GridView ID="GVInactivos" OnDataBound="GVInactivos_DataBound" OnRowCommand="GVInactivos_RowCommand" DataKeyNames="IDMarca" AllowPaging="true" AutoGenerateColumns="false" PageSize="5" CssClass="table table-bordered" runat="server">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Marca" DataField="Nombre_Marca" />
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
                                                        ¿Desea Eliminar La Marca "<%#Eval("Nombre_Marca") %>"?
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
                                                <asp:DropDownList ID="DropInactivos" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropInactivos_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <h3>
                                                    <asp:Label ID="lblfininactivos" CssClass="label label-warning" runat="server"></asp:Label>
                                                </h3>
                                            </div>
                                            <div class="col-lg-4"></div>
                                        </div>
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
    </asp:MultiView>
</asp:Content>
