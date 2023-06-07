using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebFORMS
{
    public partial class Default : System.Web.UI.Page
    {
        public List<DetallesArticulos> detallesArticulos { get; set; }
        public List<Article> articles = new List<Article>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            detallesArticulos = conector.GetArticleWithCartDetails();
            articles = detallesArticulos.Cast<Article>().ToList();
            if (!IsPostBack)
            {
                Repetidor.DataSource = detallesArticulos;
                Repetidor.DataBind();

            }
            CarritoPrueba1 carrito = Session["CarritoPrueba1"] as CarritoPrueba1;

            if (carrito != null )
            {
                carrito.GetArticulosFinal();
            }
        }
         

        protected void Repetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DetallesArticulos articulo =e.Item.DataItem as DetallesArticulos;
            CarritoPrueba1 carrito = Session["CarritoPrueba1"] as CarritoPrueba1;

            Button btnComprar = e.Item.FindControl("BtnComprar") as Button;
            Button btnEliminar = e.Item.FindControl("BtnEliminar") as Button;

            if (carrito != null && carrito.TieneArticulo(articulo.ArticleId))
            {
               btnComprar.Visible = true; btnEliminar.Visible = true;
            }
            else
            {
                btnComprar.Visible = false; btnEliminar.Visible = false;
            }

        }

        protected void ButtonVer_Click(object sender, EventArgs e)
        {
            Button ver = (Button)sender;
            string id = ver.CommandArgument.ToString();

            Response.Redirect("Articulos.aspx?id=" +  id);
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            Button comprar = (Button)sender;
            string id = comprar.CommandArgument.ToString();
            int Articulo;

            CarritoPrueba1 carrito = Session["CarritoPrueba1"] as CarritoPrueba1;
            if (carrito == null)
            {
                carrito = new CarritoPrueba1();
                Session["CarritoPrueba1"]= carrito; ;
            }
            if(int.TryParse(id, out Articulo))
            {

                 CarritoArt nuevoArt=new CarritoArt(Articulo);
                
                carrito.AgregarArticulo(nuevoArt);
                Session["CarritoPrueba1"] = carrito;
                Repetidor.DataSource = detallesArticulos;
                Repetidor.DataBind();
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnFiltro_Click(object sender, EventArgs e)
        {
            string filtro = TxtFiltro.Text;

              List<Article> Lista = articles.FindAll(x => x.Name.ToUpper().Contains(filtro.ToUpper()));
        Repetidor.DataSource= Lista;
            Repetidor.DataBind();
        
        }
    }
}