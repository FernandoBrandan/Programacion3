<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArt.aspx.cs" Inherits="CarritoWeb.DetalleArt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="card" style="width: 18rem;">
        <img  src="<% = articulo.ImagenUrl %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"  ><% =articulo.Nombre %></h5>
            <p class="card-text">Descripción del artículo</p>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item"><%=articulo.Descripcion %></li>
            <li class="list-group-item"><%=articulo.Precio %></li>
            <li class="list-group-item"><%=articulo.Categoria %></li>
        </ul>
        <div class="card-body">
            <a href="Default.aspx?" class="card-link">Volver</a>
        </div>
    </div>
</asp:Content>
