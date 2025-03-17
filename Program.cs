using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Inicializa la configuración visual y ejecuta el formulario de inicio de sesión.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita los estilos visuales para la aplicación, mejorando la apariencia de los controles.
            Application.EnableVisualStyles();

            // Asegura que la renderización de texto sea compatible con versiones anteriores de Windows Forms.
            Application.SetCompatibleTextRenderingDefault(false);

            // Crea una instancia del formulario de inicio de sesión.
            FormLogin formMain = new FormLogin();

            // Establece la posición inicial del formulario en el centro de la pantalla.
            formMain.StartPosition = FormStartPosition.CenterScreen;

            // Inicia la ejecución del formulario principal de la aplicación.
            Application.Run(formMain);
        }

    }
}
