<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarArt.aspx.cs" Inherits="CarritoWeb.AgregarArt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2 class="display-3 font-weight-bold text-shadow" style="color: black; margin: 40px auto 30px;">TUS ARTICULOS: </h2>

    <asp:GridView ID="dvListado" runat="server" class="table table-sm table table-striped table-dark"></asp:GridView>

    <div class="container">
        <div class="row" style="float: left; margin-top: 30px">
            <h2 class="align-content-center">Precio total:
                <asp:Label class="align-content-center" ID="Lbltotal" Text="text" runat="server"  />                
                <asp:Button ID="Button1" runat="server" Text="PAGAR" OnClick="btnPagar_Click" type="button" class="btn btn-success" Style="height: 50px; width: 200px; font-size: 20px;" />
            </h2>
            <asp:TextBox ID="ideliminar" placeholder="Seleccionar ID" runat="server" Style="text-align: center; margin-left: 200px; margin-right: 10px; margin-top: 15px; width: 200px; height: 50px" />
            <asp:Button ID="EliminarArticulos" runat="server" Text="Eliminar" OnClick="btnEliminarArticulo_Click" type="button" class="btn btn-danger" Style="margin-top: 15px; margin-right: 15px; height: 50px" />
            <asp:Button ID="EliminarTodo" runat="server" Text="Eliminar Todo" OnClick="btnEliminarTodo_Click" type="button" class="btn btn-danger" Style="margin-top: 15px; height: 50px" />
        </div>

    </div>

    <a href="Default.aspx?" type="button" class="btn btn-outline-light" style="font-size: x-large; margin-top: 60px">Volver al catalogo</a>

</asp:Content>

