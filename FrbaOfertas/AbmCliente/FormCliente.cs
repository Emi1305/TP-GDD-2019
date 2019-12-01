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
    public partial class FormCliente : Form
    {

        FrbaOfertas.Conexion con = new FrbaOfertas.Conexion();

        public FormCliente()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            String nombre = textBox_nombre.Text;
            String apellido = textBox_apellido.Text;
            String mail = textBox_mail.Text;
            int dni = Convert.ToInt32(textBox_dni.Text!="" ? textBox_dni.Text : "0");

            DataTable ds = con.getClientesByFiltro(nombre, apellido, dni, mail);
            gridClientes.DataSource = ds;
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente.FormClienteNuevo().Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            textBox_dni.Text = "";
            DataTable ds = con.getClientesByFiltro("", "", 0, "");
            ds.Columns.IndexOf("nombre");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_mail.Text = "";
            textBox_dni.Text = "";
            FormCliente_Load(this, null);
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            String nombre = this.gridClientes.CurrentRow.Cells[0].Value.ToString();
            String apellido = this.gridClientes.CurrentRow.Cells[1].Value.ToString();
            String strDNI = this.gridClientes.CurrentRow.Cells[2].Value.ToString();
            int dni = Convert.ToInt32(strDNI != "" ? strDNI : "0");
            String strTelefono = this.gridClientes.CurrentRow.Cells[3].Value.ToString();
            int telefono = Convert.ToInt32(strTelefono != "" ? strTelefono : "0");
            String mail = this.gridClientes.CurrentRow.Cells[4].Value.ToString();
            String direccion = this.gridClientes.CurrentRow.Cells[5].Value.ToString();
            String ciudad = this.gridClientes.CurrentRow.Cells[6].Value.ToString();
            DateTime fecNacimiento = DateTime.Parse(this.gridClientes.CurrentRow.Cells[7].Value.ToString());
            int idCliente = Convert.ToInt32(this.gridClientes.CurrentRow.Cells[8].Value.ToString());

            FormClienteNuevo form = new FormClienteNuevo(idCliente, nombre, apellido, dni, telefono, mail, direccion, ciudad, fecNacimiento);
            form.Show();
        }

        private void gridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
