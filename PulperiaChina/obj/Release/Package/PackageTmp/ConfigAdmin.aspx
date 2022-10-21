<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigAdmin.aspx.cs" Inherits="PulperiaChina.ConfigAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/sb-admin.css" rel="stylesheet" />
    <link href="../Content/morris.css" rel="stylesheet" />
    <link href="../Content/sweetalert.css" rel="stylesheet" />
    <script src="../Scripts/sweetalert-dev.js"></script>
    <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/jquery.js"></script>
    <title>Administrador</title>
    <style>
        body {
            background-color: #a34f9e;
            width: 100%;
            height: 100%;
        }

        .uno {
        }
    </style>

    <script>
        $(function () {
            $('#<%=fulogo.ClientID%>').on("change", function () {
                var files = !!this.files ? this.files : [];
                if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

                if (/^image/.test(files[0].type)) { // only image file
                    var reader = new FileReader(); // instance of the FileReader
                    reader.readAsDataURL(files[0]); // read the local file

                    reader.onloadend = function () { // set image data as background of div

                        $('#<%=imglogo.ClientID%>').attr('src', this.result);
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" class="uno" runat="server">



        <div class="container">

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

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-2"></div>
                                <div class="col-md-2">
                                    <br />
                                    <a href="/Inicio" class="btn btn-success pull-right"><span></span>Entrar al Sistema <span></span></a>
                                </div>
                                <div class="col-md-2">
                                    <br />
                                    <label style="color: white">Editar Información </label>
                                    <asp:CheckBox ID="chinfo" OnCheckedChanged="chinfo_CheckedChanged1" Checked="false" AutoPostBack="true" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Cambio Dolar</label>
                                    <asp:TextBox ID="txtdolar" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <br />
                                    <asp:Button ID="btnguardar" OnClick="btnguardar_Click" CssClass="btn btn-primary pull-right" runat="server" Text="Guardar" />
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtid" Visible="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Nombre de la Empresa</label>
                                    <asp:TextBox ID="txtempresa" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Propietario</label>
                                    <asp:TextBox ID="txtpropietario" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Administrador</label>
                                    <asp:TextBox ID="txtadmin" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-2"></div>
                                <div class="col-md-3">
                                    <label style="color: white">Ubicación</label>
                                    <asp:TextBox ID="txtubicacion" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Descripción</label>
                                    <asp:TextBox ID="txtdesc" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Municipio</label>
                                    <asp:TextBox ID="txtmunic" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-2"></div>
                                <div class="col-md-3">
                                    <label style="color: white">Departamento</label>
                                    <asp:TextBox ID="txtdepto" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">Teléfono</label>
                                    <asp:TextBox ID="txttelef" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label style="color: white">EMail</label>
                                    <asp:TextBox ID="txtmail" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-5"></div>
                                <div class="col-md-4">
                                    <label style="color: white">Logo de la Empresa</label>
                                    <br />
                                    <asp:Image ID="imglogo" Width="40%" Height="50%" ImageUrl="~/Imagenes/logoPC.jpg" runat="server" />
                                    <asp:HiddenField ID="hflogo" runat="server" />
                                    <asp:FileUpload ID="fulogo" runat="server" />
                                </div>
                                <div class="col-md-3"></div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>

    <script src="../Scripts/jquery-1.9.1.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../Scripts/bootstrap.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="../Scripts/raphael.min.js"></script>
    <script src="../Scripts/morris.min.js"></script>
    <script src="../Scripts/morris-data.js"></script>
</body>
</html>
