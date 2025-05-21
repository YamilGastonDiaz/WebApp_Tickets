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
    }
}