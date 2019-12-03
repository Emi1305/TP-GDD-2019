namespace FrbaOfertas.ComprarOferta
{
    partial class FormComprarOferta
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
            this.dataGrid_Ofertas = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btn_comprar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_clientes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Ofertas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_Ofertas
            // 
            this.dataGrid_Ofertas.AllowUserToOrderColumns = true;
            this.dataGrid_Ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Ofertas.Location = new System.Drawing.Point(12, 76);
            this.dataGrid_Ofertas.Name = "dataGrid_Ofertas";
            this.dataGrid_Ofertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_Ofertas.Size = new System.Drawing.Size(886, 259);
            this.dataGrid_Ofertas.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(114, 360);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 29;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btn_comprar
            // 
            this.btn_comprar.Location = new System.Drawing.Point(673, 359);
            this.btn_comprar.Name = "btn_comprar";
            this.btn_comprar.Size = new System.Drawing.Size(75, 23);
            this.btn_comprar.TabIndex = 30;
            this.btn_comprar.Text = "Comprar";
            this.btn_comprar.UseVisualStyleBackColor = true;
            this.btn_comprar.Click += new System.EventHandler(this.btn_comprar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cliente";
            // 
            // comboBox_clientes
            // 
            this.comboBox_clientes.FormattingEnabled = true;
            this.comboBox_clientes.Location = new System.Drawing.Point(114, 22);
            this.comboBox_clientes.Name = "comboBox_clientes";
            this.comboBox_clientes.Size = new System.Drawing.Size(352, 21);
            this.comboBox_clientes.TabIndex = 32;
            // 
            // FormComprarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 416);
            this.Controls.Add(this.comboBox_clientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_comprar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGrid_Ofertas);
            this.Name = "FormComprarOferta";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormComprarOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Ofertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_Ofertas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btn_comprar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_clientes;

    }
}