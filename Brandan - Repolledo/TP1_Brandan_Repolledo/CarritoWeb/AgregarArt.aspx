<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="AgregarArt.aspx.cs" Inherits="CarritoWeb.AgregarArt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
             

            <h1>hola</h1>
            <asp:TextBox id="txtArticulo" runat ="server" />
            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>

     
            <asp:GridView id="dvListado" runat="server">   </asp:GridView>

          
        </div>
    </form>
</body>
</html>
