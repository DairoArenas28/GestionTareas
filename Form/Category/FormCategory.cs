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
using WindowsFormsLoginTask.Form.Category;
using WindowsFormsLoginTask.Tools;

namespace WindowsFormsLoginTask.Form
{
    public partial class FormCategory : MaterialForm
    {    /// <summary>
         /// Identificador de la categoría.
         /// </summary>
        private int id;

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        private String nombre;

        /// <summary>
        /// Descripción de la categoría.
        /// </summary>
        private String descripcion;

        /// <summary>
        /// Contiene los datos obtenidos de la base de datos.
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Indica el resultado de una operación en el formulario.
        /// </summary>
        private bool bResultForm;

        /// <summary>
        /// Herramientas auxiliares.
        /// </summary>
        private ToolsMain tools = new ToolsMain();

        /// <summary>
        /// Instancia de la clase Categoria.
        /// </summary>
        private Categoria categoria = new Categoria();

        /// <summary>
        /// Constructor de la clase FormCategory.
        /// Inicializa los componentes y carga los datos en la tabla.
        /// </summary>
        public FormCategory()
        {
            InitializeComponent();
            LlenarTabla();
        }

        /// <summary>
        /// Maneja el evento de clic en un elemento de la lista.
        /// Permite editar o eliminar una categoría dependiendo de la columna seleccionada.
        /// </summary>
        private void dataListViewCategory_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = dataListViewCategory.HitTest(e.Location);

            if (info.Item != null && info.SubItem != null)
            {
                int subItemIndex = info.Item.SubItems.IndexOf(info.SubItem);

                // Verificar si se hizo clic en la columna de "Editar"
                if (subItemIndex == 4)
                {
                    if (dataListViewCategory.SelectedItems.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("¿Deseas editar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        ListViewItem selectedItem = dataListViewCategory.SelectedItems[0];

                        id = Convert.ToInt32(selectedItem.SubItems[0].Text);
                        nombre = selectedItem.SubItems[1].Text;
                        descripcion = selectedItem.SubItems[2].Text;

                        if (result == DialogResult.Yes)
                        {
                            using (FormEditCategory form = new FormEditCategory(id, nombre, descripcion, 0))
                            {
                                form.StartPosition = FormStartPosition.CenterScreen;
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    LlenarTabla();
                                }
                            }
                        }
                    }
                }

                // Verificar si se hizo clic en la columna de "Borrar"
                if (subItemIndex == 5)
                {
                    DialogResult result = MessageBox.Show("¿Eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ListViewItem selectedItem = dataListViewCategory.SelectedItems[0];
                        int selectedIndex = selectedItem.Index;
                        id = int.Parse(selectedItem.SubItems[0].Text);

                        bool bResultForm = categoria.InactivoCategoria(id, 1);
                        if (bResultForm)
                        {
                            dataListViewCategory.Items.RemoveAt(selectedIndex);
                            MessageBox.Show("Registro eliminado correctamente!");
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el registro");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Agrega una nueva categoría a la base de datos.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                nombre = textName.Text;
                descripcion = textDescrip.Text;

                bResultForm = categoria.AgregarCategoria(nombre, descripcion, 0);

                if (bResultForm)
                {
                    LlenarTabla();
                    LimpiarCampos();
                    MessageBox.Show("Datos guardados correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al guardar el registro.");
                }
            }
        }

        /// <summary>
        /// Llena el ListView con los datos de la tabla Categorías.
        /// </summary>
        private void LlenarTabla()
        {
            ds = categoria.ObtenerCategorias();
            dataListViewCategory.Items.Clear();

            foreach (DataRow fila in ds.Tables["Categorias"].Rows)
            {
                ListViewItem item = new ListViewItem(fila["ID"].ToString());
                item.SubItems.Add(fila["nombre"].ToString());
                item.SubItems.Add(fila["descripcion"].ToString());
                item.SubItems.Add(fila["fechaCreacion"].ToString());
                item.SubItems.Add("Editar");
                item.SubItems.Add("Borrar");

                dataListViewCategory.Items.Add(item);
            }
        }

        /// <summary>
        /// Valida que los campos de entrada no estén vacíos.
        /// </summary>
        private bool ValidarCampos()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                errorProvider1.SetError(textName, "Este campo es obligatorio.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textName, "");
            }

            if (string.IsNullOrWhiteSpace(textDescrip.Text))
            {
                errorProvider1.SetError(textDescrip, "Este campo es obligatorio.");
                valido = false;
            }
            else
            {
                errorProvider1.SetError(textDescrip, "");
            }

            return valido;
        }

        /// <summary>
        /// Limpia los campos de entrada en el formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            textName.Text = "";
            textDescrip.Text = "";
        }

        /// <summary>
        /// Maneja el evento de carga del formulario.
        /// Configura el ListView para dibujo personalizado.
        /// </summary>
        private void FormCategory_Load(object sender, EventArgs e)
        {
            dataListViewCategory.OwnerDraw = true;
            dataListViewCategory.DrawColumnHeader += dataListViewCategory_DrawColumnHeader;
            dataListViewCategory.DrawSubItem += dataListViewCategory_DrawSubItem;
        }

        private void dataListViewCategory_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void dataListViewCategory_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Graphics.FillRectangle(Brushes.MediumBlue, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else if (e.ColumnIndex == 5)
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

    }
}
