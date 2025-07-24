using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EventoRanking
    {
        public string nombreEvento { get; set; }
        public int entradasVendidas { get; set; }

        public EventoRanking() 
        {
            nombreEvento = string.Empty;
            entradasVendidas = 0;
        }
    }
}
