using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginTask.Tools
{
    public class ToolsMain
    {
        public void LlenarCombo<DataRow>(MaterialComboBox combo, DataSet dataSource, string displayMember, string valueMember)
        {
            // Asegúrate de que el DataSet tenga al menos una tabla
            if (dataSource.Tables.Count > 0)
            {
                // Asumiendo que solo deseas llenar el ComboBox con la primera tabla
                DataTable table = dataSource.Tables[0];

                // Asigna el DataSource, DisplayMember y ValueMember correctamente
                combo.DataSource = table;
                combo.DisplayMember = displayMember;
                combo.ValueMember = valueMember;
            }
            else
            {
                MessageBox.Show("No se encontraron datos en el DataSet.");
            }
        }

        public void OcultarColumnaListView(MaterialListView listview, List<int> columnas)
        {
            for (int i = 0; i < columnas.Count; i++)
            {
                listview.Columns[columnas[i]].Width = 0;
            }
        }
    }
}
