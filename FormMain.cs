using Facturacion.MaterialUI.MaterialSkinUI;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLoginTask.Context;
using WindowsFormsLoginTask.Form;

namespace WindowsFormsLoginTask
{
    public partial class FormMain: MaterialForm
    {
        MaterialSkinUI skinui = new MaterialSkinUI(); // Instancia de MaterialSkinUI para aplicar diseño.

        private List<Usuario> usuarioList;
        public FormMain(List<Usuario> usuarios)
        {
            this.usuarioList = usuarios;
            InitializeComponent();
            skinui.MaterialSkin(this);
            tabControlMain.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            // Establecer el índice seleccionado al cargar el formulario
            tabControlMain.SelectedIndex = 0; // Seleccionar la primera pestaña por defecto

            // Cargar el formulario de la primera pestaña automáticamente al inicio
            LoadFormForSelectedTab();

        }

        /// <summary>
        /// Evento que se dispara cuando se cambia la pestaña seleccionada en el TabControl.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento (en este caso, el TabControl).</param>
        /// <param name="e">Argumentos del evento, que proporcionan detalles sobre el cambio de índice.</param>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llama a la función que carga el formulario correspondiente según la pestaña seleccionada.
            LoadFormForSelectedTab();
        }


        /// <summary>
        /// Carga el formulario correspondiente en la pestaña seleccionada del TabControl.
        /// Limpia la pestaña y agrega el formulario adecuado dependiendo de la pestaña seleccionada.
        /// </summary>
        private void LoadFormForSelectedTab()
        {
            // Limpiar el contenido actual de la pestaña seleccionada para cargar un nuevo formulario.
            tabControlMain.SelectedTab.Controls.Clear();

            // Variable para almacenar el formulario que se va a cargar.
            MaterialForm formularioInterno = null;

            // Identificar qué pestaña se seleccionó y asignar el formulario correspondiente.
            switch (tabControlMain.SelectedTab.Name)
            {
                // Si la pestaña seleccionada es "tabPageTask", se carga el formulario FormTask.
                case "tabPageTask":
                    formularioInterno = new FormTask(usuarioList); // Pasar el usuarioList al formulario
                    break;
                // Si la pestaña seleccionada es "tabPageCategory", se carga el formulario FormCategory.
                case "tabPageCategory":
                    formularioInterno = new FormCategory();
                    break;
            }

            // Si se ha asignado un formulario (es decir, no es null), se configura y muestra.
            if (formularioInterno != null)
            {
                formularioInterno.TopLevel = false; // Permite que el formulario se comporte como un control, no como una ventana independiente.
                formularioInterno.FormBorderStyle = FormBorderStyle.None; // Quita los bordes del formulario.
                formularioInterno.Dock = DockStyle.Fill; // Hace que el formulario ocupe toda el área disponible de la pestaña.

                // Agrega el formulario al contenedor de controles de la pestaña seleccionada.
                tabControlMain.SelectedTab.Controls.Add(formularioInterno);

                // Muestra el formulario dentro de la pestaña.
                formularioInterno.Show();
            }
        }

    }
}
