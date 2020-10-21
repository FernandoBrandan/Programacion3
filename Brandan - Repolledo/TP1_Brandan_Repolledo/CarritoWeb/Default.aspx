<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TECH STORE</h1>
        <p class="lead">Bienvenidos a la tienda mas grande de zona Norte</p>
    </div>
    

        <div class="container">
    <div class="row">
            <div class="card-columns">
                <%foreach (Dominio.Articulo item in ListadeArticulos)
                    {%>
                <div class="card" style="width: 28rem; background-color:  lightgray">
                    <img src="<% = item.ImagenUrl%>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% =item.Nombre  %></h5>
                        <p class="card-text"><%=item.Descripcion %></p>
                        <p class="card-text"><%=item.Precio %></p>
                        <a href="AgregarArt.aspx?idAgregarCarrito=<% =item.ID.ToString() %>" class="btn btn-primary">Agregar</a>
                        <a href="DetalleArt.aspx?idAr=<% =item.ID.ToString() %>" class="btn btn-primary">Detalle</a>
                    </div>
                </div>
                <% }  %>
            </div>
        </div>
    </div>

</asp:Content>
