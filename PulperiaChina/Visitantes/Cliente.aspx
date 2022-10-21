<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="PulperiaChina.Visitantes.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceSlider" runat="server">

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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:MultiView ID="MultiViewCliente" runat="server">
        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Clientes Almacenados</h1></center>
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnbaja" OnClick="btnbaja_Click" CssClass="btn btn-info pull-right" runat="server" Text="Clientes Inactivos" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Cliente" />
                        </div>
                        <%--<a href="/Cliente" class="btn btn-success">Agregar Cliente <span class="glyphicon glyphicon-plus-sign"></span></a>--%>


                        <%--<hr />--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscar" placeholder="Ingresa el Cliente que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" ValidationGroup="agregar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Font-Bold="true" ControlToValidate="txtBuscar" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <br />
                                <hr />
                                <asp:Literal ID="LiteralElimiar" runat="server"></asp:Literal>
                                <asp:GridView ID="GridViewClientes" AllowPaging="true" PageSize="5" OnDataBound="GridViewClientes_DataBound" OnRowCommand="GridViewClientes_RowCommand" CssClass="table table-bordered" DataKeyNames="ID_cliente" AutoGenerateColumns="false" runat="server">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Código" DataField="ID_Cliente" />--%>
                                        <asp:BoundField HeaderText="Cliente" DataField="Nombre_Cliente" />
                                        <asp:BoundField HeaderText="Apellido" DataField="Apellido1_Cliente" />
                                        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                                        <asp:BoundField HeaderText="Nº Cédula" DataField="N__de_Cedula" />
                                        <asp:BoundField HeaderText="Municipio" DataField="NombreMunicipio" />
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
                                                <asp:DropDownList ID="DropCli" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropCli_SelectedIndexChanged" runat="server"></asp:DropDownList>
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
        </asp:View>

        <asp:View ID="VistaEdicion" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <center><h1 class="text-success" style="font-size:50px;">Nuevo Cliente</h1></center>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnLista" OnClick="btnLista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Clientes" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
                            <asp:Literal ID="LiteralActualiza" runat="server"></asp:Literal>
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
                                        <asp:TextBox ID="txtCodigo" Visible="false" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNombre" runat="server" ErrorMessage="Solo se Permiten Letras" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" CssClass="Validation" runat="server" ControlToValidate="txtNombre" ErrorMessage="* El Nombre Es Necesario" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Apellido Paterno</label>
                                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtApellido" runat="server" ErrorMessage="Solo se Permiten Letras" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" CssClass="Validation" runat="server" ControlToValidate="txtApellido" ErrorMessage="* El Apellido Es Necesario" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Dirección</label>
                                        <asp:TextBox ID="txtDireccion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDireccion" runat="server" ErrorMessage="Solo se permiten Letras" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" CssClass="Validation" runat="server" ControlToValidate="txtDireccion" ErrorMessage="* La Direccion Es Necesario" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar Cliente" ValidationGroup="Guardar" />
                                    <br />
                                    <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar Cliente" Enabled="false" Visible="false" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Nº De Cédula</label>
                                        <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtCedula" runat="server" ErrorMessage="Formato: 000-000000-0002D" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="\d{3}-\d{6}-\d{4}\w" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="Validation" runat="server" ControlToValidate="txtCedula" ErrorMessage="* Se necesita la cédula" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtCedula" Mask="999-999999-9999A" InputDirection="RightToLeft" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Teléfono</label>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtTelefono" runat="server" ErrorMessage="Solo se permiten Numeros" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="(\d{3})-\d{4}-\d{4}" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" CssClass="Validation" runat="server" ControlToValidate="txtTelefono" ErrorMessage="* ingrese Un Numero telefonico" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="txtTelefono" Mask="(+505) 9999-9999" InputDirection="RightToLeft" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Municipio</label>
                                        <asp:DropDownList ID="DropMunicipio" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btncancelar" OnClick="btncancelar_Click" CssClass="btn btn-danger" Visible="false" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>UserName</label>
                                        <asp:TextBox ID="txtUser" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtUser" runat="server" ErrorMessage="Es Necesario" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtUser" Display="Dynamic" CssClass="Validation" runat="server" ErrorMessage="Lo Necesitamos" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>E-Mail</label>
                                        <asp:TextBox ID="txtmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Estado</label><br />
                                        <asp:CheckBox ID="chkEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="VistaDadosdeBajas" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Clientes Dados de Baja</h1></center>
                        <%--<div class="col-md-12">--%>
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Clientes Activos" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success pull-right" runat="server" Text="Agregar Cliente" />
                            </div>
                        <%--</div>--%>
                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbuscainactivos" CssClass="form-control" PlaceHolder="Ingresa el Cliente que desea Buscar" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnbuscainactivos" ValidationGroup="agregar" OnClick="btnbuscainactivos_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtbuscainactivos" Font-Bold="true" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>

                                <asp:GridView ID="GVInactivos" CssClass="table table-bordered" DataKeyNames="ID_cliente" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" OnDataBound="GVInactivos_DataBound" OnRowCommand="GVInactivos_RowCommand" runat="server">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Cliente" DataField="Nombre_Cliente" />
                                        <asp:BoundField HeaderText="Apellido" DataField="Apellido1_Cliente" />
                                        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                                        <asp:BoundField HeaderText="Nº Cédula" DataField="N__de_Cedula" />
                                        <asp:BoundField HeaderText="Municipio" DataField="NombreMunicipio" />
                                        <asp:TemplateField HeaderText="Restaurar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnRestaurar" CommandName="cmdRestaurar" runat="server" CssClass="btn btn-info" Text="Restaurar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnexterminar" CommandName="cmdexterminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" />

                                                <ajaxToolkit:ConfirmButtonExtender ID="cbeeliminar" DisplayModalPopupID="mpe" TargetControlID="btnexterminar" runat="server" />
                                                <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="Pnppopup" TargetControlID="btnexterminar"
                                                    OkControlID="btnsi" CancelControlID="btnno" BackgroundCssClass="modalBackground" runat="server">
                                                </ajaxToolkit:ModalPopupExtender>
                                                <asp:Panel ID="Pnppopup" CssClass="panel" Style="display: none" runat="server">
                                                    <div class="modal-header">
                                                        ¿Desea Eliminar El Cliente "<%#Eval("Nombre_Cliente") %>"?
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
                                                <asp:DropDownList ID="dropinactivos" Width="70px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="dropinactivos_SelectedIndexChanged" runat="server"></asp:DropDownList>
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
        </asp:View>

    </asp:MultiView>
    <hr />
    <br />
</asp:Content>
