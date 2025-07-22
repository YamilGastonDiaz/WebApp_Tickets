using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class ModificarEvento : System.Web.UI.Page
    {
        NegocioEvento negocio = new NegocioEvento();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idEvento = int.Parse(Request.QueryString["id"]);
                Evento seleccionado = negocio.Obtener(idEvento);

                if (seleccionado != null)
                {
                    txtNombre.Text = seleccionado.name;
                    txtDescripcion.Text = seleccionado.description;
                    txtFecha.Text = seleccionado.fecha.ToString("yyyy-MM-ddTHH:mm");
                    txtLugar.Text = seleccionado.locale;
                    txtDireccion.Text = seleccionado.direction;
                    txtTotalEntrada.Text = seleccionado.totalTickt.ToString();
                    txtPrecio.Text = seleccionado.price.ToString();

                    if (!string.IsNullOrEmpty(seleccionado.image))
                    {
                        Img_Evento.ImageUrl = "~/Img/ImgEvento/" + seleccionado.image;
                    }
                    else
                    {
                        Img_Evento.ImageUrl = "~/Img/ImgEvento/No-imge.jpg";
                    }
                }
            }
        }

        protected void ClickModificarEvento(object sender, EventArgs e)
        {
            int idEvento = int.Parse(Request.QueryString["id"]);
            Evento evento = negocio.Obtener(idEvento);

            if (evento != null)
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                DateTime fechaEvento = Convert.ToDateTime(txtFecha.Text);
                string lugar = txtLugar.Text;
                string direccion = txtDireccion.Text;
                int totalEntrada = int.Parse(txtTotalEntrada.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                string nombreArchivo = evento.image;

                if (txtImagen.HasFile)
                {
                    string extension = Path.GetExtension(txtImagen.FileName);
                    string ruta = Server.MapPath("~/Img/ImgEvento/");
                    nombreArchivo = "evento_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                    string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                    txtImagen.SaveAs(rutaCompleta);
                }

                Evento eventoModificado = new Evento
                {
                    name = nombre,
                    description = descripcion,
                    fecha = fechaEvento,
                    locale = lugar,
                    direction = direccion,
                    totalTickt = totalEntrada,
                    price = precio,
                    image = nombreArchivo,
                    id = idEvento
                };

                negocio.Modificar(eventoModificado);

                string script = "alert('Evento modificado correctamente.'); window.location='Default.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaModificarEvento", script, true);
            }
        }

        protected void btn_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("PerfilAdmin.aspx");
        }
    }
}