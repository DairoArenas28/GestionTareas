using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask.Context
{
    public class Categoria:ConexionDB
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        bool bResultQuery;

        public static SqlConnection conn = GetConnection();

        private SqlTransaction transaction;

        //bool bResultQuery;

        string query;

        /// <summary>
        /// Obtiene todos los registros de la tabla 'Categorias' que no están inactivos.
        /// </summary>
        /// <returns>
        /// Retorna un objeto de tipo DataSet que contiene los registros obtenidos de la consulta.
        /// El DataSet contiene una tabla llamada 'Categorias' con los siguientes campos:
        /// - ID: El identificador único de la categoría.
        /// - nombre: El nombre de la categoría.
        /// - descripcion: La descripción de la categoría.
        /// - fechaCreacion: La fecha de creación de la categoría.
        /// </returns>
        public DataSet ObtenerCategorias()
        {
            DataSet ds = new DataSet(); // ✅ Declarar el DataSet antes del try
            query = "SELECT ID, nombre, descripcion, fechaCreacion FROM Categorias WHERE inactivo <> 1";

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                // Inicia una transacción para asegurar que la consulta se ejecute de manera atómica
                transaction = conn.BeginTransaction();

                // Crea un adaptador de datos para ejecutar la consulta y llenar el DataSet
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Asigna la transacción al comando del adaptador
                adapter.SelectCommand.Transaction = transaction;

                // Ejecuta la consulta y llena el DataSet con los resultados
                adapter.Fill(ds, "Categorias"); // Llenar el DataSet
            }
            catch (Exception e)
            {
                // Si ocurre un error, se muestra un mensaje de error en la consola
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos en el bloque 'finally' para garantizar que se cierre siempre
                conn.Close();
            }

            // Retorna el DataSet con los resultados obtenidos de la consulta
            return ds; // ✅ Ahora el DataSet se retorna con datos
        }



        /// <summary>
        /// Agrega una nueva categoría a la tabla 'Categorias' en la base de datos.
        /// </summary>
        /// <param name="nombre">El nombre de la categoría que se va a agregar.</param>
        /// <param name="descripcion">La descripción de la categoría que se va a agregar.</param>
        /// <param name="inactivo">Valor que indica si la categoría está activa o inactiva (1 para inactiva, 0 para activa).</param>
        /// <returns>
        /// Retorna un valor booleano:
        /// - `true` si la categoría se agregó correctamente a la base de datos.
        /// - `false` si hubo un error o no se insertaron filas en la base de datos.
        /// </returns>
        public bool AgregarCategoria(string nombre, string descripcion, int inactivo)
        {
            bool resultado = false;

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                // Consulta SQL para insertar los valores en la tabla 'Categorias'
                string query = "INSERT INTO Categorias (nombre, descripcion, inactivo) " +
                               "VALUES (@nombre, @descripcion, @inactivo)";

                // Utiliza un SqlCommand para ejecutar la consulta
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Se agregan los parámetros con sus respectivos valores
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@inactivo", inactivo);

                    // Ejecuta la consulta y obtiene el número de filas afectadas
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Si se insertaron filas, la operación fue exitosa
                    if (filasAfectadas > 0)
                    {
                        resultado = true; // Se marca el resultado como exitoso
                    }
                }
            }
            catch (Exception e)
            {
                // En caso de error, muestra un mensaje con el detalle del error
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos al final de la operación
                conn.Close();
            }

            // Retorna el resultado de la operación
            return resultado;
        }


        /// <summary>
        /// Actualiza los detalles de una categoría existente en la tabla 'Categorias' de la base de datos.
        /// </summary>
        /// <param name="categoriaId">El ID de la categoría que se desea actualizar.</param>
        /// <param name="nombre">El nuevo nombre de la categoría.</param>
        /// <param name="descripcion">La nueva descripción de la categoría.</param>
        /// <param name="inactivo">El nuevo estado de la categoría (1 para inactiva, 0 para activa).</param>
        /// <returns>
        /// Retorna un valor booleano:
        /// - `true` si la categoría fue actualizada correctamente.
        /// - `false` si hubo un error o no se actualizó ninguna fila en la base de datos.
        /// </returns>
        public bool ActualizarCategoria(int categoriaId, string nombre, string descripcion, int inactivo)
        {
            bool resultado = false;

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                // Consulta SQL para actualizar los datos de la categoría
                string query = "UPDATE Categorias SET nombre = @nombre, descripcion = @descripcion, inactivo = @inactivo " +
                               "WHERE ID = @id";  // 'ID' es la clave primaria de la tabla Categorias

                // Utiliza un SqlCommand para ejecutar la consulta
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Se agregan los parámetros con sus respectivos valores
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@inactivo", inactivo);
                    cmd.Parameters.AddWithValue("@id", categoriaId); // El ID de la categoría que se desea actualizar

                    // Ejecuta la consulta y obtiene el número de filas afectadas
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Si se actualizaron filas, la operación fue exitosa
                    if (filasAfectadas > 0)
                    {
                        resultado = true; // Se marca el resultado como exitoso
                    }
                }
            }
            catch (Exception e)
            {
                // En caso de error, muestra un mensaje con el detalle del error
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conn.Close();
            }

            // Retorna el resultado de la operación
            return resultado;
        }


        /// <summary>
        /// Actualiza el estado de inactividad de una categoría específica en la base de datos.
        /// </summary>
        /// <param name="categoriaId">El ID de la categoría cuyo estado de inactividad se desea actualizar.</param>
        /// <param name="inactivo">El nuevo estado de inactividad (1 para inactiva, 0 para activa).</param>
        /// <returns>
        /// Retorna un valor booleano:
        /// - `true` si la actualización fue exitosa y la categoría se marcó correctamente como activa o inactiva.
        /// - `false` si hubo un error durante la actualización o si no se actualizó ninguna fila en la base de datos.
        /// </returns>
        public bool InactivoCategoria(int categoriaId, int inactivo)
        {
            // Consulta SQL para actualizar el estado de inactividad de la categoría
            query = "UPDATE Categorias SET inactivo = @inactivo WHERE ID = @id";

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                // Inicia una transacción para asegurar que la operación sea atómica
                using (transaction = conn.BeginTransaction())
                {
                    // Ejecuta la consulta de actualización dentro de la transacción
                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        // Se agregan los parámetros con sus respectivos valores
                        cmd.Parameters.AddWithValue("@inactivo", inactivo);
                        cmd.Parameters.AddWithValue("@id", categoriaId);

                        // Ejecuta la consulta y obtiene el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Si se actualizó al menos una fila, se confirma la transacción
                        if (filasAfectadas > 0)
                        {
                            transaction.Commit();  // Confirmar la transacción
                            bResultQuery = true;   // Operación exitosa
                        }
                        else
                        {
                            // Si no se actualizó ninguna fila, se revierte la transacción
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Si ocurre un error, muestra el mensaje de error
                MessageBox.Show("Error al editar el registro: " + e.Message);
                bResultQuery = false;  // Operación fallida
            }
            finally
            {
                // Se cierra la conexión a la base de datos
                conn.Close();
            }

            // Retorna el resultado de la operación
            return bResultQuery;
        }

    }

}
