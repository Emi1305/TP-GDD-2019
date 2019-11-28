using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaOfertas.AbmUsuario
{
    public partial class AbmUsuario : Form
    {
        Conexion con = new Conexion();

        public AbmUsuario()
        {
            InitializeComponent();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            refreshlistaUsuarios();
            gridUsuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            cmbEstadoCuenta.Visible = false;
        }

        private void addItemToCmb(String text, String value)
        {
        }

        private void refreshlistaUsuarios()
        {
            DataTable listaUsuarios = con.getListaUsuarios();
            gridUsuario.DataSource = listaUsuarios;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        public string encriptarSHA256(string mensaje)
        {
            var byteMensaje = Encoding.ASCII.GetBytes(mensaje);
            var sha = new SHA256Managed();
            var shaConMensaje = sha.ComputeHash(byteMensaje);
            System.Text.StringBuilder resultado = new StringBuilder();
            foreach (byte b in shaConMensaje)
            {
                //escribirlo como hexa
                resultado.Append(b.ToString("x2"));
            }
            return resultado.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTextoExacto.Text = "";
            txtTextoLibre.Text = "";
            cmbEstadoCuenta.SelectedValue = "";
            checkBuscarEstado.Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String textoExacto = txtTextoExacto.Text;
            String textoLibre = txtTextoLibre.Text;
            String estadoCuenta = "";
            if (checkBuscarEstado.Checked)
            {
                estadoCuenta = cmbEstadoCuenta.SelectedItem.ToString();
            }
            DataTable ds = con.getUsuarioByFiltro(textoExacto, textoLibre, estadoCuenta);
            gridUsuario.DataSource = ds;
        }

        private void checkBuscarEstado_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBuscarEstado.Checked)
            {
                cmbEstadoCuenta.Visible = true;
            }
            else
            {
                cmbEstadoCuenta.Visible = false;
            }
        }

        private void cmbEstadoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            String codUsuario = this.gridUsuario.CurrentRow.Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Esta seguro que quiere eliminar el Usuario : " + codUsuario, "Borrar Usuario", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                con.deleteEstadoUsuario(codUsuario);
                con.borrarUsuario(codUsuario);
            }

            refreshlistaUsuarios();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AbmUsuarioMain menu = new AbmUsuarioMain(this);
            menu.Show();
        }

        private void gridUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
