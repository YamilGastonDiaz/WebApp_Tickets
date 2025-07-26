using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    NegocioEvento negocio = new NegocioEvento();
                    List<Evento> mostrarEvento = new List<Evento>();

                    int id = (int)Session["id"];

                    mostrarEvento.Add(negocio.Obtener(id));

                    rpt_NameYcantidad.DataSource = mostrarEvento;
                    rpt_NameYcantidad.DataBind();

                    rpt_Hora.DataSource = mostrarEvento;
                    rpt_Hora.DataBind();

                    rpt_Price.DataSource = mostrarEvento;
                    rpt_Price.DataBind();
                }
            }
        }

        private int total = 0;
        private decimal totalFinal = 0;
        private const int MAX_ENTRADAS = 5;

        protected void Decrementar_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                int id = (int)Session["id"];

                NegocioEvento negocio = new NegocioEvento();
                Evento evento = negocio.Obtener(id);

                total = int.Parse(lbl_Contar.Text);
                if (total > 0)
                {
                    total--;
                }
                lbl_Contar.Text = total.ToString();

                lbl_TicketPrecio.Text = evento.price.ToString("F2");

                lbl_Cantidad.Text = total.ToString();

                totalFinal = evento.price * total;
                lbl_Total.Text = totalFinal.ToString("F2");
            }
        }

        protected void Incrementar_Click(object sender, EventArgs e)
        {
            int id = (int)Session["id"];

            NegocioEvento negocio = new NegocioEvento();
            Evento evento = negocio.Obtener(id);

            total = int.Parse(lbl_Contar.Text);
            if (total < MAX_ENTRADAS && total < evento.totalTickt)
            {
                total++;
            }
            lbl_Contar.Text = total.ToString();

            lbl_TicketPrecio.Text = evento.price.ToString("F2");

            lbl_Cantidad.Text = total.ToString();

            totalFinal = evento.price * total;
            lbl_Total.Text = totalFinal.ToString("F2");
        }

        protected void Pagar_click(object sender, EventArgs e)
        {
            NegocioEvento negocioE = new NegocioEvento();            
            NegocioMercadoPago negocioMP = new NegocioMercadoPago();

            try
            {
                if (Session["Usuario_Id"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                int cantidad = int.Parse(lbl_Cantidad.Text);

                if (!AceptarTerminos())
                {
                    lblMensaje.Text = "Debe aceptar los términos y condiciones.";
                    lblMensaje.Visible = true;
                }
                else if (cantidad <= 0)
                {
                    lblMensaje.Text = "Debes seleccionar al menos una entrada.";
                    lblMensaje.Visible = true;
                }
                else
                {
                    int idEvento = (int)Session["id"];
                    Evento evento = negocioE.Obtener(idEvento);

                    // Datos de la compra                    
                    string nombre = evento.name.ToString();
                    decimal precioUnitario = decimal.Parse(lbl_TicketPrecio.Text);

                    Session["Cantidad"] = cantidad;
                    Session["PrecioUnitario"] = precioUnitario;

                    string checkoutUrl = negocioMP.CrearPreferencia(nombre, precioUnitario, cantidad);

                    Response.Redirect(checkoutUrl, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool AceptarTerminos()
        {
            return checkCondiciones.Checked;
        }
    }
}

