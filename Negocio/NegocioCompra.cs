using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCompra    {      

        public int AgregarCompra(int eventoId, int usuarioId, int cantidad, decimal monto, int estado)
        {
            AccessDB datos = new AccessDB();

            try
			{
                datos.setearConsulta("INSERT INTO Compras (Id_Evento, Id_Usuario, CantidadEntrada, MontoTotal, Estado) VALUES (@Id_Evento, @Id_Usuario, @CantidadEntrada, @MontoTotal, @Estado); " + "SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@Id_Evento", eventoId);
                datos.setearParametro("@Id_Usuario", usuarioId);
                datos.setearParametro("@CantidadEntrada", cantidad);                
                datos.setearParametro("@MontoTotal", monto);
                datos.setearParametro("@Estado", estado);

                int id = datos.ejecutarScalar();

                return id;
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

        public void AgregarEntrada(int compraId, int eventoId, int usuarioId, int estado)
        {
            AccessDB datos = new AccessDB();

            try
            {
                datos.setearConsulta("INSERT INTO Entradas (Id_Compra, Id_Evento, Id_Usuario, Estado) VALUES (@Id_Compra, @Id_Evento, @Id_Usuario, @Estado);");
                datos.setearParametro("@Id_Compra", compraId);
                datos.setearParametro("@Id_Evento", eventoId);
                datos.setearParametro("@Id_Usuario", usuarioId);                
                datos.setearParametro("@Estado", estado);

                datos.ejecutarAccion();            
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

        public List<string> ObtenerCodigo(int usuario)
        {
            List<string> codigos = new List<string>();
            AccessDB datos = new AccessDB();

            try
            {
                datos.setearConsulta("SELECT Codigo FROM Entradas as E INNER JOIN Compras as C ON E.Id_Compra = C.Compra_Id WHERE C.Id_Usuario = @idUsuario AND C.Compra_Id = (SELECT MAX(Compra_Id) FROM Compras WHERE Id_Usuario = @idUsuario);");
                datos.setearParametro("@idUsuario", usuario);

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

        }
    }
}
