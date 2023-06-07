using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class DetallesArticulos: Article
    {
        public int CantidadArt { get; set; }
        public decimal PrecioArt { get; set; }
    }
}
