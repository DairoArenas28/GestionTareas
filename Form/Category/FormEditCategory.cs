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
using System.Xml.Linq;
using WindowsFormsLoginTask.Context;

namespace WindowsFormsLoginTask.Form.Category
{
    public partial class FormEditCategory: MaterialForm
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public String nombre { get; set; }

        /// <summary>
        /// Descripción de la categoría.
        /// </summary>
        public String descripcion { get; set; }

        /// <summary>
        /// Estado de la categoría, donde 0 significa activa y 1 inactiva.
        /// </summary>
        public int inactivo { get; set; }

        /// <summary>
        /// Instancia de la clase Categoria para realizar actualizaciones en la base de datos.
        /// </summary>
        Categoria categoria = new Categoria();

        /// <summary>
        /// Constructor que recibe los valores de la categoría para editar.
        /// </summary>
        /// <param name="id">Identificador único de la categoría.</param>
        /// <param name="nombre">Nombre de la categoría.</param>
        /// <param name="descripcion">Descripción de la categoría.</param>
        /// <param name="inactivo">Estado de la categoría (0 para activa, 1 para inactiva).</param>

        public FormEditCategory(int id, string nombre, string descripcion, int inactivo)
        {
            InitializeComponent();
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.inactivo = inactivo;

            // Establece los valores en los campos de texto y combo
            textName.Text = this.nombre;
            textDescrip.Text = this.descripcion;
            //comboUsuario.SelectedValue = this.usuarioId; // Asigna el usuario seleccionada según el ID
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos antes de agregar
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Guardar los valores ingresados y cerrar el modal
                nombre = textName.Text; // Actualiza el nombre con el texto ingresado.
                descripcion = textDescrip.Text; // Actualiza la descripción con el texto ingresado.

                if (categoria.ActualizarCategoria(id, nombre, descripcion, 0))
                {
                    MessageBox.Show("Registro actualizado correctamente!!");
                }
                else
                {
                    MessageBox.Show("Error al actualizado el registro!!");
                }

                DialogResult = DialogResult.OK; // Indica que se guardaron los cambios y el formulario se cerrará con éxito.
                Close(); // Cierra el formulario.
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            // Validar el campo de nombre
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                errorProvider1.SetError(textName, "Este campo es obligatorio.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textName, ""); // Limpiar error si es válido
            }

            // Validar el campo de descripción
            if (string.IsNullOrWhiteSpace(textDescrip.Text))
            {
                errorProvider1.SetError(textDescrip, "Este campo es obligatorio.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textDescrip, ""); // Limpiar error si es válido
            }

            return valido; // Retornar el resultado de la validación
        }
    }
}
