namespace FrbaOfertas.AbmRol
{
    partial class FormRol
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
            this.gridRoles = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRoles
            // 
            this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoles.Location = new System.Drawing.Point(100, 129);
            this.gridRoles.Name = "gridRoles";
            this.gridRoles.Size = new System.Drawing.Size(317, 422);
            this.gridRoles.TabIndex = 0;
            this.gridRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRoles_CellContentClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(319, 581);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 41);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar Rol";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gridRoles);
            this.Name = "FormRol";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridRoles;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button button1;
    }
}