using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Negocio
{
    public class NegocioUsuario
    {
        private AccessDB datos = new AccessDB();
        private readonly PasswordHasher<Usuario> passHasher;
        public NegocioUsuario()
        {
            passHasher = new PasswordHasher<Usuario>();
        }
        public List<Usuario> listarUser()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("SELECT Usuario_Id, Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento FROM Usuarios");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.idUser = (int)datos.Lector["Usuario_Id"];
                    aux.name = (string)datos.Lector["Nombre"];
                    aux.lastname = (string)datos.Lector["Apellido"];
                    aux.dni = (string)datos.Lector["Dni"];
                    aux.email = (string)datos.Lector["Email"];
                    aux.birthdate = (DateTime)datos.Lector["FechaNacimiento"];                   
                    aux.numerphone = (string)datos.Lector["Telefono"];

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
        public int Registro(Usuario usuario)
        {
            try
            {
                //Hashear la contraseña antes de guardarla en la base de datos
                string hashedPassword = passHasher.HashPassword(usuario, usuario.password);

                datos.setearProcedure("SP_INSERTAR_USER");

                datos.setearParametro("@nombre", usuario.name);
                datos.setearParametro("@apellido", usuario.lastname);
                datos.setearParametro("@dni", usuario.dni);
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@telefono", usuario.numerphone);
                datos.setearParametro("@fecha", usuario.birthdate);
                datos.setearParametro("@pass", hashedPassword);

                return datos.ejecutarScalar();

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
        public bool Logear(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("SELECT Usuario_Id, Email, TipoUsuario, Contrasenia FROM Usuarios WHERE Email = @email"); // no olvidar colocar el Estado = 1                
                datos.setearParametro("@email", usuario.email);
                
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    usuario.idUser = (int)datos.Lector["Usuario_Id"];
                    usuario.email = (string)datos.Lector["Email"];
                    usuario.TipoUser = (int)(datos.Lector["TipoUsuario"]) == 1 ? TipoUser.ADMIN : TipoUser.CLIENTE;

                    //Obtener la contraseña hasheada desde la base de datos
                    string hashedPassword = (string)datos.Lector["Contrasenia"];

                    //Verificar si la contraseña ingresada coincide con el hash
                    var resultado = passHasher.VerifyHashedPassword(usuario, hashedPassword, usuario.password);

                    return resultado == PasswordVerificationResult.Success;
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
            return false;
        }
        public void Modificar(Usuario usuario) 
        {
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, Dni = @dni, Email = @email, Telefono = @telefono, FechaNacimiento = @fechaNacimiento WHERE Usuario_Id = @id");
                datos.setearParametro("@nombre", usuario.name);
                datos.setearParametro("@apellido", usuario.lastname);
                datos.setearParametro("@dni", usuario.dni);
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@telefono", usuario.numerphone);
                datos.setearParametro("@fechaNacimiento", usuario.birthdate);
                datos.setearParametro("@id", usuario.idUser);

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
        public void ModificarPass(Usuario usuario)
        {
            try
            {
                //Hashear la contraseña antes de guardarla en la base de datos
                string hashedPassword = passHasher.HashPassword(usuario, usuario.password);

                datos.setearConsulta("UPDATE Usuarios SET Contrasenia = @Contrasenia WHERE Usuario_Id = @id");
                datos.setearParametro("@Contrasenia", hashedPassword);
                datos.setearParametro("id", usuario.idUser);

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
        public Usuario Obtener(int id)
        {
            Usuario user = new Usuario();

            try
            {
                datos.setearConsulta("SELECT Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento FROM Usuarios WHERE Usuario_Id = @id");
                datos.setearParametro("@Id", id);

                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    user.name = datos.Lector["Nombre"].ToString();
                    user.lastname = datos.Lector["Apellido"].ToString();
                    user.dni = datos.Lector["Dni"].ToString();
                    user.email = datos.Lector["Email"].ToString();
                    user.numerphone = datos.Lector["Telefono"].ToString();
                    user.birthdate = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
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

            return user;
        }
        public void Baja(int id) 
        {
            try
            {
                datos.setearConsulta("UPDATE Usuarios set Estado = 0 WHERE Usuario_Id = @id");
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
