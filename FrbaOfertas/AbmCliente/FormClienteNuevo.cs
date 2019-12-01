using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class FormClienteNuevo : Form
    {
        Conexion con = new Conexion();

        public FormClienteNuevo()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void Calle_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormClienteNuevo fc = new FormClienteNuevo();
            fc.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(textBox_dni.Text);
            DateTime fechaNacimiento = dtp_fecNacimiento.Value;
            String nombre = textBox_nombre.Text;
            String apellido = textBox_apellido.Text;
            String telefono = textBox_telefono.Text;
            String mail = textBox_mail.Text;
            String ciudad = textBox_localidad.Text;
            String direccion = textBox_calle.Text + " " + textBox_numero.Text + " " + textBox_piso.Text + 
                " " + textBox_departamento.Text + " " + textBox_codPostal.Text;

            try
            {
                con.insertCliente(nombre, apellido, dni, telefono, mail, direccion, ciudad, fechaNacimiento);
                this.Hide();
                new FrbaOfertas.Menu().Show();
            }    
            catch (Exception ex)
            {
                
            }

        }
    }
}
