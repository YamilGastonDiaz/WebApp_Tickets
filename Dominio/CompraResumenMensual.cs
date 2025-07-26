using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompraResumenMensual
    {
        public string mes {  get; set; }
        public int numeroMes { get; set; }
        public decimal recaudacionMensual { get; set; }

        public CompraResumenMensual()
        {
            mes = string.Empty;
            numeroMes = 0;
            recaudacionMensual = 0;
        }
    }
}
