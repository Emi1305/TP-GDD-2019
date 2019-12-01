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
        private String nombre;
        private String apellido;
        private String mail;
        private String direccion;
        private String ciudad;
        private int dni;
        private int telefono;
        private DateTime fechaNacimiento;
        private bool update = false;

        public FormClienteNuevo()
        {
            InitializeComponent();
        }

        public FormClienteNuevo(String nombre, String apellido, int dni, int telefono, String mail, String direccion, String ciudad, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.mail = mail;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.fechaNacimiento = fechaNacimiento;
            this.update = true;
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            textBox_dni.Text = dni==0 ? "" : dni.ToString() ;
            textBox_apellido.Text = apellido;
            textBox_nombre.Text = nombre;
            textBox_localidad.Text = ciudad;
            textBox_mail.Text = mail;
            textBox_calle.Text = direccion;
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
            new FormCliente().Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int dniID = this.dni;
            int dni = Convert.ToInt32(textBox_dni.Text!="" ? textBox_dni.Text : "0");
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
                if (update)
                {
                    con.updateCliente(dniID, nombre, apellido, dni, telefono, mail, direccion, ciudad, fechaNacimiento);
                }
                else
                {
                    con.insertCliente(nombre, apellido, dni, telefono, mail, direccion, ciudad, fechaNacimiento);
                    //TODO insertar dinero $200
                }
                this.Hide();
                new FrbaOfertas.AbmCliente.FormCliente().Show();
            }    
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando query insertCliente : " + ex.ToString());

            }

        }
    }
}
