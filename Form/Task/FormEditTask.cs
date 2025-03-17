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
using WindowsFormsLoginTask.Tools;

namespace WindowsFormsLoginTask.Form
{
    /// <summary>
    /// Formulario para editar una tarea.
    /// </summary>
    public partial class FormEditTask : MaterialForm
    {
        /// <summary>
        /// Instancia de MaterialSkinUI para aplicar diseño Material Skin.
        /// </summary>
        MaterialSkinUI skinui = new MaterialSkinUI();

        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Título de la tarea.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        public String descrip { get; set; }

        /// <summary>
        /// Identificador de la categoría relacionada con la tarea.
        /// </summary>
        public int categoriaId { get; set; }

        /// <summary>
        /// Identificador del usuario relacionado con la tarea.
        /// </summary>
        public int usuarioId { get; set; }

        /// <summary>
        /// Identificador del estado de la tarea.
        /// </summary>
        public int estadoId { get; set; }

        /// <summary>
        /// Fecha de vencimiento de la tarea.
        /// </summary>
        public DateTime fechaVencimiento { get; set; }

        /// <summary>
        /// Días restantes para la fecha de vencimiento.
        /// </summary>
        public int vencimiento { get; set; }

        /// <summary>
        /// Estado inactivo de la tarea (1 para inactiva, 0 para activa).
        /// </summary>
        public int inactivo { get; set; }

        /// <summary>
        /// Instancia de la clase Tarea para gestionar tareas.
        /// </summary>
        Tarea tareas = new Tarea();

        /// <summary>
        /// Instancia de la clase Categoria para gestionar categorías.
        /// </summary>
        Categoria categorias = new Categoria();

        /// <summary>
        /// Instancia de la clase Estado para gestionar estados.
        /// </summary>
        Estado estados = new Estado();

        /// <summary>
        /// Instancia de la clase ToolsMain para herramientas adicionales.
        /// </summary>
        ToolsMain tools = new ToolsMain();

        /// <summary>
        /// Constructor que inicializa el formulario con los valores a editar.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <param name="titulo">Título de la tarea.</param>
        /// <param name="descripcion">Descripción de la tarea.</param>
        /// <param name="categoriaId">Identificador de la categoría relacionada.</param>
        /// <param name="usuarioId">Identificador del usuario relacionado.</param>
        /// <param name="estadoId">Identificador del estado de la tarea.</param>
        /// <param name="fechaVencimiento">Fecha de vencimiento de la tarea.</param>
        /// <param name="inactivo">Estado de inactividad de la tarea.</param>
        public FormEditTask(int id, string titulo, string descripcion, int categoriaId, int usuarioId, int estadoId, DateTime fechaVencimiento, int inactivo)
        {
            InitializeComponent(); // Inicializa los componentes del formulario
            skinui.MaterialSkin(this); // Aplica el estilo de Material Skin al formulario

            // Asigna los valores recibidos a las propiedades
            this.id = id;
            this.name = titulo;
            this.descrip = descripcion;
            this.categoriaId = categoriaId;
            this.usuarioId = usuarioId;
            this.estadoId = estadoId;
            this.fechaVencimiento = fechaVencimiento;

            // Llenar los combos de categorías y estados
            tools.LlenarCombo<DataRow>(comboCategoria, categorias.ObtenerCategorias(), "Nombre", "Id");
            tools.LlenarCombo<DataRow>(comboEstado, estados.ObtenerEstados(), "NombreEstado", "Id");

            // Establece los valores en los campos de texto y combo
            textName.Text = this.name;
            textDescrip.Text = this.descrip;
            comboEstado.SelectedValue = this.estadoId; // Asigna el estado según el ID
            comboCategoria.SelectedValue = this.categoriaId; // Asigna la categoría según el ID
                                                             //comboUsuario.SelectedValue = this.usuarioId; // Asigna el usuario según el ID (comentado)

            // Calcula los días de vencimiento
            TimeSpan diasDiferenciaFechas = (fechaVencimiento - DateTime.Now);
            vencimiento = (diasDiferenciaFechas.Days + 1);
            textVencimiento.Text = vencimiento.ToString();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Guardar".
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos antes de agregar
            if (!ValidarCampos())
            {
                // Muestra un mensaje si los campos no son válidos
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Guardar los valores ingresados y cerrar el modal
                name = textName.Text; // Actualiza el nombre con el texto ingresado.
                descrip = textDescrip.Text; // Actualiza la descripción con el texto ingresado.
                categoriaId = Convert.ToInt32(comboCategoria.SelectedValue.ToString()); // Actualiza la categoría seleccionada.
                estadoId = Convert.ToInt32(comboEstado.SelectedValue.ToString()); // Actualiza el estado seleccionado.
                vencimiento = Convert.ToInt32(textVencimiento.Text); // Actualiza el vencimiento.
                fechaVencimiento = DateTime.Now.AddDays(vencimiento); // Calcula la fecha de vencimiento.

                // Llama a la función para actualizar la tarea
                if (tareas.ActualizarTarea(id, name, descrip, categoriaId, usuarioId, estadoId, fechaVencimiento, inactivo))
                {
                    MessageBox.Show("Registro actualizado correctamente!!");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro!!");
                }

                // Indica que los cambios se guardaron y cierra el formulario
                DialogResult = DialogResult.OK;
                Close(); // Cierra el formulario.
            }
        }

        /// <summary>
        /// Método para validar los campos del formulario antes de guardar.
        /// </summary>
        /// <returns>True si todos los campos son válidos, false en caso contrario.</returns>
        private bool ValidarCampos()
        {
            bool valido = true;

            // Validar el campo de nombre (mínimo 3 caracteres)
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                errorProvider1.SetError(textName, "El nombre es obligatorio.");
                valido = false;
            }
            else if (textName.Text.Length < 3)
            {
                errorProvider1.SetError(textName, "El nombre debe tener al menos 3 caracteres.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textName, "");
            }

            // Validar el campo de descripción (mínimo 10 caracteres)
            if (string.IsNullOrWhiteSpace(textDescrip.Text))
            {
                errorProvider1.SetError(textDescrip, "La descripción es obligatoria.");
                valido = false;
            }
            else if (textDescrip.Text.Length < 10)
            {
                errorProvider1.SetError(textDescrip, "La descripción debe tener al menos 10 caracteres.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textDescrip, "");
            }

            // Validar que un campo solo tenga números (Ejemplo: textNumero)
            if (!int.TryParse(textVencimiento.Text, out int numero)) // Solo permite enteros
            {
                errorProvider1.SetError(textVencimiento, "Este campo solo puede contener números enteros.");
                valido = false;
            }
            else if (numero <= 0)
            {
                errorProvider1.SetError(textVencimiento, "El número debe ser mayor a 0");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textVencimiento, "");
            }

            return valido; // Retorna el resultado de la validación
        }
    }

}
