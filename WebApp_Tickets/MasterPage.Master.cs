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
            }
            else
            {
                SignIn.Text = "SIGN IN";
                Registrarme.Visible = true;
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