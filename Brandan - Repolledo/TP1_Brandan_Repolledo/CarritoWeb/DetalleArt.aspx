<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleArt.aspx.cs" Inherits="CarritoWeb.DetalleArt" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label Text="Nombre de articulo: " runat="server" />

            <h1><% =  articulo.Nombre %></h1>
            
            <asp:Label Text="Descripción:" runat="server" />

        </div>
    </form>
</body>
</html>
