using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class CarritoArt
    {
        public CarritoArt(int IDarticulo)
        {
            this.IDarticulo = IDarticulo;
            cantidad = 1;
        }

        public int IDarticulo { get; set; }
        public int cantidad { get; set; }
    }
}
