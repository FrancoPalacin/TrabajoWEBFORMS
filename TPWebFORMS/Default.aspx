<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebFORMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>PAGINA PRINCIPAL </h1>

     <asp:TextBox ID="TxtFiltro" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonFiltro" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="BtnFiltro_Click" />

    <asp:Repeater runat="server" ID="Repetidor" OnItemDataBound="Repetidor_ItemDataBound">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">
                <img src="<%#Eval("ImagenArticulo") %>"
                    class="card-img-top"
                    alt="IMAGEN DEL ARTICULO" <%#Eval("name")%>
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("name") %></h5>
                    <p class="card-text"><%#Eval("Brand.Descrpition") %></p>
                    <h5 class="card-Price"><%#Eval("Price") %></h5>
                </div>
                <asp:Label ID="lblIDarticulo" runat="server" Text='<%#Eval("ArticleID")%>' Visible="false"</asp:Label>
            
                <asp:Button ID="ButtonVer" runat="server" Text="Ver Mas" CssClass="btn btn-primary" OnClick="ButtonVer_Click" CommandArgument="<%#Eval("ArticleId") %>" NavigateUrl="<%# String.Format("Articulos.aspx?id={0}"); Eval("ArticleId") %>" />
                
                <asp:Button ID="BtnComprar" runat="server" Text="Comprar" OnClick="BtnComprar_Click" Visible="false" CssClass=" btn btn-primary" CommandArgument="<%#Eval("ArticleId") %>" />
                
                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" Visible="false" CommandArgument="<%#Eval("ArticleId")%>" />
            </div>
        </div>
        </ItemTemplate>
    </asp:Repeater>
   
</asp:Content>
