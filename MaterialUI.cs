using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.MaterialUI.MaterialSkinUI
{
    public class MaterialSkinUI
    {
        /// <summary>
        /// Configura el aspecto visual de un formulario utilizando el tema MaterialSkin.
        /// </summary>
        /// <param name="form">Formulario que se va a gestionar con el esquema de MaterialSkin.</param>
        public void MaterialSkin(MaterialForm form)
        {
            // Obtiene la instancia del gestor de MaterialSkin.
            var materialSkinManager = MaterialSkinManager.Instance;

            // Añade el formulario al gestor de MaterialSkin para que se le aplique el esquema visual.
            materialSkinManager.AddFormToManage(form);

            // Establece el tema del formulario a "LIGHT", que es un tema claro.
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Define el esquema de colores para el formulario con tonos de índigo.
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo800,   // Color principal para los controles, encabezados, etc.
                Primary.Indigo900,   // Color de fondo principal más oscuro.
                Primary.Indigo500,   // Color para elementos secundarios.
                Accent.Indigo400,    // Color de acento, como botones y elementos interactivos.
                TextShade.WHITE      // Color del texto en color blanco para asegurar contraste y legibilidad.
            );
        }


    }
}