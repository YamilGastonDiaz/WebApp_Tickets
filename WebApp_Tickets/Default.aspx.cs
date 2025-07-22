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
        List<Evento> listar;
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioEvento negocio = new NegocioEvento();

            if (!IsPostBack)
            {
                listar = negocio.listar();
                rpt_Eventos.DataSource = listar;
                rpt_Eventos.DataBind();

                rpt_Banner.DataSource = listar;
                rpt_Banner.DataBind();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            NegocioEvento negocio = new NegocioEvento();

            listar = negocio.listar();

            // Aplicar filtro
            var filtrados = listar.Where(ev =>
                (!string.IsNullOrEmpty(ev.name) && ev.name.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(ev.locale) && ev.locale.ToLower().Contains(filtro))
            ).ToList();

            // Mostrar resultados filtrados
            rpt_Eventos.DataSource = filtrados;
            rpt_Eventos.DataBind();

            lblSinResultados.Visible = filtrados.Count == 0;
        }
        protected void rpt_DataBoundEventos(object sender, RepeaterItemEventArgs e)
        {
            DateTime fechaEvento = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "fecha"));
            int totalEntradas = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "totalTickt"));

            Button btnComprar = (Button)e.Item.FindControl("btn_Comprar");

            if (btnComprar != null)
            {
                if (fechaEvento <= DateTime.Now)
                {
                    btnComprar.Text = "Finalizado";
                    btnComprar.Enabled = false;
                    btnComprar.CssClass = "btn btn-secondary";
                }
                else if (totalEntradas <= 0)
                {
                    btnComprar.Text = "Agotado";
                    btnComprar.Enabled = false;
                    btnComprar.CssClass = "btn btn-secondary";
                }
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