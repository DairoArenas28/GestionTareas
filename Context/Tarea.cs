using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask.Context
{
    public class Tarea:ConexionDB
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool inactivo { get; set; }

        public static SqlConnection conn = GetConnection();

        private SqlTransaction transaction;

        bool bResultQuery;

        string query;
        /// <summary>
        /// Agrega una nueva tarea a la base de datos con los detalles especificados.
        /// </summary>
        /// <param name="titulo">Título de la tarea.</param>
        /// <param name="descripcion">Descripción de la tarea.</param>
        /// <param name="categoriaId">ID de la categoría a la que pertenece la tarea.</param>
        /// <param name="usuarioId">ID del usuario asignado a la tarea.</param>
        /// <param name="estadoId">ID del estado de la tarea.</param>
        /// <param name="fechaVencimiento">Fecha de vencimiento de la tarea.</param>
        /// <param name="inactivo">Indica si la tarea está activa (0) o inactiva (1).</param>
        /// <returns>
        /// Retorna `true` si la tarea se agregó correctamente, `false` en caso de error.
        /// </returns>
        public bool AgregarTarea(string titulo, string descripcion, int categoriaId, int usuarioId, int estadoId, DateTime fechaVencimiento, int inactivo)
        {
            bool resultado = false; // Variable para almacenar el resultado de la operación

            try
            {
                // Abre la conexión a la base de datos
                conn.Open();

                // Definir la consulta SQL para insertar una nueva tarea
                string query = "INSERT INTO Tareas (titulo, descripcion, categoriaId, usuarioId, estadoId, fechaVencimiento, inactivo) " +
                               "VALUES (@titulo, @descripcion, @categoriaId, @usuarioId, @estadoId, @fechaVencimiento, @inactivo)";

                // Iniciar una transacción para asegurar la consistencia de la operación
                using (transaction = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        // Agregar los parámetros con sus valores correspondientes
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        cmd.Parameters.AddWithValue("@estadoId", estadoId);
                        cmd.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                        cmd.Parameters.AddWithValue("@inactivo", inactivo);

                        // Ejecutar la consulta y obtener el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Verificar si la inserción fue exitosa
                        if (filasAfectadas > 0)
                        {
                            transaction.Commit(); // Confirmar la transacción
                            resultado = true; // Indicar que la operación fue exitosa
                        }
                        else
                        {
                            transaction.Rollback(); // Revertir la transacción en caso de fallo
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores: Mostrar un mensaje de error al usuario
                MessageBox.Show("Error al agregar la tarea: " + e.Message);

                // Si ocurre una excepción, la transacción debe revertirse para evitar inconsistencias
                transaction?.Rollback();
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conn.Close();
            }

            return resultado; // Retornar el resultado de la operación
        }


        /// <summary>
        /// Obtiene todas las tareas activas almacenadas en la base de datos, incluyendo información de categorías, usuarios y estados.
        /// </summary>
        /// <returns>
        /// Retorna un DataSet con la tabla "Tareas":
        /// - Contiene todas las tareas activas (`inactivo <> 1`).
        /// - Incluye información adicional sobre la categoría, usuario y estado asociados a cada tarea.
        /// - Si ocurre un error, retorna un DataSet vacío.
        /// </returns>
        public DataSet ObtenerTareas()
        {
            // Se declara el DataSet antes del try para garantizar su disponibilidad en caso de error
            DataSet ds = new DataSet();

            // Consulta SQL para obtener las tareas junto con su categoría, usuario y estado
            string query = "SELECT t.ID, t.titulo, t.descripcion, t.categoriaId, c.nombre AS nombreCategoria, " +
                           "t.usuarioId, u.nombreUsuario, t.estadoId, e.nombreEstado AS nombreEstado, t.fechaVencimiento " +
                           "FROM Tareas t " +
                           "JOIN Categorias c ON c.ID = t.categoriaId " +
                           "JOIN Usuarios u ON u.ID = t.usuarioId " +
                           "JOIN Estados e ON e.ID = t.estadoId " +
                           "WHERE t.inactivo <> 1";

            try
            {
                // Abrir conexión a la base de datos
                conn.Open();

                // Iniciar una transacción para garantizar la integridad de la consulta
                using (transaction = conn.BeginTransaction())
                {
                    // Crear un adaptador para ejecutar la consulta y llenar el DataSet
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        // Asignar la transacción al comando del adaptador
                        adapter.SelectCommand.Transaction = transaction;

                        // Llenar el DataSet con los resultados de la consulta
                        adapter.Fill(ds, "Tareas");

                        // Confirmar la transacción, ya que la consulta fue exitosa
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores: Mostrar un mensaje con la excepción
                MessageBox.Show("Error al obtener las tareas: " + e.Message);

                // Si ocurre una excepción, se revierte la transacción para evitar inconsistencias
                transaction?.Rollback();
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conn.Close();
            }

            // Retornar el DataSet con los datos obtenidos o vacío en caso de error
            return ds;
        }


        /// <summary>
        /// Actualiza una tarea en la base de datos con los nuevos valores proporcionados.
        /// </summary>
        /// <param name="tareaId">ID de la tarea a actualizar.</param>
        /// <param name="titulo">Nuevo título de la tarea.</param>
        /// <param name="descripcion">Nueva descripción de la tarea.</param>
        /// <param name="categoriaId">Nuevo ID de la categoría asociada.</param>
        /// <param name="usuarioId">Nuevo ID del usuario asignado.</param>
        /// <param name="estadoId">Nuevo estado de la tarea.</param>
        /// <param name="fechaVencimiento">Nueva fecha de vencimiento.</param>
        /// <param name="inactivo">Indica si la tarea está activa (0) o inactiva (1).</param>
        /// <returns>
        /// Retorna `true` si la tarea se actualizó correctamente, `false` en caso de error.
        /// </returns>
        public bool ActualizarTarea(int tareaId, string titulo, string descripcion, int categoriaId, int usuarioId, int estadoId, DateTime fechaVencimiento, int inactivo)
        {
            bool resultado = false; // Variable para almacenar el estado de la operación

            try
            {
                // Abre la conexión a la base de datos
                conn.Open();

                // Consulta SQL para actualizar la tarea
                string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, categoriaId = @categoriaId, " +
                               "usuarioId = @usuarioId, estadoId = @estadoId, fechaVencimiento = @fechaVencimiento, inactivo = @inactivo " +
                               "WHERE id = @id"; // Se asegura de actualizar la tarea correcta

                // Iniciar transacción para mantener la integridad de la operación
                using (transaction = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        // Agregar los parámetros con sus respectivos valores
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        cmd.Parameters.AddWithValue("@estadoId", estadoId);
                        cmd.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                        cmd.Parameters.AddWithValue("@inactivo", inactivo);

                        // Se asigna el ID de la tarea a actualizar
                        cmd.Parameters.AddWithValue("@id", tareaId);

                        // Ejecutar la consulta y obtener el número de filas afectadas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Si al menos una fila fue actualizada, se confirma la transacción
                        if (filasAfectadas > 0)
                        {
                            transaction.Commit();
                            resultado = true; // Indicar que la operación fue exitosa
                        }
                        else
                        {
                            transaction.Rollback(); // Revertir en caso de que no se haya actualizado ninguna fila
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores: mostrar mensaje y hacer rollback si es necesario
                MessageBox.Show("Error al actualizar la tarea: " + e.Message);
                transaction?.Rollback();
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conn.Close();
            }

            return resultado; // Retorna el resultado de la operación
        }


        /// <summary>
        /// Actualiza el estado de inactividad de una tarea en la base de datos.
        /// </summary>
        /// <param name="inactivo">El nuevo estado de inactividad (1 para inactiva, 0 para activa).</param>
        /// <param name="id">El ID de la tarea a actualizar.</param>
        /// <returns>
        /// Retorna `true` si la actualización fue exitosa, `false` en caso de error.
        /// </returns>
        public bool InactivoTarea(int inactivo, int id)
        {
            bool resultado = false; // Variable para almacenar el resultado de la operación
            string query = "UPDATE Tareas SET inactivo = @inactivo WHERE ID = @id";

            try
            {
                // Abrir la conexión a la base de datos
                conn.Open();

                // Iniciar transacción para garantizar la integridad de la operación
                using (transaction = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        // Asignar valores a los parámetros
                        cmd.Parameters.AddWithValue("@inactivo", inactivo);
                        cmd.Parameters.AddWithValue("@id", id);

                        // Ejecutar la consulta y verificar si se actualizaron filas
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            transaction.Commit(); // Confirmar la transacción
                            resultado = true; // Operación exitosa
                        }
                        else
                        {
                            transaction.Rollback(); // Deshacer la transacción si no se modificó ninguna fila
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores
                MessageBox.Show("Error al editar el registro: " + e.Message);
                transaction?.Rollback(); // Asegurar que la transacción se revierta en caso de error
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conn.Close();
            }

            return resultado; // Retorna el resultado de la operación
        }
    }
}
