using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using commerce;

namespace TPWebFORMS
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoPrueba1 carrito = Session["CarritoPrurba1"] as CarritoPrueba1; ;
            if (carrito != null ) {
                lblContadorArt.Style["display"] = "inline-flex";

            }
            else
            {
                lblContadorArt.Style["display"]= "none";
            }
        }
        public void ContadorDeArticulos(int Contador)
        {
            lblContadorArt.Text = Contador.ToString();
        }

    }
}