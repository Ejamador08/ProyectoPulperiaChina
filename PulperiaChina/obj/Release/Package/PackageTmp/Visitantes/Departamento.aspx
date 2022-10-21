<%@ Page Title="Departamentos" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="PulperiaChina.Visitantes.Departamento" %>

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
                    <h1>Los mejores Electrodomésticos</h1>
                </div>
            </div>
            <div class="item">
                <img src="../Imagenes/Slider/PulperiaBanner01.jpg" alt="..." />
                <div class="carousel-caption">
                    <h1>El material Ferreteros que necesite</h1>
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

    <asp:MultiView ID="MultiViewDepartamento" runat="server">

        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Departamentos Almacenados</h1></center>
                        <%--<a href="/Departamento" class="btn btn-success">Agregar Departamento <span class="glyphicon glyphicon-plus-sign"></span></a>--%>
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btninactivos" OnClick="btninactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Departamentos Inactivos" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Departamento" />
                        </div>
                        <%--<hr />--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscar" placeholder="Ingresa el Departamento que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnBuscar" ValidationGroup="agregar" OnClick="btnBuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Bold="true" ControlToValidate="txtBuscar" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <br />
                                <hr />
                                <asp:Literal ID="Literaleliminar" runat="server"></asp:Literal>
                                <asp:GridView ID="GridViewDepartamento" AllowPaging="true" PageSize="5" OnDataBound="GridViewDepartamento_DataBound"
                                    OnRowCommand="GridViewDepartamento_RowCommand" CssClass="table table-bordered" DataKeyNames="ID_Departamento" AutoGenerateColumns="false" runat="server">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Código" DataField="ID_Departamento" />--%>
                                        <asp:BoundField HeaderText="Departamento" DataField="Nombre_Depto" />
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="cmdEditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dar de Baja">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEliminar" CommandName="cmdEliminar" CssClass="btn btn-danger" runat="server" Text="Dar de Baja" />
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
                                                <asp:DropDownList ID="DropDepto" Width="70px" CssClass="form-control" OnSelectedIndexChanged="DropDepto_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label></h3>
                                                </h3>
                                            </div>
                                            <div class="col-lg-4"></div>
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                           <%-- </ContentTemplate>
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
        </asp:View>

        <asp:View ID="VistaEdicion" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <center><h1 class="text-success" style="font-size:50px;">Nuevo Departamento</h1></center>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnLista" OnClick="btnLista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Departamentos" />
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
                                <div class="col-md-2"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <%--<label>Código</label>--%>
                                        <asp:TextBox ID="txtCodigo" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre" runat="server" ErrorMessage="Se Necesita El Nombre" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombre" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="* El Nombre Es Necesario" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Estado</label><br />
                                        <asp:CheckBox ID="CheckEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <br />
                                <hr />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-3"></div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar Departamento" ValidationGroup="Guardar" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar Departamento" Visible="false" Enabled="false" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncancelar" OnClick="btncancelar_Click" CssClass="btn btn-danger" Visible="false" runat="server" Text="Cancelar" />
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
        </asp:View>

        <asp:View ID="VistaInactivos" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
            <center><h1 class="text-success" style="font-size:50px;">Departamentos Dados de Baja</h1></center>
                        <%--<div class="col-md-12">--%>
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Departamentos Activos" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Departamento" />
                            </div>
                        <%--</div>--%>
                        <%--<asp:UpdatePanel ID="unico" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbuscainactivos" CssClass="form-control" PlaceHolder="Ingrese el Departamento que desea Buscar" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnbuscainactivos" ValidationGroup="agregar" CssClass="btn btn-warning" OnClick="btnbuscainactivos_Click" runat="server" Text="Buscar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ControlToValidate="txtbuscainactivos" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <asp:GridView ID="GVInactivos" OnRowCommand="GVInactivos_RowCommand" OnDataBound="GVInactivos_DataBound" AllowPaging="true" PageSize="5" DataKeyNames="ID_Departamento" AutoGenerateColumns="false" CssClass="table table-bordered" runat="server">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Departamento" DataField="Nombre_Depto" />
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
                                                        ¿Desea Eliminar El Departamento "<%#Eval("Nombre_Depto") %>"?
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
                                                <asp:DropDownList ID="DropInactivos" Width="70px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DropInactivos_SelectedIndexChanged" runat="server"></asp:DropDownList>
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
                           <%-- </ContentTemplate>
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
        </asp:View>
    </asp:MultiView>
    <hr />
    <br />
</asp:Content>
