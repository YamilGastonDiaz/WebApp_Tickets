using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioArchivosUsuario
    {
        private AccessDB datos = new AccessDB();

        public void Agregar(ArchivosUsuario archivosUsuario)
        {
            try
            {
                datos.setearConsulta("INSERT INTO ArchivosUsuario (Id_Usuario, Id_Evento, NombreArchivo) " +
                                     "VALUES (@Id_Usuario, @Id_Evento, @NombreArchivo); ");

                datos.setearParametro("@Id_Usuario", archivosUsuario.idUser);
                datos.setearParametro("@Id_Evento", archivosUsuario.idEvento);
                datos.setearParametro("@NombreArchivo", archivosUsuario.nameArchivo);

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
        public List<ArchivosUsuario> listarPdf(int usuario)
        {
            List<ArchivosUsuario> listarArchivo = new List<ArchivosUsuario>();
            AccessDB datos = new AccessDB();

            try
            {
                datos.setearConsulta("SELECT au.NombreArchivo, e.Evento_Nombre, e.Evento_Imagen FROM ArchivosUsuario au JOIN Eventos e ON au.Id_Evento = e.Evento_Id WHERE au.Id_Usuario = @Id_Usuario;");
                datos.setearParametro("@Id_Usuario", usuario);

                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    ArchivosUsuario archivo = new ArchivosUsuario
                    {
                        nameArchivo = datos.Lector.GetString(0),
                        EventoNombre = datos.Lector.GetString(1),
                        EventoImagen = datos.Lector.GetString(2)
                    };

                    listarArchivo.Add(archivo);
                }

                return listarArchivo;
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
