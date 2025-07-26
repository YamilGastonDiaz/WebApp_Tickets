using Dominio;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class ResultadoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string estado = Request.QueryString["estado"];
                string mensaje = "";
                string paymentIdStr = Request.QueryString["payment_id"];

                if (!string.IsNullOrEmpty(estado))
                {
                    switch (estado)
                    {
                        case "success":
                            RegistrarCompra();
                            mensaje = "¡Pago confirmado. Gracias por tu compra!";
                            break;
                        case "pending":
                            mensaje = "El pago está pendiente. Te avisaremos cuando se acredite.";
                            break;
                        case "failure":
                            mensaje = "El pago fue rechazado o cancelado. Intenta nuevamente.";
                            break;
                    }
                    lblMensaje.Text = mensaje;
                }
            }
        }
        private void RegistrarCompra()
        {
            string asunto = "ENTRADAS PARA TU EVENTO";
            string body = "Gracias por tu compra!!!. Aqui tienes tu entradas para el evento";
            try
            {
                int userId = (int)Session["Usuario_Id"];
                int eventoId = (int)Session["id"];
                int cantidad = (int)Session["Cantidad"];
                decimal precioUnitario = (decimal)Session["PrecioUnitario"];
                decimal total = cantidad * precioUnitario;
                string mail = (string)Session["email"];

                NegocioCompra negocioC = new NegocioCompra();
                NegocioEvento negocioE = new NegocioEvento();
                NegocioArchivosUsuario negocioAU = new NegocioArchivosUsuario();
                EmailService emailService = new EmailService();
                EntradaQR entradaQr = new EntradaQR();

                Evento evento = negocioE.Obtener(eventoId);
                string nombre = evento.name;
                string fecha = evento.fecha.ToString("dddd, dd MMMM yyyy");
                string lugar = evento.locale;
                string direccion = evento.direction;

                int compraId = negocioC.RegistrarCompraConEntradas(eventoId, userId, cantidad, total);

                List<string> entrada = negocioC.ObtenerCodigoPorCompra(compraId);

                emailService.ArmarEmail(mail, asunto, body);

                foreach (string codigo in entrada)
                {
                    string rutaBase = Server.MapPath("~/Entradas");

                    string rutaPDF = entradaQr.GenerarPDF(nombre, fecha, lugar, direccion, codigo, rutaBase);

                    Attachment adjunto = new Attachment(rutaPDF);
                    emailService.AgregarAdjunto(adjunto);

                    string nombrePDF = Path.GetFileName(rutaPDF);

                    ArchivosUsuario archivoU = new ArchivosUsuario
                    {
                        idUser = userId,
                        idEvento = eventoId,
                        nameArchivo = nombrePDF
                    };

                    negocioAU.Agregar(archivoU);
                }

                emailService.EnviarEmail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}