﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEstadisticas
    {
        private AccessDB datos = new AccessDB();

        public decimal RecaudacionTotal()
        {
            try
            {
                datos.setearConsulta("SELECT ISNULL(SUM(MontoTotal), 0) FROM Compras WHERE Estado = 1");
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    return datos.Lector.GetDecimal(0);
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
            return 0;
        }
        public int UsuariosActivos()
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE Estado = 1 AND TipoUsuario = 2");
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    return datos.Lector.GetInt32(0);
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
            return 0;
        }
        public int UsuariosDadosDeBaja()
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE Estado = 0");
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    return datos.Lector.GetInt32(0);
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
            return 0;
        }
        public List<CompraResumenMensual> ObtenerRecaudacionMensual(int anio)
        {
            List<CompraResumenMensual> lista = new List<CompraResumenMensual>();

            try
            {
                datos.setearConsulta("SELECT DATENAME(MONTH, Compra_Fecha) AS Mes, MONTH(Compra_Fecha) AS NumeroMes, SUM(MontoTotal) AS RecaudacionMensual FROM Compras WHERE Estado = 1 AND YEAR(Compra_Fecha) = @Anio GROUP BY MONTH(Compra_Fecha), DATENAME(MONTH, Compra_Fecha) ORDER BY NumeroMes");
                datos.setearParametro("@Anio", anio);
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    CompraResumenMensual aux = new CompraResumenMensual
                    {
                        mes = datos.Lector.GetString(0),
                        numeroMes = datos.Lector.GetInt32(1),
                        recaudacionMensual = datos.Lector.GetDecimal(2)
                    };
                    lista.Add(aux);
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
            return lista;
        }
        public List<EventoRanking> ObtenerRankingEventos()
        {
            List<EventoRanking> lista = new List<EventoRanking>();

            try
            {
                datos.setearConsulta("SELECT E.Evento_Nombre, SUM(C.CantidadEntrada) AS TotalVendidas FROM Compras C INNER JOIN Eventos E ON C.Id_Evento = E.Evento_Id WHERE C.Estado = 1 GROUP BY E.Evento_Nombre ORDER BY TotalVendidas DESC");

                datos.ejecutarRead();
                while (datos.Lector.Read())
                {
                    EventoRanking aux = new EventoRanking
                    {
                        nombreEvento = datos.Lector.GetString(0),
                        entradasVendidas = datos.Lector.GetInt32(1)
                    };
                    lista.Add(aux);
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
            return lista;
        }
        public List<UsuarioRanking> ObtenerRankingUsuarios()
        {
            List<UsuarioRanking> lista = new List<UsuarioRanking>();

            try
            {
                datos.setearConsulta("SELECT U.Nombre + ' ' + U.Apellido AS NombreCompleto, SUM(C.CantidadEntrada) AS TotalCompradas FROM Compras C INNER JOIN Usuarios U ON C.Id_Usuario = U.Usuario_Id WHERE C.Estado = 1 GROUP BY U.Nombre, U.Apellido ORDER BY TotalCompradas DESC");

                datos.ejecutarRead();
                while (datos.Lector.Read())
                {
                    UsuarioRanking aux = new UsuarioRanking
                    {
                        nombreUsuario = datos.Lector.GetString(0),
                        entradasCompradas = datos.Lector.GetInt32(1)
                    };
                    lista.Add(aux);
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
            return lista;
        }
        public DetalleEvento ObtenerDetalleEvento(string nombreEvento)
        {
            try
            {
                datos.setearConsulta("SELECT E.Evento_Nombre, E.Evento_Fecha, (ISNULL(SUM(C.CantidadEntrada), 0) + E.TotalEntrada) AS TotalOriginal, ISNULL(SUM(C.CantidadEntrada), 0) AS Vendidas, E.TotalEntrada AS NoVendidas, ISNULL(SUM(C.MontoTotal), 0) AS Recaudacion FROM Eventos E LEFT JOIN Compras C ON E.Evento_Id = C.Id_Evento AND C.Estado = 1 WHERE E.Evento_Nombre = @nombre GROUP BY E.Evento_Nombre, E.Evento_Fecha, E.TotalEntrada");

                datos.setearParametro("@nombre", nombreEvento);
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    DetalleEvento aux = new DetalleEvento
                    {
                        nombre = datos.Lector.GetString(0),
                        fecha = datos.Lector.GetDateTime(1),
                        totalEntradas = datos.Lector.GetInt32(2),
                        entradasVendidas = datos.Lector.GetInt32(3),
                        entradasNoVendidas = datos.Lector.GetInt32(4),
                        recaudacion = datos.Lector.GetDecimal(5)
                    };
                    return aux;
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
            return null;
        }
    }
}

