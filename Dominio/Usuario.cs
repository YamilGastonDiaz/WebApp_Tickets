using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUser
    {
        ADMIN = 1,
        CLIENTE = 2
    }
    public class Usuario
    {
        public int idUser { get; set; }        
        public string name { get; set; }
        public string lastname { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public string numerphone { get; set; }
        public string password { get; set; }
        public TipoUser TipoUser { get; set; }

        public Usuario()
        {

        }

        public Usuario(string UserE, string pass, int user)
        {
            email = UserE;
            password = pass;

            if (user == 1)
            {
                TipoUser = TipoUser.ADMIN;
            }
            else
            {
                TipoUser = TipoUser.CLIENTE;
            }
        }           
    }
}
