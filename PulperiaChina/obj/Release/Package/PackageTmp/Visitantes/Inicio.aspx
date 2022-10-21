<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PulperiaChina.Visitantes.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .aki {
            height: 200px;
            width: 200px;
            margin-left:20px;
        }

        .abajo {
            margin-bottom: 5%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceSlider" runat="server">

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
    </div>
    <%-----Banner-----%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--permite realizar validaciones o ejecutar el javascript-->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- PRODUCT NAV -->
    <div class="tab-pane" style="background-color: #a34f9e; color: white; border-radius: 5px;">
        <center><h1><span class="glyphicon glyphicon-bell"></span> Últimos Artículos <span class="glyphicon glyphicon-bell"></span></h1></center>
    </div>
    <br />
    <br />

    <!-- PRODUCTS -->
    <div class="tab-content">
        <!-- Featured Products -->
        <div role="tabpanel" class="tab-pane fade in active" id="tab_one">
            <div class="row">
                <asp:ListView ID="LisArticulos" runat="server">
                    <ItemTemplate>
                        <div class="abajo col-md-3 col-sm-6">
                            <div class="product-singleArea">
                                <div class="aki product-img">
                                    <%--<div class="overlay"></div>--%>
                                    <img class="img-responsive primary_image" src="../<%#Eval("RutaImagen")%>" />
                                </div>
                                <div class="product-details">
                                    <center><div> <%#Eval("Nombre_Articulo") %></div>
                                    <div class="product-pd">
                                        <%--<div class="glyphicon glyphicon-usd"> <%#Eval("Precio") %></div>--%>
                                        <div class="glyphicon glyphicon-tags"> <%#Eval("NombreProveedor") %></div>
                                    </div>
                                    <div class="product-review">
                                        <div class="star">
                                            <div class="glyphicon glyphicon-star"> <%#Eval("Estado") %></div>
                                        </div>
                                    </div>
                                    <a class="btn btn-info" href="/Visitantes/DetalleArticulo.aspx?ID=<%#Eval("ID_Articulo") %>">Ver Detalle</a>
                                        </center>
                                    <%--con el otro metodo--%>
                                    <%--<a class="btn btn-info" href="/Visitantes/DetalleArticulo.aspx/<%#Eval("ID_Articulo") %>">Ver Detalle</a>--%>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
