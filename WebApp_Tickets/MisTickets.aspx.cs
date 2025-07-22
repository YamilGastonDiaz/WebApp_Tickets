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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario_Id"] != null)
                {
                    int idUsuario = (int)Session["Usuario_Id"];
                    NegocioArchivosUsuario negocioAU = new NegocioArchivosUsuario();
                    List<ArchivosUsuario> archivos = negocioAU.listarPdf(idUsuario);

                    rpt_Tickets.DataSource = archivos;
                    rpt_Tickets.DataBind();
                }
            }
        }
    }
}