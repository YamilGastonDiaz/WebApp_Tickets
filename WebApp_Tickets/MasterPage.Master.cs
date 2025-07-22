using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Tickets
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is WebApp_Tickets.Default ||
                  Page is WebApp_Tickets.Login ||
                  Page is WebApp_Tickets.Registro ||
                  Page is WebApp_Tickets.Detalle ||
                  Page is WebApp_Tickets.Terminos ||
                  Page is WebApp_Tickets.Contacto))
            {
                if (Session["usuario"] == null)
                    Response.Redirect("Login.aspx", false);
            }

            if (!IsPostBack)
            {
                actualizarBtn();
            }
        }

        private void actualizarBtn()
        {
            if (Session["usuario"] != null)
            {
                SignIn.Text = "SIGN OUT";
                Registrarme.Visible = false;

                lbl_Mail.Text = Session["Email"].ToString();
                lbl_Mail.Visible = true;
            }
            else
            {
                SignIn.Text = "SIGN IN";
                Registrarme.Visible = true;

                lbl_Mail.Text = "";
                lbl_Mail.Visible = false;
            }
        }

        protected void SignOut_btn(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Abandon();
                Session.Remove("usuario");

                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }           
        }

        protected void Registro_btn(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}