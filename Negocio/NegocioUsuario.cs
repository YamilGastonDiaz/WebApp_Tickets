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
        private readonly PasswordHasher<Usuario> passHasher;

        public NegocioUsuario()
        {
            passHasher = new PasswordHasher<Usuario>();
        }

        public List<Usuario> listarUser()
        {
            AccessDB datos = new AccessDB();
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

        public void VerificarYRegistrarAdmin()
        {
            AccessDB dato = new AccessDB();

            try
            {
                // Verificar si ya existe un administrador en la base de datos
                dato.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE TipoUsuario = 1");
                int count = (int)dato.ejecutarScalar();

                // Si no existe un administrador, proceder a crear uno
                if (count == 0)
                {
                    string adminEmail = "admin@dominio.com";  // Correo del admin
                    string adminPassword = "ContraseniaSeguraAdmin";  // Contraseña del admin

                    // Crear un usuario de tipo admin
                    Usuario adminUsuario = new Usuario
                    {
                        name = "Admin",
                        lastname = "Admin",
                        dni = "12345678",  // Asegúrate de asignar un DNI válido
                        email = adminEmail,
                        numerphone = "12345678",  // Teléfono de contacto
                        birthdate = DateTime.Now.Date,  // Fecha de nacimiento actual
                        password = adminPassword,  // Contraseña que será hasheada
                        TipoUser = (TipoUser)1
                    };

                    // Hashear la contraseña antes de guardarla
                    var passHasher = new PasswordHasher<Usuario>();
                    string hashedPassword = passHasher.HashPassword(adminUsuario, adminPassword);

                    // Insertar el admin en la base de datos
                    dato.setearConsulta("INSERT INTO Usuarios (Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento, Contrasenia, TipoUsuario) VALUES (@nombre, @apellido, @dni, @email, @telefono, @fechaNacimiento, @pass, @tipo)");
                    dato.setearParametro("@nombre", adminUsuario.name);
                    dato.setearParametro("@apellido", adminUsuario.lastname);
                    dato.setearParametro("@dni", adminUsuario.dni);
                    dato.setearParametro("@email", adminUsuario.email);
                    dato.setearParametro("@telefono", adminUsuario.numerphone);
                    dato.setearParametro("@fechaNacimiento", adminUsuario.birthdate);
                    dato.setearParametro("@pass", hashedPassword);
                    dato.setearParametro("tipo", (int)adminUsuario.TipoUser);
                    dato.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConnection();
            }
        }

        public int Registro(Usuario usuario)
        {
            AccessDB dato = new AccessDB();

            try
            {
                //Hashear la contraseña antes de guardarla en la base de datos
                string hashedPassword = passHasher.HashPassword(usuario, usuario.password);


                dato.setearProcedure("SP_INSERTAR_USER");

                dato.setearParametro("@nombre", usuario.name);
                dato.setearParametro("@apellido", usuario.lastname);
                dato.setearParametro("@dni", usuario.dni);
                dato.setearParametro("@email", usuario.email);
                dato.setearParametro("@telefono", usuario.numerphone);
                dato.setearParametro("@fecha", usuario.birthdate);
                dato.setearParametro("@pass", hashedPassword);

                return dato.ejecutarScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConnection();
            }
        }

        public bool Logear(Usuario usuario)
        {
            AccessDB dato = new AccessDB();

            try
            {
                dato.setearConsulta("SELECT Usuario_Id, Email, TipoUsuario, Contrasenia FROM Usuarios WHERE Email = @email");                
                dato.setearParametro("@email", usuario.email);
                
                dato.ejecutarRead();

                while (dato.Lector.Read())
                {
                    usuario.idUser = (int)dato.Lector["Usuario_Id"];
                    usuario.email = (string)dato.Lector["Email"];
                    usuario.TipoUser = (int)(dato.Lector["TipoUsuario"]) == 1 ? TipoUser.ADMIN : TipoUser.CLIENTE;

                    //Obtener la contraseña hasheada desde la base de datos
                    string hashedPassword = (string)dato.Lector["Contrasenia"];

                    //Verificar si la contraseña ingresada coincide con el hash
                    var resultado = passHasher.VerifyHashedPassword(usuario, hashedPassword, usuario.password);

                    return resultado == PasswordVerificationResult.Success;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConnection();
            }
        }

        public void Modificar(Usuario usuario) 
        {
            AccessDB dato = new AccessDB();

            try
            {
                dato.setearConsulta("UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, Dni = @dni, Email = @email, Telefono = @telefono, FechaNacimiento = @fechaNacimiento WHERE Usuario_Id = @id");
                dato.setearParametro("@nombre", usuario.name);
                dato.setearParametro("@apellido", usuario.lastname);
                dato.setearParametro("@dni", usuario.dni);
                dato.setearParametro("@email", usuario.email);
                dato.setearParametro("@telefono", usuario.numerphone);
                dato.setearParametro("@fechaNacimiento", usuario.birthdate);
                dato.setearParametro("@id", usuario.idUser);

                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.cerrarConnection();
            }
        }

        public Usuario Obtener(int id)
        {
            AccessDB dato = new AccessDB();
            Usuario user = new Usuario();

            try
            {
                dato.setearConsulta("SELECT Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento FROM Usuarios WHERE Usuario_Id = @id");
                dato.setearParametro("@Id", id);

                dato.ejecutarRead();

                if (dato.Lector.Read())
                {
                    user.name = dato.Lector["Nombre"].ToString();
                    user.lastname = dato.Lector["Apellido"].ToString();
                    user.dni = dato.Lector["Dni"].ToString();
                    user.email = dato.Lector["Email"].ToString();
                    user.numerphone = dato.Lector["Telefono"].ToString();
                    user.birthdate = DateTime.Parse(dato.Lector["FechaNacimiento"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                dato.cerrarConnection();
            }

            return user;
        }

        public void Baja(int id) 
        {
            AccessDB dato = new AccessDB();

            try
            {
                dato.setearConsulta("UPDATE Usuarios set Estado = 0 WHERE Usuario_Id = @id");
                dato.setearParametro("@id", id);

                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                dato.cerrarConnection();
            }
        }
    }
}
