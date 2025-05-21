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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioEvento negocio = new NegocioEvento();


            if (!IsPostBack)
            {
                List<Evento> evento = negocio.listar();
                rpt_Eventos.DataSource = evento;
                rpt_Eventos.DataBind();

                rpt_Banner.DataSource = evento;
                rpt_Banner.DataBind();
            }
        }

        protected void IrCompraClick(object sender, EventArgs e)
        {
            int valor = int.Parse(((Button)sender).CommandArgument);

            Session["id"] = valor;
            Response.Redirect("Compra.aspx");
        }
    }
}