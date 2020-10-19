<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarArt.aspx.cs" Inherits="CarritoWeb.AgregarArt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="align-content-center">Tus articulos seleccionados son: </h3>

    <table class="table table-bordered border-primary"></table>


    <asp:GridView ID="dvListado" runat="server" class="table table-sm"></asp:GridView>
    <h3 class="align-content-center">Por favor ingrese el ID del artículo a borrar:</h3>
    <asp:TextBox ID="ideliminar" runat="server" />
    <asp:Button ID="EliminarArticulos" runat="server" Text="Eliminar Articulos" OnClick="btnEliminarArticulo_Click" class="btn btn-outline-danger" Style="font-size: x-large; height: 50px; width: 225px; text-align: center; display: inline-block" />


    <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-trash" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
        <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
    </svg>

    <h3 class="align-content-center">El total es:</h3>
    <asp:Label class="align-content-center"  ID="Lbltotal" Text="text" runat="server" />

    <div class="card-body">
        <a href="Default.aspx?" class="card-link">Volver</a>
    </div>
</asp:Content>

