<%@ Page Title="Administrador" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="EntradaAdmin.aspx.cs" Inherits="PulperiaChina.EntradaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-10">
                    <center><h1 class="text-success" style="font-size:50px;"> Información Del Administrador Y La Empresa </h1></center>
                </div>
                <div class="col-md-2">
                    <br />
                    <br />
                    <a href="/Inicio" class="btn btn-success pull-right"><span></span>Entrar <span></span></a>
                </div>
            </div>
            <div class="col-md-12">
                <br />
                <br />
                <br />
            </div>
            <div class="col-md-12">
                <div class="col-md-5"></div>
                <div class="col-md-2">
                    <label>Editar Información</label>
                    <asp:CheckBox ID="cheditar" Checked="false" AutoPostBack="true" OnCheckedChanged="cheditar_CheckedChanged" runat="server" />
                </div>
                <div class="col-md-5"></div>
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
                    <label>Nombre de la Empresa</label>
                    <asp:TextBox ID="txtempresa" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Propietario</label>
                    <asp:TextBox ID="txtpropietario" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Administrador</label>
                    <asp:TextBox ID="txtadmin" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
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
                    <label>Ubicación</label>
                    <asp:TextBox ID="txtubicacion" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Descripción</label>
                    <asp:TextBox ID="txtdesc" Enabled="false" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Municipio</label>
                    <asp:TextBox ID="txtmunic" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
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
                    <label>Departamento</label>
                    <asp:TextBox ID="txtdepto" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Teléfono</label>
                    <asp:TextBox ID="txttelef" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Email</label>
                    <asp:TextBox ID="txtmail" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
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
                    <label>Logo de la Empresa</label>
                    <br />
                    <asp:Image ID="imglogo" Width="40%" Height="50%" ImageUrl="~/Imagenes/logoPC.jpg" runat="server" />
                    <asp:HiddenField ID="Hflogo" runat="server" />
                    <asp:FileUpload ID="Fulogo" runat="server" />
                </div>
                <div class="col-md-3"></div>
            </div>
            <div class="col-md-12">
                <br />
                <br />
                <br />
            </div>
            <div class="col-md-12">
                <div class="col-md-5"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                </div>
                <div class="col-md-5"></div>
            </div>
        </div>
    </div>
</asp:Content>
