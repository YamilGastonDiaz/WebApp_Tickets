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

                return codigos;
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
        public List<Compra> ListarCompra(int anio)
        {
            List<Compra> lista = new List<Compra>();

            try
            {
                datos.setearConsulta("SELECT Compra_Id, Id_Evento, Id_Usuario, CantidadEntrada, Compra_Fecha, MontoTotal, Estado FROM Compras WHERE YEAR(Compra_Fecha) = @anio AND Estado = 1");
                datos.setearParametro("anio", anio);
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.compraId = (int)datos.Lector["Compra_Id"];
                    aux.eventoId = (int)datos.Lector["Id_Evento"];
                    aux.usuarioId = (int)datos.Lector["Id_Usuario"];
                    aux.cantidad = (int)datos.Lector["CantidadEntrada"];
                    aux.fecha = (DateTime)datos.Lector["Compra_Fecha"];
                    aux.monto = (decimal)datos.Lector["MontoTotal"];

                    lista.Add(aux);
                }
                return lista;
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
    }
}
