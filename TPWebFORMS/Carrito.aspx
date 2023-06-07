<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWebFORMS.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <style>
        .button-container{
            margin-top:8px;
        }

    </style>

    <section class="h-100" style="background-color: #eee;">
        <div class="container h-100 py-5">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-10">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h3 class="fw-normal mb-0 text-black">Shopping Cart</h3>
                    </div>
                    <asp:Repeater ID="Repetidor" runat="server">
                        <ItemTemplate>   
                            <div class="card rounded-3 mb-4">
                                <div class="card-body p-4">
                                    <div class="row d-flex justify-content-between align-items-center">
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <img
                                                src="<%#Eval("ArticleImage") %>"  class="img-fluid rounded-3" alt="IMAGEN DE ARTICULO <%#Eval("Name") %>"
                                                onerror="this.src='https://www.google.com/imgres?imgurl=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F004%2F141%2F669%2Fnon_2x%2Fno-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg&tbnid=Q-MVc6qD9PUJ5M&vet=12ahUKEwix_Kf1krD_AhU-rpUCHXIICJcQMygAegUIARDMAQ..i&imgrefurl=https%3A%2F%2Fes.vecteezy.com%2Farte-vectorial%2F4141669-sin-foto-o-imagen-en-blanco-icono-cargando-imagenes-o-imagen-faltante-marca-imagen-no-disponible-o-imagen-proxima-firmar-simple-naturaleza-silueta-en-marco-ilustracion-vectorial-aislada&docid=3WG7zJyV8rwJhM&w=1093&h=980&q=sin%20imagen&client=opera-gx&ved=2ahUKEwix_Kf1krD_AhU-rpUCHXIICJcQMygAegUIARDMAQ'" />
                                               
                                     
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                    </div>
                </div>
            </div>
        
    </section>

</asp:Content>
