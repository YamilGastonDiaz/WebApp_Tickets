using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string status = Request.QueryString["status"];
                int id = int.Parse(Request.QueryString["compraId"]);
               

                if (!string.IsNullOrEmpty(status))
                {
                    if (status == "success")
                    {                                
                        lblResultado.Text = "¡Compra realizada con éxito!";
                    }
                    else
                    {
                        lblResultado.Text = "Hubo un problema con la compra.";
                    }
                }
            }
        }
    }
}