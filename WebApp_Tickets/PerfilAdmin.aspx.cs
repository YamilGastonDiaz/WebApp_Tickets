using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        NegocioEstadisticas negocioEstadistica = new NegocioEstadisticas();
        Validaciones validar = new Validaciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewUsuarios.DataSource = negocioU.listarUser();
                GridViewUsuarios.DataBind();

                GridViewEventos.DataSource = negocioE.listar();
                GridViewEventos.DataBind();

                CargarTarjetas();
                CargarRankingEventos();
                CargarRankingUsuarios();

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
            int id = (int)Session["Usuario_Id"];
            Usuario user = negocio.Obtener(id);

            if (user != null)
            {
                string pass1 = txtPassAdmin.Text;
                string pass2 = txtPassNuevoAdmin.Text;

                lblMensajePassword.Visible = true;

                if (string.IsNullOrWhiteSpace(pass1) || string.IsNullOrWhiteSpace(pass2))
                {
                    lblMensajePassword.Text = "Debe completar ambos campos.";
                    return;
                }

                if (pass1 != pass2)
                {
                    lblMensajePassword.Text = "Las contraseñas no coinciden.";
                    return;
                }

                bool esValida = validar.ValidarPassword(pass1);

                if (!esValida)
                {
                    lblMensajePassword.Text = "La contraseña debe tener entre 6 y 12 caracteres, una mayúscula y un número.";
                    return;
                }
                Usuario passAdmin = new Usuario
                {
                    password = pass1,
                    idUser = id
                };
                negocio.ModificarPass(passAdmin);

                lblMensajePassword.ForeColor = System.Drawing.Color.Green;
                lblMensajePassword.Text = "Contraseña modificada correctamente.";
            }
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

        protected void FiltrarAnio(object sender, EventArgs e)
        {
            int anio;
            if (int.TryParse(txtAnio.Text, out anio))
            {
                CargarGrafico(anio);
            }
        }

        protected void BuscarEvento(object sender, EventArgs e)
        {
            string nombre = txtEventoBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(nombre))
            {
                
                var detalle = negocioEstadistica.ObtenerDetalleEvento(nombre);

                if (detalle != null)
                {
                    GridViewDetalleEvento.DataSource = new List<DetalleEvento> { detalle };
                    GridViewDetalleEvento.DataBind();
                }
                else
                {
                    GridViewDetalleEvento.DataSource = null;
                    GridViewDetalleEvento.DataBind();
                }
            }
        }
        private void CargarTarjetas()
        {
            lblUsuariosActivos.Text = negocioEstadistica.UsuariosActivos().ToString();
            lblUsuariosBaja.Text = negocioEstadistica.UsuariosDadosDeBaja().ToString();
            lblRecaudacionTotal.Text = "$ " + negocioEstadistica.RecaudacionTotal().ToString("N2");
        }
        private void CargarGrafico(int anio)
        {
            var datos = negocioEstadistica.ObtenerRecaudacionMensual(anio);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);

            litDatosRecaudacion.Text = $"<script>var datosRecaudacion = {json};</script>";
        }
        private void CargarRankingEventos()
        {
            GridViewRankingEventos.DataSource = negocioEstadistica.ObtenerRankingEventos();
            GridViewRankingEventos.DataBind();
        }
        private void CargarRankingUsuarios()
        {
            GridViewRankingUsuarios.DataSource = negocioEstadistica.ObtenerRankingUsuarios();
            GridViewRankingUsuarios.DataBind();
        }
    }
}