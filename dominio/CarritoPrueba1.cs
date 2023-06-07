using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class CarritoPrueba1
    {
        List<CarritoArt> ArticulosCarrito = new List<CarritoArt>();

        public void AgregarArticulo(CarritoArt article)
        {
            CarritoArt Stock = ArticulosCarrito.Find(Art => Art.IDarticulo == article.IDarticulo);
            if (Stock != null)
            {
                Stock.cantidad++;
            }
            else
            {
                ArticulosCarrito.Add(article);
            }

        }
        //get de articulo selected
        public CarritoArt getArticulo(int IDArticulo)
        {
            return ArticulosCarrito.Find(ART => ART.IDarticulo == IDArticulo);
        }
        //get de articuloSS
        public List<CarritoArt> GetArticulos()
        {
            return ArticulosCarrito;
        }
        //gets de final de articulos
        public int GetArticulosFinal()
        {
            int final = 0;
            foreach (var articulo in ArticulosCarrito)
            {
                final += articulo.cantidad;
            }
            return final;
        }
        public int GetCantidad(int ID)
        {
            return getArticulo(ID).cantidad;
        }
        //Borrado de articulos de la lista del carrito
        public void BorarArticulo(CarritoArt art)
        {
            CarritoArt ArticuloEnLista = ArticulosCarrito.Find(ART => ART.IDarticulo == art.IDarticulo);
            if (ArticuloEnLista != null && ArticuloEnLista.cantidad > 1)
            {
                ArticuloEnLista.cantidad--;
            }
            else if (ArticuloEnLista != null && ArticuloEnLista.cantidad == 1)
            {
                SacarArticulo(art);
            }
        }


        public void SacarArticulo(CarritoArt art)
        {
            CarritoArt current = getArticulo(art.IDarticulo);
            ArticulosCarrito.Remove(current);
        }
        //get para saber si un articulo ya esta agregado al carrito
        public bool TieneArticulo(int id)
        {
            return ArticulosCarrito.Contains(getArticulo(id));
        }
    }
}
