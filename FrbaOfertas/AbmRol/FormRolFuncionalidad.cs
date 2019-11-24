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
    public partial class FormRolFuncionalidad : Form
    {
        Conexion con = new Conexion();

        public FormRolFuncionalidad(String codRol, String descRol, String funcionalidad)
        {
            InitializeComponent();
            if (string.Equals(funcionalidad, "creacion"))
            {
                txtCodRol.Visible = false;
                txtDescRol.Visible = false;
                txtCodRol.Text = codRol;
                txtDescRol.Text = descRol;
                txtDescRol.ReadOnly = true;
            }
            else
            {
                txtCodRol.Visible = true;
                txtDescRol.Visible = true;
                txtCodRol.Text = codRol;
                txtDescRol.Text = descRol;
            }
            refreshListaFuncionalidadesDeRol();
            refreshListaFuncionalidades();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
        }

        private void refreshListaFuncionalidadesDeRol()
        {
            String codRol = txtCodRol.Text;
            DataTable listaFuncionalidades = con.getFuncionalidadesPorCodRol(codRol);
            gridFuncionalidad.DataSource = listaFuncionalidades;
        }

        private void refreshListaFuncionalidades()
        {
            DataSet listaFuncionalidades = con.getFuncionalidades();
            cmbFuncionalidades.DataSource = listaFuncionalidades.Tables[0];
            cmbFuncionalidades.DisplayMember = "descFuncionalidad";
            cmbFuncionalidades.ValueMember = "codFuncionalidad";
        }

        private void gridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRol menu = new FormRol();
            menu.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarFuncionalidad_Click(object sender, EventArgs e)
        {
            String codRol = txtCodRol.Text; 
            String codFuncionalidad = cmbFuncionalidades.SelectedValue.ToString();
            bool resultadoAgregarFuncionalidad = con.agregarFuncionalidadARol(codFuncionalidad, codRol);
            if (resultadoAgregarFuncionalidad)
            {
                refreshListaFuncionalidadesDeRol();
            }
            else
            {
                MessageBox.Show("Error : El Rol ya posee esa funcionalidad");
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String codRol = txtCodRol.Text;
            String descRol = txtDescRol.Text;
            bool resultado = con.ActualizarRol(codRol, descRol);
            this.Hide();
            FormRol menu = new FormRol();
            menu.Show();
        }
    }
}
