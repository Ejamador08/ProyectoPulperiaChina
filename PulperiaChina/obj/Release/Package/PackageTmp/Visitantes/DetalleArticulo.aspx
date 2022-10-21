<%@ Page Title="Detalle de Articulo" Language="C#" MasterPageFile="~/Visitantes/MaestraVisitante.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="PulperiaChina.Visitantes.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ima {
            height: 100%;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:#a34f9e; border-radius: 5px;">
        <h3><a style="font-size:30px; color:white; margin-left:35%;">DETALLE DEL ARTÍCULO</a></h3>
    </div>
    <br />

    <div class="row">
        <div class="col-md-6">
            <asp:Image ID="ImageArticulo" CssClass="ima img-responsive-area" runat="server" />
        </div>
        <div class="col-md-6">
            <h4><a style="font-size:30px; color:black">Nombre:</a>
                <br />
                <br />
                <a style="margin-left:10%; color:black">
                <asp:Label ID="lblNombre" runat="server" Text="" BorderStyle="Double" Font-Size="Larger"></asp:Label></a></h4>
            <br />
            <h4><a style="font-size:30px; color:black">Código:</a>
                <br />
                <br />
                <a style="margin-left:10%; color:black">
                <asp:Label ID="lblCodigo" runat="server" Text="" BorderStyle="Double" Font-Size="Larger"></asp:Label></a></h4>
            <br />
            <h4><a style="font-size:30px; color:black">Descripción:</a>
                <br />
                <br />
                <a style="margin-left:10%; color:black;">
                <asp:Label ID="Descripcion" runat="server" Text="" BorderStyle="Double" Font-Size="Larger"></asp:Label></a></h4>
            <br />
            <%--<h4>Precio: C$ <asp:Label ID="lblPrecio" runat="server" Text="Label"></asp:Label></h4><br />--%>
            <%--<h4>Categoria: <asp:Label ID="lblCategoria" runat="server" Text="Label"></asp:Label></h4><br />--%>
            <%--<a class="btn btn-warning" href="#">COMPRAR</a>--%>
            <a href="Inicio.aspx" class="btn btn-info pull-right">Atrás</a>
        </div>
    </div>
    <div class="row">
        <%--<h3>Artículos Relacionados</h3>--%>
        <asp:ListView ID="ListViewRelacionados" runat="server">
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="media">
                        <div class="media-left">
                            <a href="DetalleArticulo.aspx/<%#Eval("ID_Articulo") %>">
                                <img class="media-object" src="/<%#Eval("RutaImagen") %>" alt="..." />
                            </a>
                        </div>
                        <div class="media-body">
                            <h4 class="media-heading"><%#Eval("Nombre_Articulo") %></h4>
                            <%--<i class="glyphicon glyphicon-apple"><%#Eval("Precio") %></i>--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
