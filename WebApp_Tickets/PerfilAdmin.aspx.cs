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
    public partial class PerfilAdmin : System.Web.UI.Page
    {
        NegocioUsuario negocio = new NegocioUsuario();
        NegocioEvento negocioE = new NegocioEvento();
        NegocioUsuario negocioU = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewUsuarios.DataSource = negocioU.listarUser();
                GridViewUsuarios.DataBind();

                GridViewEventos.DataSource = negocioE.listar();
                GridViewEventos.DataBind();

                if (Session["Usuario"] != null)
                {
                    int id = (int)Session["Usuario_Id"];

                    Usuario user = negocio.Obtener(id);

                    if (user != null)
                    {
                        txtNombreAdmin.Text = user.name;
                        txtApellidoAdmin.Text = user.lastname;
                        txtDniAdmin.Text = user.dni;
                        txtEmailAdmin.Text = user.email;
                        txtTelefonoAdmin.Text = user.numerphone;
                        txtCalendarioFnAdmin.Text = user.birthdate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        protected void MostrarEditarCuentaAdmin(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 0;
        }

        protected void MostrarCambiarContraseniaAdmin(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 1;
        }

        protected void MostrarUsuarios(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 2;
        }

        protected void MostrarEventos(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 3;
        }

        protected void MostrarEstadisticas(object sender, EventArgs e)
        {
            MultiViewUser.ActiveViewIndex = 4;
        }

        protected void ModificarAdminBtn(object sender, EventArgs e)
        {
            int id = (int)Session["Usuario_Id"];
            Usuario user = negocio.Obtener(id);

            if (user != null) 
            {
                string nombre = txtNombreAdmin.Text;
                string apellido = txtApellidoAdmin.Text;
                string nroDocumento = txtDniAdmin.Text;
                string correo = txtEmailAdmin.Text;
                string tel = txtTelefonoAdmin.Text;
                DateTime fecha = Convert.ToDateTime(txtCalendarioFnAdmin.Text);

                Usuario adminModificado = new Usuario
                {
                    idUser = id,
                    name = nombre,
                    lastname = apellido,
                    dni = nroDocumento,
                    email = correo,
                    numerphone = tel,
                    birthdate = fecha
                };

                negocio.Modificar(adminModificado);

                string script = "alert('Datos actualizados correctamente.'); window.location='Default.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaModificacion", script, true);
            }
        }

        protected void ModificarPassAdminBtn(object sender, EventArgs e)
        {
            
        }

        protected void CrearEvento(object sender, EventArgs e) 
        {
            Response.Redirect("CrearEvento.aspx");
        }

        protected void ModificarEvento(object sender, EventArgs e)
        {
            try
            {
                string id = ((Button)sender).CommandArgument;
                Response.Redirect("ModificarEvento.aspx?id=" + id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EliminarEvento(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);
                negocioE.Baja(id);

                string script = "alert('Evento eliminado correctamente.'); window.location='Default.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaEliminacion", script, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}