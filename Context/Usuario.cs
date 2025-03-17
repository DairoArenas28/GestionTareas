using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask.Context
{
    public class Usuario : ConexionDB
    {
        // Propiedades
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; private set; } // Encapsulada para mayor seguridad
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public static SqlConnection conn = GetConnection();

        /// <summary>
        /// Constructor sin parámetros de la clase Usuario.
        /// Inicializa la propiedad FechaCreacion con la fecha y hora actual.
        /// </summary>
        public Usuario()
        {
            FechaCreacion = DateTime.Now; // Se asigna la fecha y hora actual al momento de crear el objeto
        }

        public Usuario(string nombreUsuario, string contrasena, string correo)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Correo = correo;
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Valida si un usuario existe en la base de datos con el nombre de usuario y contraseña proporcionados.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario a validar.</param>
        /// <param name="contrasenaUsuario">La contraseña asociada al usuario.</param>
        /// <returns>
        /// Retorna un valor booleano:  
        /// - `true` si existe un usuario con las credenciales proporcionadas.  
        /// - `false` si no se encuentra un usuario con esas credenciales o si ocurre un error.  
        /// </returns>
        public bool UsuarioValidacion(string nombreUsuario, string contrasenaUsuario)
        {
            // Consulta SQL para verificar la existencia del usuario en la base de datos
            string query = "SELECT ID, nombreUsuario, correo, contrasena FROM Usuarios WHERE nombreUsuario = @nombre AND contrasena = @contrasena";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Se agregan los parámetros con los valores proporcionados
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasenaUsuario);

                try
                {
                    // Se abre la conexión a la base de datos
                    conn.Open();

                    // Se ejecuta la consulta y se obtiene el resultado
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows) // Si la consulta devuelve filas, el usuario existe
                        {
                            return true; // Retorna `true` indicando que el usuario es válido
                        }
                    }
                }
                catch (Exception e)
                {
                    // En caso de error, se muestra un mensaje con la descripción del error
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    // Se cierra la conexión con la base de datos
                    conn.Close();
                }
            }

            return false; // Retorna `false` si el usuario no existe o si ocurrió un error
        }


        /// <summary>
        /// Obtiene una lista de usuarios de la base de datos con el nombre de usuario y contraseña especificados.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario a buscar.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>
        /// Retorna una lista de objetos `Usuario` que coincidan con las credenciales proporcionadas.  
        /// - Si se encuentra uno o más usuarios, retorna la lista con los datos obtenidos.  
        /// - Si no hay coincidencias, retorna una lista vacía.  
        /// </returns>
        public List<Usuario> ObtenerUsuario(string nombreUsuario, string contrasena)
        {
            // Consulta SQL para obtener los usuarios que coincidan con los parámetros
            string query = "SELECT * FROM Usuarios WHERE nombreUsuario = @nombreUsuario AND contrasena = @contrasena";

            // Se crea una lista para almacenar los usuarios encontrados
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Se agregan los parámetros a la consulta
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    // Se ejecuta la consulta y se almacena el resultado en un lector de datos
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Se verifica si la consulta devuelve filas
                        if (reader.HasRows)
                        {
                            // Se recorren todas las filas obtenidas
                            while (reader.Read())
                            {
                                // Se crea un objeto `Usuario` con los datos obtenidos de la base de datos
                                Usuario usuario = new Usuario
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    NombreUsuario = reader.GetString(reader.GetOrdinal("nombreUsuario")),
                                    Contrasena = reader.GetString(reader.GetOrdinal("contrasena")),
                                    Correo = reader.GetString(reader.GetOrdinal("correo")),
                                    FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fechaCreacion"))
                                };

                                // Se agrega el usuario a la lista
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // En caso de error, se muestra el mensaje en la consola
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Se cierra la conexión con la base de datos
                conn.Close();
            }

            // Se retorna la lista de usuarios encontrados (o una lista vacía si no hay coincidencias)
            return usuarios;
        }


    }
}
