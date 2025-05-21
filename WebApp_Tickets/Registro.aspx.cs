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
    public partial class Registro : System.Web.UI.Page
    {
        NegocioUsuario negocio = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Registro_btn(object sender, EventArgs e)
        { 
            Usuario nuevoUsuario = new Usuario
            {
                name = txtNombre.Text,
                lastname = txtApellido.Text,
                dni = txtDni.Text,
                email = txtEmail.Text,
                numerphone = txtTelefono.Text,
                birthdate = Convert.ToDateTime(txtCalendarioFN.Text),
                password = txtPass.Text
            };

            negocio.Registro(nuevoUsuario);

            string script = "alert('Su cuenta fue creada exitosamente.'); window.location='Default.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaRegistro", script, true);
        }
    }
}