using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evento
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime fecha { get; set; }
        public string locale { get ; set;}
        public string  direction {  get; set; }
        public int totalTickt { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }

        public Evento()
        {
            id = 0;
            name = string.Empty;
            description = string.Empty;
            fecha = DateTime.MinValue;
            locale = string.Empty;
            direction = string.Empty;
            totalTickt = 0;
            price = 0;
            image = string.Empty;
        }
    }
}
