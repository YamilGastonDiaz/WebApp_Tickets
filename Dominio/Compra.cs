using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int compraId {  get; set; }
        public int eventoId { get; set; }
        public int usuarioId { get; set; }
        public int cantidad {  get; set; }
        public DateTime fecha { get; set; }
        public decimal monto {  get; set; }

        public Compra()
        {
            compraId = 0;
            eventoId = 0;
            usuarioId = 0;
            cantidad = 0;
            fecha = DateTime.MinValue;
            monto = 0;
        }

    }
}
