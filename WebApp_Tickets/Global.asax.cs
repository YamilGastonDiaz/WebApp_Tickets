using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Dominio;
using MercadoPago.Config;
using Microsoft.AspNetCore.Identity;
using Negocio;

namespace WebApp_Tickets
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                MercadoPagoConfig.AccessToken = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
        protected void Session_Start(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            negocio.VerificarYRegistrarAdmin();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}