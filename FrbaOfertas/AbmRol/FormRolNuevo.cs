using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class FormRolNuevo : Form
    {
        Conexion con = new Conexion();

        public FormRolNuevo()
        {
            InitializeComponent();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            refreshListaFuncionalidades();
        }

        private void refreshListaFuncionalidades()
        {

            //DataTable listaFuncionalidades = con.getFuncionalidades();
            //cmbFuncionalidades.DataSource = listaRoles;
        }

        private void gridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRol formulario = new FormRol();
            formulario.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String codRol = txtCodRol.Text;
            String descRol = txtDescRol.Text;

            bool resultadoAgregarRol = con.agregarRol(codRol, descRol);

            if (resultadoAgregarRol)
            {
                this.Hide();
                FormRolFuncionalidad formulario = new FormRolFuncionalidad(codRol, descRol,"creacion");
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Error : el codigo de Rol ya existe, ingrese otro codigo de rol" );
                txtCodRol.Text = "";
                txtDescRol.Text = "";
            }
        }
    }
}
