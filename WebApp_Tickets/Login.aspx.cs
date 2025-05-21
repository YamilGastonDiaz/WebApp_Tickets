using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Ingresar_btn(object sender, EventArgs e)
        {
            Usuario usuario;
            NegocioUsuario negocio = new NegocioUsuario();

            int numeroUser = 0;

            try
            {
                usuario = new Usuario(txt_Email.Text, txt_Pass.Text, numeroUser);
                bool exitoLog = negocio.Logear(usuario);
                numeroUser = (int)usuario.TipoUser;

                if (exitoLog)
                {
                    Session.Add("usuario", usuario);
                    Session.Add("Usuario_Id", usuario.idUser);                    
                    Session.Add("Email", usuario.email);

                    switch (numeroUser)
                    {
                        case 1:
                        case 2:
                            Response.Redirect("Default.aspx");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}