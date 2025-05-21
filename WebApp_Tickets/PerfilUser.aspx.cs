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
    public partial class PerfilUser : System.Web.UI.Page
    {
        NegocioUsuario negocio = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["Usuario"] != null)
                {
                    int id = (int)Session["Usuario_Id"];

                    Usuario user = negocio.Obtener(id);

                    if (user != null)
                    {
                        txtNombreUser.Text = user.name;
                        txtApellidoUser.Text = user.lastname;
                        txtDniUser.Text = user.dni;
                        txtEmailUser.Text = user.email;
                        txtTelefonoUser.Text = user.numerphone;
                        txtCalendarioFnUser.Text = user.birthdate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        protected void MostrarEditarCuenta(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 0;
        }

        protected void MostrarCambiarContrasenia(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 1;
        }

        protected void MostrarEliminarCuenta(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 2;
        }

        protected void Modificar_btn(object sender, EventArgs e)
        {
            int id = (int)Session["Usuario_Id"];
            Usuario user = negocio.Obtener(id);

            if (user != null) 
            {
                string nombre = txtNombreUser.Text;
                string apellido = txtApellidoUser.Text;
                string nroDocumento = txtDniUser.Text;
                string correo = txtEmailUser.Text;
                string tel = txtTelefonoUser.Text;
                DateTime fechaNacimiento = Convert.ToDateTime(txtCalendarioFnUser.Text);

                Usuario modificado = new Usuario
                {
                    idUser = id,
                    name = nombre,
                    lastname = apellido,
                    dni = nroDocumento,
                    email = correo,
                    numerphone = tel,
                    birthdate = fechaNacimiento
                };

                negocio.Modificar(modificado);

                string script = "alert('Datos actualizados correctamente.'); window.location='Default.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaModificacion", script, true);
            }
        }

        protected void ModificarPass_btn(object sender, EventArgs e)
        {

        }

        protected void ClickEliminarUser(object sender, EventArgs e) 
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    int id = int.Parse(Session["Usuario_Id"].ToString());

                    negocio.Baja(id);

                    Session.Clear();

                    string script = "alert('Cuenta eliminada exitosamente.'); window.location='Default.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaEliminacion", script, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}