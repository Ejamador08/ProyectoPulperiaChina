<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PulperiaChina.Cuenta.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Acceso</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/custom.css" rel="stylesheet" />

    <style type="text/css">
        .login {
            margin-top: 30%;
            background-color:#a34f9e;
            color:white;
            border-radius:22px;
        }

        .cuerpo {
            background-image:url(../Imagenes/Slider/slider04.jpg);
        }

        .aumentar {
            font-size:18px;
        }
    </style>
</head>
<body class="cuerpo">

    <div class="row">

        <div class="col-md-4"></div>
        <div class="col-md-4">
            <form id="form1" runat="server">
                <div class="login">
                    <h3>
                        <center>Iniciar Sesión</center>
                    </h3>
                    <hr />
                    <div class="interno">
                        <h6 style="color: #c4076a;">
                            <asp:Literal ID="LiteralMensaje" runat="server"></asp:Literal>
                        </h6>
                        <div class="form-group">
                            <label class="aumentar">Usuario:</label>
                            <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" required=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="aumentar">Contraseña:</label>
                            <asp:TextBox ID="txtPasword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            <%--<asp:TextBox ID="txtPassword" TextMode="Password"  CssClass="form-control" runat="server" required></asp:TextBox>--%>
                        </div>
<%--                        <div class="form-group">
                            <asp:CheckBox ID="RememberMe" CssClass="Label" Text="Recordármelo la Próxima Vez..." runat="server" />
                        </div>--%>
                        <div class="form-group">
                            <div class="btn-group" role="group" aria-label="...">
                                <%--<a class="btn btn-warning" href="/Inicio"><i class="glyphicon glyphicon-home"></i>Ir a inicio</a>
                                <a class="btn btn-warning" href="/Cuenta/Registro.aspx"><i class="glyphicon glyphicon-log-in"></i>Registrarse</a>--%>
                            </div>
                            <asp:Button Text="Iniciar Sesión" OnClick="btnAccesar_Click" CssClass="btn btn-info pull-right" ID="btnAccesar" runat="server" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <div class="col-md-4">
        </div>
    </div>
</body>
</html>
