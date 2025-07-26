using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using Dominio;

namespace Negocio
{
    public class NegocioMercadoPago
    {
        public string CrearPreferencia(string titulo, decimal precio, int cantiad)
        {
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = titulo,
                        Quantity = cantiad,
                        CurrencyId = "ARS",
                        UnitPrice = precio,                        
                    },
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://localhost:44310/ResultadoPago.aspx?estado=success",
                    Failure = "https://localhost:44310/ResultadoPago.aspx?estado=failure",
                    Pending = "https://localhost:44310/ResultadoPago.aspx?estado=pending"
                },
                AutoReturn = "approved",
                ExternalReference = $"ref_{Guid.NewGuid().ToString()}",
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMinutes(10)
            };

            var client = new PreferenceClient();
            var preference = client.Create(request);            

            return preference.SandboxInitPoint;
        }
    }
}
