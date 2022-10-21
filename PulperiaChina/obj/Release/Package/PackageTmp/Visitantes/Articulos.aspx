<%@ Page Title="Artículos" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="PulperiaChina.Visitantes.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/jquery.js"></script>
    <script>
        $(function () {
            $('#<%=FileUploadArticulo.ClientID%>').on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div

                        $('#<%=Preview.ClientID%>').attr('src', this.result);
                    }
                }
            });
        });
    </script>

    <style>
        .abc {
            margin-left: 50%;
        }
    </style>
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:MultiView ID="MultiViewArticulos" runat="server">

        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Artículos Almacenados</h1></center>
                        <%--<a href="/Articulos" class="btn btn-success">Agregar Artículo <span class="glyphicon glyphicon-plus-sign"></span></a>--%>
                        <div class="col-md-8"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btninactivos" OnClick="btninactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Artículos Inactivos" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnnuevo" OnClick="btnnuevo_Click" class="btn btn-success pull-right" runat="server" Text="Agregar Artículo" />
                        </div>

                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-md-12">
                                    <br />
                                    <br />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscar" placeHolder="Ingresa el artículo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" ValidationGroup="agregar" />
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Bold="true" ControlToValidate="txtBuscar" ValidationGroup="agregar" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </div>
                                <br />
                                <hr />
                                <asp:Literal ID="LiteralEliminar" runat="server"></asp:Literal>

                                <asp:GridView ID="GridViewArticulo" OnRowCommand="GridViewArticulo_RowCommand"
                                    CssClass="table table-bordered" AllowPaging="true" OnDataBound="GridViewArticulo_DataBound" PageSize="5"
                                    runat="server" DataKeyNames="ID_Articulo" AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#6c9ed7" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Artículo" DataField="Nombre_Articulo" />
                                        <%--<asp:BoundField HeaderText="Estado" DataField="Estado" />--%>
                                        <asp:BoundField HeaderText="Categoría" DataField="NombreCategoria" />
                                        <asp:BoundField HeaderText="Proveedor" DataField="NombreProveedor" />
                                        <asp:BoundField HeaderText="Marca" DataField="NombreMarca" />
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandName="cmdEditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dar de Baja">
                                            <ItemTemplate>
                                                <%--OnClientClick="return confirm('Esta Seguro de Eliminar el Artículo');"--%>
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
                                                <asp:DropDownList ID="DropArto" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="DropArto_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2" style="text-align: right;">
                                                <h3>
                                                    <asp:Label ID="lblArtoPageOf" CssClass="label label-warning" runat="server"></asp:Label></h3>
                                            </div>
                                            <div class="col-lg-4"></div>
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <%-- ---TERMINAR DE REVISAR LA PARTE DEL LOGIN----CUANDO ESTA Y CUANDO NO ESTA LOGUEADO----CREAR LOS MODAL A CADA BOTON NECESARIO-----%>
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
        </asp:View>

        <asp:View ID="VistaEdicion" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-8">
                                <h1 class="abc text-success" style="font-size:50px;">Nuevo Artículo</h1>
                            </div>
                            <div class="col-md-4">
                                <br />
                                <asp:Button ID="btnIrlista" OnClick="btnIrlista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Artículos" />
                            </div>
                        </div>
                        <hr />
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
                                        <asp:TextBox ID="txtCodigo" CssClass="form-control" Visible="false" Enabled="false" runat="server"></asp:TextBox>
                                        <label>Nombre</label>
                                        <%--onkeypress="return SoloTexto(event)" onsubmit="return Validaciones(this)" ValidationGroup="Guardar"--%>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre" runat="server" ErrorMessage="Solo se Permiten Letras" Font-Bold="True" Font-Italic="True" ForeColor="#CC0000" ValidationExpression="[A-Za-z | ]*" ValidationGroup="Guardar"></asp:RegularExpressionValidator>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Validation" runat="server" ControlToValidate="txtNombre" ErrorMessage="* El Nombre Es Necesario" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Descripción</label>
                                        <asp:TextBox ID="txtdescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Categoría</label>
                                        <asp:DropDownList ID="DropCategoria" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar Artículo" ValidationGroup="Guardar" />
                                    <br />
                                    <asp:Button ID="btnActualizar" Visible="false" OnClick="btnActualizar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar Artículo" />
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
                                        <label>Proveedor</label>
                                        <asp:DropDownList ID="DropProveedor" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Marca</label>
                                        <asp:DropDownList ID="DropMarca" CssClass="selectpicker form-control" Width="100%" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Garantía</label>
                                                <asp:CheckBox ID="CBGarantia" AutoPostBack="true" OnCheckedChanged="CBGarantia_CheckedChanged" runat="server" />
                                                <%--<asp:TextBox ID="txtgarantia" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>--%>
                                                <asp:DropDownList ID="DropGarantia" Enabled="false" CssClass="form-control" runat="server">
                                                    <asp:ListItem> Sin Garantía </asp:ListItem>
                                                    <asp:ListItem>1 Mes</asp:ListItem>
                                                    <asp:ListItem>3 Meses</asp:ListItem>
                                                    <asp:ListItem>6 Meses</asp:ListItem>
                                                    <asp:ListItem>9 Meses</asp:ListItem>
                                                    <asp:ListItem>12 Meses</asp:ListItem>
                                                    <asp:ListItem>18 Meses</asp:ListItem>
                                                    <asp:ListItem>24 Meses</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-2">
                                    <asp:Button ID="btncanactu" OnClick="btncanactu_Click" Visible="false" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-1"></div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Imagen</label>
                                        <br />
                                        <asp:Image ID="Preview" Width="40%" Height="50%" ImageUrl="~/Imagenes/ImagenesArticulos/imgvacia.png" runat="server" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:FileUpload ID="FileUploadArticulo" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Estado</label><br />
                                        <asp:CheckBox ID="chkEstado" Checked="true" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3"></div>
                            </div>
                            <div class="col-md-12">
                                <%--del boton guardar: OnClientClick="return confirm('Enviar datos?');"--%>
                                <div class="col-md-2"></div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnVerCombo" OnClick="btnVerCombo_Click" Visible="false" CssClass="btn btn-warning" runat="server" Text="Ver Combo" Enabled="false" />
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="VistaInactivos" runat="server">
            <div class="container">
                <div class="row">
                    <br />
                    <br />
                    <div class="col-md-12">
                        <center><h1 class="text-success" style="font-size:50px;">Artículos Dados de Baja</h1></center>
                        <%--<div class="col-md-12">--%>
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnactivos" OnClick="btnactivos_Click" CssClass="btn btn-info pull-right" runat="server" Text="Artículos Activos" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnnew" OnClick="btnnew_Click" CssClass="btn btn-success" runat="server" Text="Agregar Artículo" />
                            </div>
                        <%--</div>--%>

                        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtbuscainactivos" placeHolder="Ingresa el artículo que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnbuscainactivos" CssClass="btn btn-warning" OnClick="btnbuscainactivos_Click" runat="server" Text="Buscar" ValidationGroup="agregar" />
                                </span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Bold="true" ControlToValidate="txtbuscainactivos" ValidationGroup="agregar" runat="server" ErrorMessage="* Agregue un dato a la Búsqueda"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>

                        <asp:GridView ID="GvInactivos" OnRowCommand="GvInactivos_RowCommand" OnDataBound="GvInactivos_DataBound" DataKeyNames="ID_Articulo" CssClass="table table-bordered"
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="5" runat="server">
                            <HeaderStyle BackColor="#6c9ed7" />
                            <Columns>
                                <asp:BoundField HeaderText="Artículo" DataField="Nombre_Articulo" />
                                <%--<asp:BoundField HeaderText="Estado" DataField="Estado" />--%>
                                <asp:BoundField HeaderText="Categoría" DataField="NombreCategoria" />
                                <asp:BoundField HeaderText="Proveedor" DataField="NombreProveedor" />
                                <asp:BoundField HeaderText="Marca" DataField="NombreMarca" />
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
                                                ¿Desea Eliminar El Artículo "<%#Eval("Nombre_Articulo") %>"?
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
                                        <asp:DropDownList ID="dropinactivos" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="dropinactivos_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
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
            <br />
        </asp:View>

    </asp:MultiView>

    <%-- <ajaxToolkit:ConfirmButtonExtender ID="confEliminar" DisplayModalPopupID="mpe" TargetControlID="btnEliminar" runat="server" />

    <ajaxToolkit:ModalPopupExtender ID="mpe" PopupControlID="pnlPopUp" TargetControlID="btnEliminar" OkControlID="Si" CancelControlID="No" BackgroundCssClass="modal-backdrop" runat="server">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlPopup" CssClass="modalPopup" Style="display: none;" runat="server">
        <div class="header">
            <h4>Eliminar</h4>
        </div>
        <div>
            ¿Desea Eliminar El Articulo<%#Eval("Nombre_Articulo") %>?
        </div>
        <div>
            <asp:Button ID="Si" runat="server" Text="Si" CssClass="btn btn-info" />
            <asp:Button ID="No" runat="server" Text="No" CssClass="btn btn-warning" />
        </div>
    </asp:Panel>--%>

    <%-----MODAL DEL BOTON ELIMINAR
    <div class="modal fade" id="VentanaEliminar">
        <div class="modal-dialog">
            <div class="modal-content">
                <%----header de la ventana
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Advertencia</h4>
                </div>
                <%-----contenidode la ventana
                <div class="modal-body">
                    <p>Esta Seguro Que desea Eliminar El Articulo</p>
                </div>
                <%----footerde la ventana
                <div class="modal-footer">
                    <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-danger" runat="server" Text="Aceptar" />
                    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-default" runat="server" Text="Cancelar" />
                    <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>-----%>
    <%-----MODAL DEL BOTON ELIMINAR termina-----%>

    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#Preview').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
