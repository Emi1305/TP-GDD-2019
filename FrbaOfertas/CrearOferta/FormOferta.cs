using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FrbaOfertas.CrearOferta
{
    public partial class FormOferta : Form
    {

        private Conexion con = new Conexion();

        public FormOferta()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int proveedor = Convert.ToInt32(comboBox_proveedores.SelectedValue.ToString());
            String descripcion = textBox_descripcion.Text;
            DateTime fecPublicacion = dtp_publicacion.Value;
            DateTime fecVencimiento = dtp_vencimiento.Value;
            double precioOferta = Convert.ToDouble(textBox_precioOferta.Text);
            double precioLista = Convert.ToDouble(textBox_precioLista.Text!="" ? textBox_precioLista.Text : "0");
            int cantidad = Convert.ToInt16(textBox_cantDisp.Text!="" ? textBox_cantDisp.Text : "0");

            con.insertOferta(proveedor, descripcion, fecPublicacion, fecVencimiento, precioLista, precioOferta, cantidad);


            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void FormOferta_Load(object sender, EventArgs e)
        {

        }

        private void refreshlistaProveedor()
        {
            //TODO no anda el llenado del combo => no pude probar el insert
            DataSet ds = con.getProveedores();
            comboBox_proveedores.DataSource = ds.Tables[0];
            comboBox_proveedores.ValueMember = "idProveedor";
            comboBox_proveedores.DisplayMember = "razonSocial";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
        }
    }
}
