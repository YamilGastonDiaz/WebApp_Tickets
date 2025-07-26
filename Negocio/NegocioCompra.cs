using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCompra
    {
        private AccessDB datos = new AccessDB();
        public int RegistrarCompraConEntradas(int eventoId, int usuarioId, int cantidad, decimal monto)
        {
            try
            {
                datos.setearProcedure("SP_RegistrarCompraConEntradas");
                datos.setearParametro("@Id_Evento", eventoId);
                datos.setearParametro("@Id_Usuario", usuarioId);
                datos.setearParametro("@CantidadEntrada", cantidad);
                datos.setearParametro("@MontoTotal", monto);

                int compraId = datos.ejecutarScalar();
                return compraId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConnection();
            }
        }
        public List<string> ObtenerCodigoPorCompra(int compraId)
        {
            List<string> codigos = new List<string>();
            AccessDB datos = new AccessDB();

            try
            {
                datos.setearConsulta(@"SELECT Codigo FROM Entradas WHERE Id_Compra = @compraId;");
                datos.setearParametro("@compraId", compraId);

                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    codigos.Add(datos.Lector["Codigo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConnection();
            }
            return codigos;
        }
    }
}
