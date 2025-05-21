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

                    mostrarEvento.Add(negocio.buscarEvento(id));

                    rpt_Name.DataSource = mostrarEvento;
                    rpt_Name.DataBind();

                    rpt_Hora.DataSource = mostrarEvento;
                    rpt_Hora.DataBind();

                    rpt_Price.DataSource = mostrarEvento;
                    rpt_Price.DataBind();
                }
            }
        }

        private int total = 0;
        private decimal totalFinal = 0;

        protected void Decrementar_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                int id = (int)Session["id"];

                NegocioEvento negocio = new NegocioEvento();
                Evento evento = negocio.buscarEvento(id);

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
            Evento evento = negocio.buscarEvento(id);

            total = int.Parse(lbl_Contar.Text);
            if (total < 5)
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
            NegocioCompra negocioC = new NegocioCompra();
            NegocioMercadoPago negocioMP = new NegocioMercadoPago();
            EntradaQR entradaQr = new EntradaQR();
            EmailService email = new EmailService();

            string asunto = "Entrada para el Evento";
            string body = "Hola, aquí tienes tu entrada para el evento. Gracias por tu compra!!!";

            try
            {
                int cantidad = int.Parse(lbl_Cantidad.Text);

                if (AceptarTerminos() && cantidad > 0)
                {
                    int id = (int)Session["id"];
                    int idU = (int)Session["Usuario_Id"];
                    string mail = (string)Session["email"];
                    Evento evento = negocioE.buscarEvento(id);

                    // Datos de la compra                    

                    string nombre = evento.name.ToString();
                    string fecha = evento.fecha.ToString("dddd, dd MMMM yyyy");
                    string lugar = evento.locale.ToString();
                    string direccion = evento.direction.ToString();                    
                    int eventoId = id;
                    int UserId = idU;
                    decimal monto = decimal.Parse(lbl_TicketPrecio.Text);//para la preferencia
                    decimal total = decimal.Parse(lbl_Total.Text);//para la compra

                    // Crear la preferencia                    
                    string checkoutUrl = negocioMP.CrearPreferencia(nombre, monto, cantidad);                                     
                    
                    //Response.Write("<script> window.open( '" + checkoutUrl + "','_blank' ); </script>");
                    //Response.End();

                    /*string status = Request.QueryString["status"];*/

                    /* if (status == "success")
                     {*/
                    // Registrar la compra
                    int compraId = negocioC.AgregarCompra(eventoId, UserId, cantidad, total, 1);

                    for (int i = 0; i < cantidad; i++)
                    {
                        negocioC.AgregarEntrada(compraId, eventoId, UserId, 1);
                    }

                    //Obtener los códigos de las entradas
                    List<string> entrada = negocioC.ObtenerCodigo(UserId);

                    //Crear la instancia de EmailService
                    EmailService emailService = new EmailService();

                    // Armar el correo
                    emailService.ArmarEmail(mail, asunto, body);

                    foreach (string codigo in entrada)
                    {
                        //Generar PDF en memoria
                        byte[] pdfByte = entradaQr.GenerarPDF(nombre, fecha, lugar, direccion, codigo);

                        //Crear un MemoryStream para el archivo PDF
                        MemoryStream pdfStream = new MemoryStream(pdfByte);

                        // Crear el adjunto
                        Attachment adjunto = new Attachment(pdfStream, $"{codigo}.pdf", "application/pdf");

                        // Agregar cada archivo PDF como adjunto
                        emailService.AgregarAdjunto(adjunto); 
                    }

                    //Enviar el correo
                    emailService.EnviarEmail();

                    /*}*/
                }
                else
                {
                    lbl_Chek.Text = "Debe aceptar términos y condiciones";
                    lbl_Chek.Visible = true;
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

