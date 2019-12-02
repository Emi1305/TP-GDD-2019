namespace FrbaOfertas.CrearOferta
{
    partial class FormOferta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_precioOferta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_precioLista = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_cantDisp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtp_publicacion = new System.Windows.Forms.DateTimePicker();
            this.dtp_vencimiento = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox_proveedores = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // textBox_precioOferta
            // 
            this.textBox_precioOferta.Location = new System.Drawing.Point(103, 56);
            this.textBox_precioOferta.Name = "textBox_precioOferta";
            this.textBox_precioOferta.Size = new System.Drawing.Size(209, 20);
            this.textBox_precioOferta.TabIndex = 5;
            this.textBox_precioOferta.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio Oferta";
            // 
            // textBox_precioLista
            // 
            this.textBox_precioLista.Location = new System.Drawing.Point(415, 56);
            this.textBox_precioLista.Name = "textBox_precioLista";
            this.textBox_precioLista.Size = new System.Drawing.Size(209, 20);
            this.textBox_precioLista.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio Lista";
            // 
            // textBox_cantDisp
            // 
            this.textBox_cantDisp.Location = new System.Drawing.Point(103, 102);
            this.textBox_cantDisp.Name = "textBox_cantDisp";
            this.textBox_cantDisp.Size = new System.Drawing.Size(209, 20);
            this.textBox_cantDisp.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cant. Disponible";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Vto. Oferta";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(103, 146);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(521, 20);
            this.textBox_descripcion.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Descripcion";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(237, 228);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 28;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(348, 228);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 29;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtp_publicacion
            // 
            this.dtp_publicacion.Location = new System.Drawing.Point(415, 12);
            this.dtp_publicacion.Name = "dtp_publicacion";
            this.dtp_publicacion.Size = new System.Drawing.Size(209, 20);
            this.dtp_publicacion.TabIndex = 30;
            // 
            // dtp_vencimiento
            // 
            this.dtp_vencimiento.Location = new System.Drawing.Point(415, 102);
            this.dtp_vencimiento.Name = "dtp_vencimiento";
            this.dtp_vencimiento.Size = new System.Drawing.Size(209, 20);
            this.dtp_vencimiento.TabIndex = 31;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // comboBox_proveedores
            // 
            this.comboBox_proveedores.FormattingEnabled = true;
            this.comboBox_proveedores.Location = new System.Drawing.Point(103, 13);
            this.comboBox_proveedores.Name = "comboBox_proveedores";
            this.comboBox_proveedores.Size = new System.Drawing.Size(209, 21);
            this.comboBox_proveedores.TabIndex = 32;
            // 
            // FormOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 299);
            this.Controls.Add(this.comboBox_proveedores);
            this.Controls.Add(this.dtp_vencimiento);
            this.Controls.Add(this.dtp_publicacion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_cantDisp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_precioLista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_precioOferta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormOferta";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormOferta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_precioOferta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_precioLista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_cantDisp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DateTimePicker dtp_publicacion;
        private System.Windows.Forms.DateTimePicker dtp_vencimiento;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox_proveedores;
    }
}