<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="PulperiaChina.Visitantes.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.js"></script>
    <script>
        $(function () {
            $('#<%=FileUploadUsuario.ClientID%>').on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div

                        $('#<%=Imageuser.ClientID%>').attr('src', this.result);
                    }
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
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
    <asp:MultiView ID="MultiViewUsuario" runat="server">
        <asp:View ID="VistaLista" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <center><h1 class="text-success">Usuarios Almacenados</h1></center>
                        <a href="/Registro" class="btn btn-success pull-right">Agregar Usuario <%--<span class="glyphicon glyphicon-plus-sign"></span>--%></a>
                        <%--<hr />--%>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <div class="input-group">
                                <asp:TextBox ID="txtbuscar" placeHolder="Ingresa el Usuario que desea Buscar" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnbuscar" OnClick="btnbuscar_Click" CssClass="btn btn-warning" runat="server" Text="Buscar" />
                                </span>
                            </div>
                            <br />
                            <br />
                        </div>
                        <br />
                        <hr />
                        <asp:Literal ID="LiteralEliminar" runat="server"></asp:Literal>
                        <asp:GridView ID="GridViewUsuario" OnRowCommand="GridViewUsuario_RowCommand" CssClass="table table-bordered" OnDataBound="GridViewUsuario_DataBound"
                            runat="server" DataKeyNames="ID_Usuario" AutoGenerateColumns="false" AllowPaging="true" PageSize="5">
                            <HeaderStyle BackColor="#6c9ed7" />
                            <Columns>
                                <asp:BoundField HeaderText="Codigo" DataField="ID_Usuario" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre_User" />
                                <asp:BoundField HeaderText="Apellido Paterno" DataField="Apellido1_User" />
                                <asp:BoundField HeaderText="Contraseña" DataField="Apellido2_User" />
                                <asp:BoundField HeaderText="Tipo Usuario" DataField="Tipo_Usuario" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditar" CommandName="cmdeditar" CssClass="btn btn-info" runat="server" Text="Editar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminar" CommandName="cmdeliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" />
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
                                    <div class="col-lg-1" style="text-align: right;">
                                        <br />
                                        <asp:DropDownList ID="dropuserpage" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="dropuserpage_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
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
                    <center><h1 class="text-success">Nuevo Usuario</h1></center>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:Button ID="btnLista" OnClick="btnLista_Click" CssClass="btn btn-success pull-right" runat="server" Text="Ver Usuario" />
                </div>
            </div>
            <div class="col-md-12">
                <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
            </div>
            <hr />
            <div class="col-md-6">
                <div class="form-group">
                    <label>Código</label>
                    <asp:TextBox ID="txtcodigo" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Apellido Paterno</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtapellido02" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>UserName</label>
                    <asp:TextBox ID="txtuser" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Tipo De Usuario</label>
                    <asp:DropDownList ID="Droptipouser" CssClass="form-control" runat="server" Font-Bold="true" Height="30px" Style="margin-left: 30px; text-align: center; padding-left: 5px;" TabIndex="5" Width="161px">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Vendedor</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Imagen</label>
                    <asp:Image ID="Imageuser" Width="40%" Height="50%" ImageUrl="~/Imagenes/Usuarios.png" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:FileUpload ID="FileUploadUsuario" runat="server" />
                </div>
            </div>
            <br />
            <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" Visible="false" CssClass="btn btn-warnings" runat="server" Text="Actualizar Usuario" />
            <asp:Button ID="btncancelar" OnClick="btncancelar_Click" Visible="false" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
            <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return confirm('Enviar datos?');" CssClass="btn btn-primary" runat="server" Text="Guardar Usuario" ValidationGroup="Guardar" />
        </asp:View>
    </asp:MultiView>

</asp:Content>
