using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Validaciones
    {
        public bool ValidarPassword(string pass)
        {
            return pass.Length >= 6 &&
                   pass.Length <= 12 &&
                   pass.Any(char.IsUpper) &&
                   pass.Any(char.IsDigit) &&
                   !pass.Any(char.IsWhiteSpace);
        }
    }
}
