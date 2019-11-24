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
    public partial class FormRol : Form
    {
        Conexion con = new Conexion();

        public FormRol()
        {
            InitializeComponent();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            refreshListaRoles();
        }

        private void refreshListaRoles()
        {
            DataTable listaRoles = con.getRoles();
            gridRoles.DataSource = listaRoles;
        }

        private void gridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menu = new MenuForm(this);
            menu.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro1.Text = "";
            txtFiltro2.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String palabraFiltroLibre = txtFiltro1.Text.ToLower();
            String palabraFiltroExacto = txtFiltro2.Text.ToLower();
            if (string.IsNullOrEmpty(palabraFiltroLibre))
            {
                if (string.IsNullOrEmpty(palabraFiltroExacto))
                {
                    refreshListaRoles();
                }
                else
                {
                    DataTable listaRoles = con.getRolesFiltroExacto(palabraFiltroExacto);
                    gridRoles.DataSource = listaRoles;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(palabraFiltroExacto))
                {
                    DataTable listaRoles = con.getRolesFiltroLibre(palabraFiltroLibre);
                    gridRoles.DataSource = listaRoles;
                }
                else
                {
                    DataTable listaRoles = con.getRolesFiltroMix(palabraFiltroLibre, palabraFiltroExacto);
                    gridRoles.DataSource = listaRoles;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRolNuevo formulario = new FormRolNuevo();
            formulario.Show();
        }

        private void gridRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            FormRolFuncionalidad formulario = new FormRolFuncionalidad(this.gridRoles.CurrentRow.Cells[0].Value.ToString(), this.gridRoles.CurrentRow.Cells[1].Value.ToString(), "modificacion");
            formulario.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String codRol = this.gridRoles.CurrentRow.Cells[0].Value.ToString();
            String descRol = this.gridRoles.CurrentRow.Cells[1].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Esta seguro que quiere eliminar el Rol : " + descRol, "Borrar Rol", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                bool resultadoDeleteFuncionalidadRol = con.deleteFuncionalidadRol(codRol);
                bool resultadoDeleteRol = con.deleteRol(codRol);
            }

            refreshListaRoles();
        }
    }
}
