using System;
using System.Collections.Generic;
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
                MercadoPagoConfig.AccessToken = "APP_USR-6253345231951666-122201-f87b3f3083e97eab9ca39cccdea0f63d-2175041084";
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