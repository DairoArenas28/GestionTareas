namespace WindowsFormsLoginTask
{
    partial class FormTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textName = new MaterialSkin.Controls.MaterialTextBox();
            this.textDescrip = new MaterialSkin.Controls.MaterialTextBox();
            this.comboEstado = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAgregar = new MaterialSkin.Controls.MaterialButton();
            this.panelBTNAgregar = new System.Windows.Forms.Panel();
            this.columnTarea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescrip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDelete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataListTask = new MaterialSkin.Controls.MaterialListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategoriaId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUsuarioId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEstadoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVencimiento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboCategoria = new MaterialSkin.Controls.MaterialComboBox();
            this.textVencimiento = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelBTNAgregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textName
            // 
            this.textName.AnimateReadOnly = false;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Depth = 0;
            this.textName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textName.Hint = "Nombre";
            this.textName.LeadingIcon = null;
            this.textName.Location = new System.Drawing.Point(35, 74);
            this.textName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textName.MaxLength = 50;
            this.textName.MouseState = MaterialSkin.MouseState.OUT;
            this.textName.Multiline = false;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(351, 50);
            this.textName.TabIndex = 13;
            this.textName.Text = "";
            this.textName.TrailingIcon = null;
            // 
            // textDescrip
            // 
            this.textDescrip.AnimateReadOnly = false;
            this.textDescrip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textDescrip.Depth = 0;
            this.textDescrip.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textDescrip.Hint = "Descripción";
            this.textDescrip.LeadingIcon = null;
            this.textDescrip.Location = new System.Drawing.Point(35, 145);
            this.textDescrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDescrip.MaxLength = 50;
            this.textDescrip.MouseState = MaterialSkin.MouseState.OUT;
            this.textDescrip.Multiline = false;
            this.textDescrip.Name = "textDescrip";
            this.textDescrip.Size = new System.Drawing.Size(351, 50);
            this.textDescrip.TabIndex = 14;
            this.textDescrip.Text = "";
            this.textDescrip.TrailingIcon = null;
            // 
            // comboEstado
            // 
            this.comboEstado.AutoResize = false;
            this.comboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboEstado.Depth = 0;
            this.comboEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboEstado.DropDownHeight = 174;
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.DropDownWidth = 121;
            this.comboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Hint = "Estado";
            this.comboEstado.IntegralHeight = false;
            this.comboEstado.ItemHeight = 43;
            this.comboEstado.Location = new System.Drawing.Point(35, 284);
            this.comboEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboEstado.MaxDropDownItems = 4;
            this.comboEstado.MouseState = MaterialSkin.MouseState.OUT;
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(351, 49);
            this.comboEstado.StartIndex = 0;
            this.comboEstado.TabIndex = 15;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.HighEmphasis = true;
            this.btnAgregar.Icon = null;
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregar.Size = new System.Drawing.Size(351, 53);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar Tarea";
            this.btnAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregar.UseAccentColor = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelBTNAgregar
            // 
            this.panelBTNAgregar.Controls.Add(this.btnAgregar);
            this.panelBTNAgregar.Location = new System.Drawing.Point(35, 477);
            this.panelBTNAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBTNAgregar.Name = "panelBTNAgregar";
            this.panelBTNAgregar.Size = new System.Drawing.Size(351, 53);
            this.panelBTNAgregar.TabIndex = 16;
            // 
            // columnTarea
            // 
            this.columnTarea.Text = "Tarea";
            this.columnTarea.Width = 200;
            // 
            // columnDescrip
            // 
            this.columnDescrip.Text = "Descripción";
            this.columnDescrip.Width = 300;
            // 
            // columnEstado
            // 
            this.columnEstado.Text = "Estado";
            this.columnEstado.Width = 100;
            // 
            // columnUpdate
            // 
            this.columnUpdate.Text = "";
            this.columnUpdate.Width = 100;
            // 
            // columnDelete
            // 
            this.columnDelete.Text = "";
            this.columnDelete.Width = 100;
            // 
            // dataListTask
            // 
            this.dataListTask.AutoSizeTable = false;
            this.dataListTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataListTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnTarea,
            this.columnDescrip,
            this.columnCategoriaId,
            this.columnCategoria,
            this.columnUsuarioId,
            this.columnUsuario,
            this.columnEstadoId,
            this.columnEstado,
            this.columnVencimiento,
            this.columnUpdate,
            this.columnDelete});
            this.dataListTask.Depth = 0;
            this.dataListTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataListTask.FullRowSelect = true;
            this.dataListTask.HideSelection = false;
            this.dataListTask.Location = new System.Drawing.Point(433, 74);
            this.dataListTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListTask.MinimumSize = new System.Drawing.Size(200, 100);
            this.dataListTask.MouseLocation = new System.Drawing.Point(-1, -1);
            this.dataListTask.MouseState = MaterialSkin.MouseState.OUT;
            this.dataListTask.Name = "dataListTask";
            this.dataListTask.OwnerDraw = true;
            this.dataListTask.Size = new System.Drawing.Size(1064, 456);
            this.dataListTask.TabIndex = 17;
            this.dataListTask.UseCompatibleStateImageBehavior = false;
            this.dataListTask.View = System.Windows.Forms.View.Details;
            this.dataListTask.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.dataListTask_DrawColumnHeader);
            this.dataListTask.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.dataListTask_DrawSubItem);
            this.dataListTask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataListTask_MouseClick);
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            // 
            // columnCategoriaId
            // 
            this.columnCategoriaId.Text = "CategoriaId";
            this.columnCategoriaId.Width = 30;
            // 
            // columnCategoria
            // 
            this.columnCategoria.Text = "Categoria";
            this.columnCategoria.Width = 100;
            // 
            // columnUsuarioId
            // 
            this.columnUsuarioId.Text = "UsuarioId";
            this.columnUsuarioId.Width = 30;
            // 
            // columnUsuario
            // 
            this.columnUsuario.Text = "Usuario";
            this.columnUsuario.Width = 100;
            // 
            // columnEstadoId
            // 
            this.columnEstadoId.Text = "EstadoId";
            this.columnEstadoId.Width = 30;
            // 
            // columnVencimiento
            // 
            this.columnVencimiento.Text = "Vencimiento";
            this.columnVencimiento.Width = 150;
            // 
            // comboCategoria
            // 
            this.comboCategoria.AutoResize = false;
            this.comboCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboCategoria.Depth = 0;
            this.comboCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboCategoria.DropDownHeight = 174;
            this.comboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategoria.DropDownWidth = 121;
            this.comboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboCategoria.FormattingEnabled = true;
            this.comboCategoria.Hint = "Categoría";
            this.comboCategoria.IntegralHeight = false;
            this.comboCategoria.ItemHeight = 43;
            this.comboCategoria.Location = new System.Drawing.Point(35, 217);
            this.comboCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCategoria.MaxDropDownItems = 4;
            this.comboCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(351, 49);
            this.comboCategoria.StartIndex = 0;
            this.comboCategoria.TabIndex = 18;
            // 
            // textVencimiento
            // 
            this.textVencimiento.AnimateReadOnly = false;
            this.textVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVencimiento.Depth = 0;
            this.textVencimiento.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textVencimiento.Hint = "Vencimiento (Días)";
            this.textVencimiento.LeadingIcon = null;
            this.textVencimiento.Location = new System.Drawing.Point(35, 357);
            this.textVencimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textVencimiento.MaxLength = 50;
            this.textVencimiento.MouseState = MaterialSkin.MouseState.OUT;
            this.textVencimiento.Multiline = false;
            this.textVencimiento.Name = "textVencimiento";
            this.textVencimiento.Size = new System.Drawing.Size(351, 50);
            this.textVencimiento.TabIndex = 19;
            this.textVencimiento.Text = "1";
            this.textVencimiento.TrailingIcon = null;
            this.textVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textVencimiento_KeyPress);
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 640);
            this.Controls.Add(this.textVencimiento);
            this.Controls.Add(this.comboCategoria);
            this.Controls.Add(this.dataListTask);
            this.Controls.Add(this.panelBTNAgregar);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.textDescrip);
            this.Controls.Add(this.textName);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTask";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Text = "Tareas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTask_FormClosed);
            this.Load += new System.EventHandler(this.FormTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelBTNAgregar.ResumeLayout(false);
            this.panelBTNAgregar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialListView dataListTask;
        private System.Windows.Forms.ColumnHeader columnTarea;
        private System.Windows.Forms.ColumnHeader columnDescrip;
        private System.Windows.Forms.ColumnHeader columnEstado;
        private System.Windows.Forms.ColumnHeader columnUpdate;
        private System.Windows.Forms.ColumnHeader columnDelete;
        private System.Windows.Forms.Panel panelBTNAgregar;
        private MaterialSkin.Controls.MaterialButton btnAgregar;
        private MaterialSkin.Controls.MaterialComboBox comboEstado;
        private MaterialSkin.Controls.MaterialTextBox textDescrip;
        private MaterialSkin.Controls.MaterialTextBox textName;
        private System.Windows.Forms.ColumnHeader columnId;
        private MaterialSkin.Controls.MaterialComboBox comboCategoria;
        private System.Windows.Forms.ColumnHeader columnCategoriaId;
        private System.Windows.Forms.ColumnHeader columnCategoria;
        private System.Windows.Forms.ColumnHeader columnUsuarioId;
        private System.Windows.Forms.ColumnHeader columnUsuario;
        private System.Windows.Forms.ColumnHeader columnEstadoId;
        private System.Windows.Forms.ColumnHeader columnVencimiento;
        private MaterialSkin.Controls.MaterialTextBox textVencimiento;
    }
}