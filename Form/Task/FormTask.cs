using Facturacion.MaterialUI.MaterialSkinUI;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLoginTask.Context;
using WindowsFormsLoginTask.Form;
using WindowsFormsLoginTask.Tools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsLoginTask
{
    /// <summary>
    /// Clase que representa el formulario para gestionar tareas.
    /// </summary>
    public partial class FormTask : MaterialForm
    {
        MaterialSkinUI skinui = new MaterialSkinUI();

        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        private int id;

        /// <summary>
        /// Nombre de la tarea.
        /// </summary>
        private String name;

        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        private String descrip;

        /// <summary>
        /// Identificador del estado de la tarea.
        /// </summary>
        private int estadoId;

        /// <summary>
        /// Identificador del usuario relacionado con la tarea.
        /// </summary>
        private int usuarioId;

        /// <summary>
        /// Identificador de la categoría de la tarea.
        /// </summary>
        private int categoriaId;

        /// <summary>
        /// Fecha de vencimiento de la tarea.
        /// </summary>
        private DateTime fechaVencimiento;

        /// <summary>
        /// Número de días hasta la fecha de vencimiento.
        /// </summary>
        private int vencimiento;

        /// <summary>
        /// Conjunto de datos para las tareas.
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Resultado del formulario (si la operación fue exitosa).
        /// </summary>
        private bool bResultForm;

        /// <summary>
        /// Instancia de la clase Tarea para gestionar las operaciones de tareas.
        /// </summary>
        private Tarea tarea = new Tarea();

        /// <summary>
        /// Instancia de la clase Categoria para gestionar las categorías de las tareas.
        /// </summary>
        private Categoria categorias = new Categoria();

        /// <summary>
        /// Instancia de la clase Estado para gestionar los estados de las tareas.
        /// </summary>
        private Estado estados = new Estado();

        /// <summary>
        /// Instancia de la clase ToolsMain para herramientas adicionales.
        /// </summary>
        private ToolsMain tools = new ToolsMain();

        /// <summary>
        /// Lista de usuarios relacionados con las tareas.
        /// </summary>
        private List<Usuario> usuarioList = new List<Usuario>();

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        /// <param name="usuarios">Lista de usuarios que pueden estar relacionados con las tareas.</param>
        public FormTask(List<Usuario> usuarios)
        {
            InitializeComponent();

            this.usuarioList = usuarios;

            LlenarTabla();

            tools.LlenarCombo<DataRow>(comboCategoria,categorias.ObtenerCategorias(),"Nombre","Id");
            tools.LlenarCombo<DataRow>(comboEstado,estados.ObtenerEstados(), "NombreEstado", "Id");

            tools.OcultarColumnaListView(dataListTask, new List<int> {0, 3, 5, 7 });
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Agregar", valida los campos ingresados,
        /// agrega una nueva tarea y muestra un mensaje según el resultado.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar si los campos requeridos están completos antes de proceder.
            if (!ValidarCampos())
            {
                // Muestra un mensaje de advertencia si no se completaron los campos requeridos.
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sale del método si los campos no son válidos.
            }
            else
            {
                // Obtener los valores de los campos de texto y otras entradas del formulario.
                name = textName.Text; // Título de la tarea.
                descrip = textDescrip.Text; // Descripción de la tarea.
                categoriaId = Convert.ToInt32(comboEstado.SelectedValue.ToString()); // ID de la categoría seleccionada.
                usuarioId = usuarioList[0].Id; // ID del usuario, tomando el primero de la lista de usuarios.
                estadoId = Convert.ToInt32(comboEstado.SelectedValue.ToString()); // ID del estado seleccionado.
                vencimiento = Convert.ToInt32(textVencimiento.Text); // Valor de vencimiento en días.
                fechaVencimiento = DateTime.Now.AddDays(vencimiento); // Fecha de vencimiento calculada sumando los días al día actual.

                // Llamada a la función que agrega la tarea a la base de datos.
                bResultForm = tarea.AgregarTarea(name, descrip, categoriaId, usuarioId, estadoId, fechaVencimiento, 0);

                // Verifica si la tarea se guardó correctamente.
                if (bResultForm)
                {
                    // Si la tarea se agregó con éxito, refresca la tabla de tareas.
                    LlenarTabla();
                    // Limpiar los campos del formulario para ingresar nuevos datos.
                    LimpiarCampos();
                    // Muestra un mensaje indicando que los datos se guardaron correctamente.
                    MessageBox.Show("Datos guardados correctamente.");
                }
                else
                {
                    // Si hubo un error al guardar, muestra un mensaje de error.
                    MessageBox.Show("Error al guardar el registro.");
                }
            }
        }


        /// <summary>
        /// Llena el ListView con los datos de las tareas obtenidas desde la base de datos.
        /// Limpia el ListView antes de agregar nuevos datos y recorre cada fila del DataSet
        /// para añadirla como un nuevo item en el ListView.
        /// </summary>
        public void LlenarTabla()
        {
            // Obtiene las tareas desde la base de datos (DataSet contiene los datos)
            ds = tarea.ObtenerTareas();

            // Limpiar el ListView antes de cargar nuevos datos
            dataListTask.Items.Clear();

            // Recorrer las filas del DataSet (Tabla "Tareas") y agregar los datos al ListView
            foreach (DataRow fila in ds.Tables["Tareas"].Rows)
            {
                // Crear un nuevo item para la primera columna con el ID de la tarea
                ListViewItem item = new ListViewItem(fila["ID"].ToString());

                // Agregar subelementos para cada columna de la fila en el ListView
                item.SubItems.Add(fila["titulo"].ToString()); // Título de la tarea
                item.SubItems.Add(fila["descripcion"].ToString()); // Descripción de la tarea
                item.SubItems.Add(fila["categoriaId"].ToString()); // ID de la categoría
                item.SubItems.Add(fila["nombreCategoria"].ToString()); // Nombre de la categoría
                item.SubItems.Add(fila["usuarioId"].ToString()); // ID del usuario asignado
                item.SubItems.Add(fila["nombreUsuario"].ToString()); // Nombre del usuario asignado
                item.SubItems.Add(fila["estadoId"].ToString()); // ID del estado de la tarea
                item.SubItems.Add(fila["nombreEstado"].ToString()); // Nombre del estado de la tarea
                item.SubItems.Add(fila["fechaVencimiento"].ToString()); // Fecha de vencimiento de la tarea
                item.SubItems.Add("Editar"); // Columna para la opción de editar
                item.SubItems.Add("Borrar"); // Columna para la opción de eliminar

                // Añadir el item al ListView
                dataListTask.Items.Add(item);
            }
        }


        /// <summary>
        /// Evento que maneja el cierre del formulario de tareas.
        /// Cierra el formulario padre (si existe) cuando el formulario de tareas se cierra.
        /// </summary>
        private void FormTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Verifica si existe un formulario padre (Owner) y lo cierra
            this.Owner?.Close();
        }


        /// <summary>
        /// Evento que maneja los clics en el ListView para realizar acciones sobre los ítems.
        /// Permite editar o eliminar tareas al hacer clic en las columnas correspondientes ("Editar" y "Borrar").
        /// </summary>
        private void dataListTask_MouseClick(object sender, MouseEventArgs e)
        {
            // Obtener información sobre la ubicación del clic en el ListView
            ListViewHitTestInfo info = dataListTask.HitTest(e.Location);

            // Verificar si se hizo clic en un ítem y un subítem del ListView
            if (info.Item != null && info.SubItem != null)
            {
                // Obtener el índice del subítem en el ítem seleccionado
                int subItemIndex = info.Item.SubItems.IndexOf(info.SubItem);

                // Verificar si se hizo clic en la columna de "Editar" (índice 10)
                if (subItemIndex == 10)
                {
                    if (dataListTask.SelectedItems.Count > 0)
                    {
                        // Confirmar si se desea editar la tarea
                        DialogResult result = MessageBox.Show("¿Deseas editar esta tarea?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        ListViewItem selectedItem = dataListTask.SelectedItems[0]; // Obtener el ítem seleccionado

                        // Obtener los valores actuales del ítem seleccionado
                        id = Convert.ToInt32(selectedItem.SubItems[0].Text);
                        name = selectedItem.SubItems[1].Text;
                        descrip = selectedItem.SubItems[2].Text;
                        categoriaId = Convert.ToInt32(selectedItem.SubItems[3].Text);
                        usuarioId = Convert.ToInt32(selectedItem.SubItems[5].Text);
                        estadoId = Convert.ToInt32(selectedItem.SubItems[7].Text);
                        fechaVencimiento = Convert.ToDateTime(selectedItem.SubItems[9].Text);

                        // Si el usuario confirma la edición, se abre el formulario de edición de tarea
                        if (result == DialogResult.Yes)
                        {
                            using (FormEditTask form = new FormEditTask(id, name, descrip, categoriaId, usuarioId, estadoId, fechaVencimiento, 0))
                            {
                                form.StartPosition = FormStartPosition.CenterScreen; // Centrar el formulario en la pantalla
                                                                                     // Mostrar el formulario y esperar el resultado
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    // Si la edición es exitosa, refrescar la tabla
                                    LlenarTabla();
                                }
                            }
                        }
                    }
                }

                // Verificar si se hizo clic en la columna de "Borrar" (índice 11)
                if (subItemIndex == 11)
                {
                    // Confirmar si se desea eliminar la tarea
                    DialogResult result = MessageBox.Show("¿Eliminar esta tarea?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ListViewItem selectedItem = dataListTask.SelectedItems[0]; // Obtener el ítem seleccionado
                        int selectedIndex = selectedItem.Index; // Obtener el índice del ítem seleccionado

                        // Obtener el ID de la tarea a eliminar
                        id = int.Parse(selectedItem.SubItems[0].Text);

                        // Llamar al método para marcar la tarea como inactiva en la base de datos (eliminarla)
                        bResultForm = tarea.InactivoTarea(1, id);

                        // Si la tarea fue eliminada correctamente, remover el ítem de la vista
                        if (bResultForm)
                        {
                            dataListTask.Items.RemoveAt(selectedIndex); // Eliminar el ítem del ListView
                            MessageBox.Show("Registro eliminado correctamente!"); // Mostrar mensaje de éxito
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el registro"); // Mostrar mensaje de error
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Método para validar los campos de entrada antes de agregar o editar una tarea.
        /// Valida los campos de nombre, descripción y vencimiento para asegurar que cumplan con los requisitos establecidos.
        /// </summary>
        /// <returns>Retorna true si todos los campos son válidos, de lo contrario false.</returns>
        private bool ValidarCampos()
        {
            bool valido = true; // Variable para almacenar el estado de la validación, comienza como válida.

            // Validar el campo de nombre (mínimo 3 caracteres)
            if (string.IsNullOrWhiteSpace(textName.Text)) // Verifica si el campo está vacío o contiene solo espacios
            {
                errorProvider1.SetError(textName, "El nombre es obligatorio."); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else if (textName.Text.Length < 3) // Verifica si el nombre tiene menos de 3 caracteres
            {
                errorProvider1.SetError(textName, "El nombre debe tener al menos 3 caracteres."); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else
            {
                errorProvider1.SetError(textName, ""); // Si es válido, limpia el mensaje de error
            }

            // Validar el campo de descripción (mínimo 10 caracteres)
            if (string.IsNullOrWhiteSpace(textDescrip.Text)) // Verifica si el campo está vacío o contiene solo espacios
            {
                errorProvider1.SetError(textDescrip, "La descripción es obligatoria."); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else if (textDescrip.Text.Length < 10) // Verifica si la descripción tiene menos de 10 caracteres
            {
                errorProvider1.SetError(textDescrip, "La descripción debe tener al menos 10 caracteres."); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else
            {
                errorProvider1.SetError(textDescrip, ""); // Si es válido, limpia el mensaje de error
            }

            // Validar que el campo de vencimiento solo contenga números
            if (!int.TryParse(textVencimiento.Text, out int numero)) // Verifica si el campo contiene solo números enteros
            {
                errorProvider1.SetError(textVencimiento, "Este campo solo puede contener números enteros."); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else if (numero <= 0) // Verifica si el número es menor o igual a 0
            {
                errorProvider1.SetError(textVencimiento, "El número debe ser mayor a 0"); // Muestra un mensaje de error
                valido = false; // Marca como inválido
            }
            else
            {
                errorProvider1.SetError(textVencimiento, ""); // Si es válido, limpia el mensaje de error
            }

            return valido; // Retorna el resultado de la validación
        }


        /// <summary>
        /// Evento que se maneja cuando se carga el formulario. Habilita el dibujo personalizado del ListView.
        /// </summary>
        private void FormTask_Load(object sender, EventArgs e)
        {
            dataListTask.OwnerDraw = true;  // Habilita el dibujo personalizado en el ListView
            dataListTask.DrawColumnHeader += dataListTask_DrawColumnHeader; // Se maneja el evento para dibujar los encabezados
            dataListTask.DrawSubItem += dataListTask_DrawSubItem; // Se maneja el evento para dibujar los subítems
        }


        /// <summary>
        /// Evento que maneja el dibujo del encabezado del ListView.
        /// </summary>
        private void dataListTask_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true; // Dibuja el encabezado con el estilo predeterminado
        }


        /// <summary>
        /// Evento que maneja el dibujo de los subítems del ListView.
        /// </summary>
        private void dataListTask_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Colorear la columna de "Editar"
            if (e.ColumnIndex == 10)
            {
                e.Graphics.FillRectangle(Brushes.MediumBlue, e.Bounds);  // Color de fondo azul
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            // Colorear la columna de "Borrar"
            else if (e.ColumnIndex == 11)
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);  // Color de fondo rojo
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.DrawDefault = true; // Dibuja las demás columnas normalmente
            }
        }

        /// <summary>
        /// Método que limpia todos los campos de entrada.
        /// </summary>
        private void LimpiarCampos()
        {
            textName.Text = ""; // Limpiar el campo de nombre
            textDescrip.Text = ""; // Limpiar el campo de descripción
            comboCategoria.SelectedItem = 0; // Resetear la categoría seleccionada
            comboEstado.SelectedIndex = 0; // Reiniciar el combo de estado
            textVencimiento.Text = "1"; // Restablecer el campo de vencimiento a su valor predeterminado
        }


        /// <summary>
        /// Evento que maneja la validación de la entrada de texto en el campo de vencimiento.
        /// Permite solo números y teclas de control.
        /// </summary>
        private void textVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (borrar, enter, etc.)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada de cualquier otro carácter
            }
        }

    }

}
