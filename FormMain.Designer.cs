namespace WindowsFormsLoginTask
{
    partial class FormMain
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
            this.tabControlMain = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageTask = new System.Windows.Forms.TabPage();
            this.tabPageCategory = new System.Windows.Forms.TabPage();
            this.tabSelectorMain = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageTask);
            this.tabControlMain.Controls.Add(this.tabPageCategory);
            this.tabControlMain.Depth = 0;
            this.tabControlMain.Location = new System.Drawing.Point(-1, 81);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1551, 556);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageTask
            // 
            this.tabPageTask.Location = new System.Drawing.Point(4, 25);
            this.tabPageTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTask.Name = "tabPageTask";
            this.tabPageTask.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTask.Size = new System.Drawing.Size(1543, 527);
            this.tabPageTask.TabIndex = 0;
            this.tabPageTask.Text = "Tareas";
            this.tabPageTask.UseVisualStyleBackColor = true;
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.Location = new System.Drawing.Point(4, 25);
            this.tabPageCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCategory.Size = new System.Drawing.Size(1543, 527);
            this.tabPageCategory.TabIndex = 1;
            this.tabPageCategory.Text = "Categoria";
            this.tabPageCategory.UseVisualStyleBackColor = true;
            // 
            // tabSelectorMain
            // 
            this.tabSelectorMain.BaseTabControl = this.tabControlMain;
            this.tabSelectorMain.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.tabSelectorMain.Depth = 0;
            this.tabSelectorMain.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelectorMain.Location = new System.Drawing.Point(-1, 28);
            this.tabSelectorMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSelectorMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelectorMain.Name = "tabSelectorMain";
            this.tabSelectorMain.Size = new System.Drawing.Size(1551, 47);
            this.tabSelectorMain.TabIndex = 1;
            this.tabSelectorMain.Text = "materialTabSelector1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 640);
            this.Controls.Add(this.tabSelectorMain);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 2);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTask;
        private System.Windows.Forms.TabPage tabPageCategory;
        private MaterialSkin.Controls.MaterialTabSelector tabSelectorMain;
    }
}