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
            // Crea el objeto de request de la preference
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
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            var preference = client.Create(request);            

            return preference.InitPoint;
        }
    }
}
