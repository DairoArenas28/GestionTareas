using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;

namespace WindowsFormsLoginTask.Context
{
    public class Estado:ConexionDB
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public static SqlConnection conn = GetConnection();

        private SqlTransaction transaction;

        //bool bResultQuery;

        string query;

        /// <summary>
        /// Obtiene todos los estados almacenados en la base de datos.
        /// </summary>
        /// <returns>
        /// Retorna un DataSet con la tabla "Estados":
        /// - Contiene todos los registros de la tabla Estados.
        /// - Si ocurre un error, retorna un DataSet vacío.
        /// </returns>
        public DataSet ObtenerEstados()
        {
            // Se declara el DataSet antes del bloque try para garantizar su disponibilidad en caso de error
            DataSet ds = new DataSet();
            query = "SELECT * FROM Estados"; // Consulta SQL para obtener todos los registros de la tabla Estados

            try
            {
                // Se abre la conexión a la base de datos
                conn.Open();

                // Inicia una transacción para garantizar la integridad de la operación
                using (transaction = conn.BeginTransaction())
                {
                    // Se crea un adaptador para ejecutar la consulta y llenar el DataSet
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        // Se asigna la transacción al comando del adaptador
                        adapter.SelectCommand.Transaction = transaction;

                        // Se llena el DataSet con los resultados de la consulta
                        adapter.Fill(ds, "Estados");

                        // Se confirma la transacción, ya que la operación fue exitosa
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                // En caso de error, se muestra un mensaje con la excepción
                MessageBox.Show("Error al obtener los estados: " + e.Message);

                // Se revierte la transacción en caso de que haya fallado antes de completarse
                transaction?.Rollback();
            }
            finally
            {
                // Se cierra la conexión a la base de datos para liberar recursos
                conn.Close();
            }

            // Se retorna el DataSet con los datos obtenidos o vacío en caso de error
            return ds;
        }

    }
}
