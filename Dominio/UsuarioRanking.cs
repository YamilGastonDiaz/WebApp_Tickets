using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioRanking
    {
        public string nombreUsuario { get; set; }
        public int entradasCompradas { get; set; }

        public UsuarioRanking()
        {
            nombreUsuario = string.Empty;
            entradasCompradas = 0;
        }
    }
}
