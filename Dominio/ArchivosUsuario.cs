using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArchivosUsuario
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public int idEvento { get; set; }
        public string nameArchivo { get; set; }
        public DateTime fecha { get; set; }

        // Agregadas para visualización
        public string EventoNombre { get; set; }
        public string EventoImagen { get; set; }

        public ArchivosUsuario()
        {
            id = 0;
            idUser = 0;
            idEvento = 0;
            nameArchivo = string.Empty;
            fecha = DateTime.MinValue;
        }
    }
}
