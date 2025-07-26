using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEvento
    {
        private AccessDB datos = new AccessDB();
        public List<Evento> listar()
        {
            List<Evento> lista = new List<Evento>();

            try
            {
                datos.setearConsulta("SELECT Evento_Id, Evento_Nombre, Descripcion, Evento_Lugar, Evento_Fecha, Evento_Direccion, TotalEntrada, Precio, Evento_Imagen FROM Eventos");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Evento aux = new Evento();

                    aux.id = (int)datos.Lector["Evento_Id"];
                    aux.name = (string)datos.Lector["Evento_Nombre"];
                    aux.description = (string)datos.Lector["Descripcion"];
                    aux.locale = (string)datos.Lector["Evento_Lugar"];
                    aux.fecha = (DateTime)datos.Lector["Evento_Fecha"];
                    aux.direction = (string)datos.Lector["Evento_Direccion"];
                    aux.totalTickt = (int)datos.Lector["TotalEntrada"];
                    aux.price = (decimal)datos.Lector["Precio"];
                    aux.image = (string)datos.Lector["Evento_Imagen"];

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
        public Evento buscarEvento(int id)
        {
            try
            {
                Evento evento = new Evento();
                List<Evento> listaEventos = listar();
                foreach (Evento evt in listaEventos)
                {
                    if (evt.id == id)
                    {
                        evento = evt;
                    }
                }
                return evento;
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
        public Evento Obtener(int id)
        {
            Evento evento = new Evento();
            try
            {
                datos.setearConsulta("SELECT Evento_Nombre, Descripcion, Evento_Lugar, Evento_Fecha, Evento_Direccion, TotalEntrada, Precio, Evento_Imagen FROM Eventos WHERE Evento_Id = @id");
                datos.setearParametro("@Id", id);

                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    evento.name = (string)datos.Lector["Evento_Nombre"];
                    evento.description = (string)datos.Lector["Descripcion"];
                    evento.locale = (string)datos.Lector["Evento_Lugar"];
                    evento.fecha = (DateTime)datos.Lector["Evento_Fecha"];
                    evento.direction = (string)datos.Lector["Evento_Direccion"];
                    evento.totalTickt = (int)datos.Lector["TotalEntrada"];
                    evento.price = (decimal)datos.Lector["Precio"];
                    evento.image = (string)datos.Lector["Evento_Imagen"];
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

            return evento;
        }
        public void Agregar(Evento evento)
        {
            
            try
            {
                datos.setearConsulta("INSERT INTO Eventos (Evento_Nombre, Descripcion, Evento_Fecha, Evento_Lugar, Evento_Direccion, TotalEntrada, Precio, Evento_Imagen) " +
                                     "VALUES (@Nombre, @Descripcion, @Fecha, @Lugar, @Direccion, @Total, @Precio, @Img); " +
                                     "SELECT SCOPE_IDENTITY();");
              
                datos.setearParametro("@Nombre", evento.name);
                datos.setearParametro("@Descripcion", evento.description);
                datos.setearParametro("@Fecha", evento.fecha);
                datos.setearParametro("@Lugar", evento.locale);
                datos.setearParametro("@Direccion", evento.direction);                
                datos.setearParametro("@Total", evento.totalTickt);
                datos.setearParametro("Precio", evento.price);
                datos.setearParametro("Img", evento.image);

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
        public void Modificar(Evento evento)
        {
            try
            {
                datos.setearConsulta("UPDATE Eventos SET Evento_Nombre = @Nombre, Descripcion = @Descripcion, Evento_Fecha = @Fecha, Evento_Lugar = @Lugar, Evento_Direccion = @Direccion, TotalEntrada = @Total, Precio = @Precio, Evento_Imagen = @Img  WHERE Evento_Id = @Id");
                
                datos.setearParametro("@Nombre", evento.name);
                datos.setearParametro("@Descripcion", evento.description);
                datos.setearParametro("@Fecha", evento.fecha);                
                datos.setearParametro("@Lugar", evento.locale);
                datos.setearParametro("@Direccion", evento.direction);
                datos.setearParametro("@Total", evento.totalTickt);
                datos.setearParametro("@Precio", evento.price);
                datos.setearParametro("Img", evento.image);
                datos.setearParametro("@Id", evento.id);

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
        public void Baja(int id)
        {
            try
            { 
                datos.setearConsulta("UPDATE Eventos set Estado = 0 WHERE  Evento_Id = @id");
                datos.setearParametro("@id", id);
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
    }
}
