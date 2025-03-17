namespace WindowsFormsLoginTask.Form
{
    partial class FormCategory
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
            this.textDescrip = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.textName = new MaterialSkin.Controls.MaterialTextBox();
            this.panelBTNAgregar = new System.Windows.Forms.Panel();
            this.btnAgregar = new MaterialSkin.Controls.MaterialButton();
            this.dataListViewCategory = new MaterialSkin.Controls.MaterialListView();
            this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDelete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBTNAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textDescrip
            // 
            this.textDescrip.AnimateReadOnly = false;
            this.textDescrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textDescrip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textDescrip.Depth = 0;
            this.textDescrip.HideSelection = true;
            this.textDescrip.Hint = "Descripción";
            this.textDescrip.Location = new System.Drawing.Point(35, 178);
            this.textDescrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDescrip.MaxLength = 32767;
            this.textDescrip.MouseState = MaterialSkin.MouseState.OUT;
            this.textDescrip.Name = "textDescrip";
            this.textDescrip.PasswordChar = '\0';
            this.textDescrip.ReadOnly = false;
            this.textDescrip.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textDescrip.SelectedText = "";
            this.textDescrip.SelectionLength = 0;
            this.textDescrip.SelectionStart = 0;
            this.textDescrip.ShortcutsEnabled = true;
            this.textDescrip.Size = new System.Drawing.Size(351, 126);
            this.textDescrip.TabIndex = 25;
            this.textDescrip.TabStop = false;
            this.textDescrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textDescrip.UseSystemPasswordChar = false;
            // 
            // textName
            // 
            this.textName.AnimateReadOnly = false;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Depth = 0;
            this.textName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textName.Hint = "Nombre";
            this.textName.LeadingIcon = null;
            this.textName.Location = new System.Drawing.Point(35, 81);
            this.textName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textName.MaxLength = 50;
            this.textName.MouseState = MaterialSkin.MouseState.OUT;
            this.textName.Multiline = false;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(351, 50);
            this.textName.TabIndex = 24;
            this.textName.Text = "";
            this.textName.TrailingIcon = null;
            // 
            // panelBTNAgregar
            // 
            this.panelBTNAgregar.Controls.Add(this.btnAgregar);
            this.panelBTNAgregar.Location = new System.Drawing.Point(35, 381);
            this.panelBTNAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBTNAgregar.Name = "panelBTNAgregar";
            this.panelBTNAgregar.Size = new System.Drawing.Size(351, 53);
            this.panelBTNAgregar.TabIndex = 26;
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
            this.btnAgregar.Text = "Agregar Categoria";
            this.btnAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregar.UseAccentColor = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataListViewCategory
            // 
            this.dataListViewCategory.AutoSizeTable = false;
            this.dataListViewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataListViewCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListViewCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnNombre,
            this.columnDescripcion,
            this.columnCreacion,
            this.columnUpdate,
            this.columnDelete});
            this.dataListViewCategory.Depth = 0;
            this.dataListViewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataListViewCategory.FullRowSelect = true;
            this.dataListViewCategory.HideSelection = false;
            this.dataListViewCategory.Location = new System.Drawing.Point(431, 81);
            this.dataListViewCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListViewCategory.MinimumSize = new System.Drawing.Size(200, 100);
            this.dataListViewCategory.MouseLocation = new System.Drawing.Point(-1, -1);
            this.dataListViewCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.dataListViewCategory.Name = "dataListViewCategory";
            this.dataListViewCategory.OwnerDraw = true;
            this.dataListViewCategory.Size = new System.Drawing.Size(1079, 353);
            this.dataListViewCategory.TabIndex = 27;
            this.dataListViewCategory.UseCompatibleStateImageBehavior = false;
            this.dataListViewCategory.View = System.Windows.Forms.View.Details;
            this.dataListViewCategory.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.dataListViewCategory_DrawColumnHeader);
            this.dataListViewCategory.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.dataListViewCategory_DrawSubItem);
            this.dataListViewCategory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataListViewCategory_MouseClick);
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            // 
            // columnNombre
            // 
            this.columnNombre.Text = "Nombre";
            this.columnNombre.Width = 200;
            // 
            // columnDescripcion
            // 
            this.columnDescripcion.Text = "Descripción";
            this.columnDescripcion.Width = 300;
            // 
            // columnCreacion
            // 
            this.columnCreacion.Text = "Fecha Creación";
            this.columnCreacion.Width = 150;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 640);
            this.Controls.Add(this.dataListViewCategory);
            this.Controls.Add(this.panelBTNAgregar);
            this.Controls.Add(this.textDescrip);
            this.Controls.Add(this.textName);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCategory";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Text = "Categoría";
            this.Load += new System.EventHandler(this.FormCategory_Load);
            this.panelBTNAgregar.ResumeLayout(false);
            this.panelBTNAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialMultiLineTextBox2 textDescrip;
        private MaterialSkin.Controls.MaterialTextBox textName;
        private System.Windows.Forms.Panel panelBTNAgregar;
        private MaterialSkin.Controls.MaterialButton btnAgregar;
        private MaterialSkin.Controls.MaterialListView dataListViewCategory;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnNombre;
        private System.Windows.Forms.ColumnHeader columnDescripcion;
        private System.Windows.Forms.ColumnHeader columnCreacion;
        private System.Windows.Forms.ColumnHeader columnUpdate;
        private System.Windows.Forms.ColumnHeader columnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}