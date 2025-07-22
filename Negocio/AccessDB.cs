using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data;
using System.Configuration;


namespace Negocio
{
    public class AccessDB
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Lector
        {
            get { return reader; }
        }

        public AccessDB()
        {
            // Usar la cadena de conexión desde el archivo de configuración
            string cadenaConection = ConfigurationManager.AppSettings["cadenaConeccion"];
            conection = new SqlConnection(cadenaConection);
            command = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        public void setearParametro(string nombre, object valor) 
        {
            command.Parameters.AddWithValue(nombre, valor);
        }

        public void setearProcedure(string SP)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SP;
        }

        public void ejecutarAccion()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conection.Close();
            }
        }

        public int ejecutarScalar()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                return int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conection.Close();
            }
        }

        public void ejecutarRead()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConnection()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conection.Close();
        }
    }
}
