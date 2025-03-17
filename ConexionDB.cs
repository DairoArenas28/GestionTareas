using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask
{
    public class ConexionDB
    {
        /// <summary>
        /// Cadena de conexión estática que obtiene la configuración de la conexión desde el archivo de configuración.
        /// </summary>
        private static readonly string conexionString = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;

        /// <summary>
        /// Obtiene una nueva instancia de una conexión a la base de datos utilizando la cadena de conexión configurada.
        /// </summary>
        /// <returns>Una nueva conexión SqlConnection utilizando la cadena de conexión configurada.</returns>
        public static SqlConnection GetConnection()
        {
            // Muestra en la consola la cadena de conexión utilizada (para fines de depuración o verificación).
            Console.WriteLine(conexionString);

            // Crea y retorna una nueva instancia de SqlConnection con la cadena de conexión configurada.
            return new SqlConnection
            (
                conexionString // Utiliza la cadena de conexión obtenida de la configuración
            );
        }
    }
}
