<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="CarritoWeb.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="align-content-center">Tus articulos seleccionados son: </h3>
     <% decimal Total = 0; %>
    <div class="container">
        <div class="row">
            <div class="col">
                <a href="Default.aspx?" class="btn btn-primary">Volver</a>
               
                <table class="table">

                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Nombre</th>
                            <th scope="col">Imagen</th>
                            <th scope="col">Descripción</th>
                            <th scope="col">Precio</th>

                        </tr>
                    </thead>

                    <%foreach (var art in listadeCarrritos)
                        {
                    %>

                    <tr>
                        <td><% =art.Nombre %></td>
                       <td>  <img src="<% = art.ImagenURL%>" class="img-thumbnail" alt="..." width="80" height="80"> </td>
                        <td><% =art.Descripcion %></td>
                        <td><% =art.Precio %></td>
                       <td> <a href="AgregarCarrito.aspx?agCar=<% =art.IdArticulo.ToString() %>" class="btn btn-primary">Agregar</a> </td>
                        <td><a href="AgregarCarrito.aspx?idQuitar=<% = art.IdArticulo.ToString() %>" class="btn btn-primary">Quitar</a></td>  
                    </tr>
                    <%Total += art.Precio;  %>
                    <%}
                        
                    %>
                </table>
                <h3>El total es:</h3>
                <h3><%=Total %></h3>
            </div>
        </div>
    </div>



</asp:Content>
    


