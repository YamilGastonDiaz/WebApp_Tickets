using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WebApp_Tickets
{
    public partial class CrearEvento : System.Web.UI.Page
    {
        NegocioEvento negocio = new NegocioEvento();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ClickCrearEvento(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaCreacion = DateTime.Now;
                
                string ruta = Server.MapPath("./Img/ImgEvento/");
                string nombreArchivo = "evento_" + fechaCreacion.ToString("yyyyMMdd_HHmmss") + ".jpg";
                string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                txtImagen.PostedFile.SaveAs(rutaCompleta);

                Evento evento = new Evento
                {
                    name = txtNombre.Text,
                    description = txtDescripcion.Text,
                    fecha = Convert.ToDateTime(txtFecha.Text),
                    locale = txtLugar.Text,
                    direction = txtDireccion.Text,
                    totalTickt = int.Parse(txtTotalEntrada.Text),
                    price = decimal.Parse(txtTotalEntrada.Text),
                    image = nombreArchivo
                };

                negocio.Agregar(evento);

                string script = "alert('Evento creado correctamente.'); window.location='Default.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCrearEvento", script, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}