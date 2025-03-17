namespace WindowsFormsLoginTask.Form.Category
{
    partial class FormEditCategory
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
            this.panelBTNAgregar = new System.Windows.Forms.Panel();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.textDescrip = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.textName = new MaterialSkin.Controls.MaterialTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelBTNAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBTNAgregar
            // 
            this.panelBTNAgregar.Controls.Add(this.btnGuardar);
            this.panelBTNAgregar.Location = new System.Drawing.Point(109, 425);
            this.panelBTNAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBTNAgregar.Name = "panelBTNAgregar";
            this.panelBTNAgregar.Size = new System.Drawing.Size(351, 53);
            this.panelBTNAgregar.TabIndex = 29;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(351, 53);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.textDescrip.Location = new System.Drawing.Point(108, 234);
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
            this.textDescrip.Size = new System.Drawing.Size(351, 114);
            this.textDescrip.TabIndex = 28;
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
            this.textName.Location = new System.Drawing.Point(108, 151);
            this.textName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textName.MaxLength = 50;
            this.textName.MouseState = MaterialSkin.MouseState.OUT;
            this.textName.Multiline = false;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(351, 50);
            this.textName.TabIndex = 27;
            this.textName.Text = "";
            this.textName.TrailingIcon = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormEditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 534);
            this.Controls.Add(this.panelBTNAgregar);
            this.Controls.Add(this.textDescrip);
            this.Controls.Add(this.textName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEditCategory";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.Text = "Editar Categoría";
            this.panelBTNAgregar.ResumeLayout(false);
            this.panelBTNAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBTNAgregar;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 textDescrip;
        private MaterialSkin.Controls.MaterialTextBox textName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}