using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class Contacto : System.Web.UI.Page
    {
        EmailService email = new EmailService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Contacto(object sender, EventArgs e)
        {
            email.MensajeContacto(txtNombre.Text, txtEmail.Text, txtMensaje.Text);
            email.EnviarEmail();

            lblConfirmacion.Text = "¡Gracias por tu mensaje!";
            lblConfirmacion.Visible = true;
        }
    }
}