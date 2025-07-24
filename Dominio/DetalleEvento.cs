using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleEvento
    {
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public int totalEntradas { get; set; }
        public int entradasVendidas { get; set; }
        public int entradasNoVendidas { get; set; }
        public decimal recaudacion { get; set; }

        public DetalleEvento()
        {
            nombre = string.Empty;
            fecha = DateTime.MinValue;
            totalEntradas = 0;
            entradasVendidas = 0;
            entradasNoVendidas = 0;
            recaudacion = 0;
        }
    }
}
