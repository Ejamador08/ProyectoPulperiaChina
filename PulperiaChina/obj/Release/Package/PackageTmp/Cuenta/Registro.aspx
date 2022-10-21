<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PulperiaChina.Cuenta.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro De Usuario</title>
    <%--<link href="../Content/bootstrap.css" rel="stylesheet" />--%>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.js"></script>
    <script>
        $(function () {
            $('#<%=FileUpload1.ClientID%>').on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div

                        $('#<%=imguser.ClientID%>').attr('src', this.result);
                    }
                }
            });
        });
    </script>
    <style type="text/css">
        body {
            background-image:url(../Imagenes/Slider/slider01.jpg)
        }

        .login {
            background-color:#a34f9e;
            color:white;
            border-radius:22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div class="row">
        </div>--%>
        <div class="col-md-3"></div>
        <div class="col-md-6 login">
            <center><h3><i class="glyphicon glyphicon-user"></i>Registro de Usuario</h3></center>
                <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
            <div class="col-md-12">
                <center><asp:Image ID="imguser" ToolTip="Clic Para Seleccionar Imagen Usuario" CssClass="img-circle" ImageUrl="~/Imagenes/Usuarios.png" Width="20%" Height="20%" runat="server" /></center>
                <center><asp:FileUpload ID="FileUpload1" runat="server" /></center>
                <center><asp:HiddenField ID="HiddenField1" runat="server" /></center>
            </div>
            <div class="col-md-6">
                <h3>Información de la cuenta</h3>
                <div>
                    <div class="form-group">
                        <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <%--<input type="password" name="txtPassword" id="txtPassword" size="45" placeholder="Contraseña"/>--%>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Contraseña" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <%--<input type="password" name="txtPasswordCOnfirm" id="txtPasswordCOnfirm" size="45" placeholder="Confirmar Contraseña"/>--%>
                        <asp:TextBox ID="txtPasswordCOnfirm" TextMode="Password" passwordchar="*" CssClass="form-control" placeholder="Confirmar Contraseña" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox TextMode="Email" ID="txtEmail" CssClass="form-control" placeholder="Correo Electronico" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropTipoUsuario" CssClass="form-control" runat="server">
                            <asp:ListItem>--Seleccione el Tipo de Usuario--</asp:ListItem>
                            <asp:ListItem>Administrador</asp:ListItem>
                            <asp:ListItem>Vendedor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList ID="DropPreguntas" CssClass="form-control" runat="server">
                            <asp:ListItem>--Seleccione una Pregunta de Seguridad--</asp:ListItem>
                            <asp:ListItem>¿Nombre de tu Padre o tu Madre?</asp:ListItem>
                            <asp:ListItem>¿Estado civil?</asp:ListItem>
                            <asp:ListItem>¿Nombre de amigo(a) de la infancia?</asp:ListItem>
                            <asp:ListItem>¿Tu jugador Preferido?</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtRespuesta" CssClass="form-control" placeholder="Respuesta" required="" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
                    <div class="col-md-6">
                <h3>Información del Usuario</h3>
                <div>
                    <div class="form-group">
                        <asp:TextBox ID="txtNombres" CssClass="form-control" placeholder="Nombre completo" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Primer Apellido" required="" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtusername" CssClass="form-control" placeholder="Dirección" required="" runat="server"></asp:TextBox>
                    </div>
                </div> <br />
            </div>

            <center>
            <div class="btn-group" role="group" aria-label="...">
                <a class="btn btn-danger" href="/Inicio"><i class="glyphicon glyphicon-home"></i>Ir a inicio</a>
                <a class="btn btn-success" href="/Usuario"><i class="glyphicon glyphicon-log-in"></i>Ver Usuarios</a>
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-info" OnClick="btnRegistrarse_Click" ID="btnRegistrarse" runat="server" />
             </center>
        </div>

        <div class="col-md-3"></div>

    </form>
</body>
</html>
