namespace WindowsFormsLoginTask.Form
{
    partial class FormEditTask
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.comboCategoria = new MaterialSkin.Controls.MaterialComboBox();
            this.comboEstado = new MaterialSkin.Controls.MaterialComboBox();
            this.textName = new MaterialSkin.Controls.MaterialTextBox();
            this.textDescrip = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.textVencimiento = new MaterialSkin.Controls.MaterialTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Location = new System.Drawing.Point(119, 591);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 53);
            this.panel2.TabIndex = 20;
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
            this.comboCategoria.Location = new System.Drawing.Point(119, 345);
            this.comboCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCategoria.MaxDropDownItems = 4;
            this.comboCategoria.MouseState = MaterialSkin.MouseState.OUT;
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(351, 49);
            this.comboCategoria.StartIndex = 0;
            this.comboCategoria.TabIndex = 22;
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
            this.comboEstado.Location = new System.Drawing.Point(119, 411);
            this.comboEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboEstado.MaxDropDownItems = 4;
            this.comboEstado.MouseState = MaterialSkin.MouseState.OUT;
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(351, 49);
            this.comboEstado.StartIndex = 0;
            this.comboEstado.TabIndex = 21;
            // 
            // textName
            // 
            this.textName.AnimateReadOnly = false;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Depth = 0;
            this.textName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textName.Hint = "Nombre";
            this.textName.LeadingIcon = null;
            this.textName.Location = new System.Drawing.Point(119, 133);
            this.textName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textName.MaxLength = 50;
            this.textName.MouseState = MaterialSkin.MouseState.OUT;
            this.textName.Multiline = false;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(351, 50);
            this.textName.TabIndex = 19;
            this.textName.Text = "";
            this.textName.TrailingIcon = null;
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
            this.textDescrip.Location = new System.Drawing.Point(119, 199);
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
            this.textDescrip.TabIndex = 23;
            this.textDescrip.TabStop = false;
            this.textDescrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textDescrip.UseSystemPasswordChar = false;
            // 
            // textVencimiento
            // 
            this.textVencimiento.AnimateReadOnly = false;
            this.textVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textVencimiento.Depth = 0;
            this.textVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textVencimiento.Hint = "Vencimiento (Días)";
            this.textVencimiento.LeadingIcon = null;
            this.textVencimiento.Location = new System.Drawing.Point(119, 477);
            this.textVencimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textVencimiento.MaxLength = 50;
            this.textVencimiento.MouseState = MaterialSkin.MouseState.OUT;
            this.textVencimiento.Multiline = false;
            this.textVencimiento.Name = "textVencimiento";
            this.textVencimiento.Size = new System.Drawing.Size(351, 50);
            this.textVencimiento.TabIndex = 24;
            this.textVencimiento.Text = "1";
            this.textVencimiento.TrailingIcon = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormEditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 688);
            this.Controls.Add(this.textVencimiento);
            this.Controls.Add(this.textDescrip);
            this.Controls.Add(this.comboCategoria);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.comboEstado);
            this.Controls.Add(this.textName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEditTask";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.Text = "Editar Tarea";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialComboBox comboCategoria;
        private MaterialSkin.Controls.MaterialComboBox comboEstado;
        private MaterialSkin.Controls.MaterialTextBox textName;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 textDescrip;
        private MaterialSkin.Controls.MaterialTextBox textVencimiento;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}