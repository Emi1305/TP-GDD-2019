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
    public partial class AbmUsuarioMain : Form
    {
        Conexion con = new Conexion();

        public AbmUsuarioMain()
        {
            InitializeComponent();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            refreshListaUsuario();
        }

        private void refreshListaUsuario()
        {
            DataTable listaUsuarios = con.getListUsuarios();
            gridUsuarios.DataSource = listaUsuarios;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string passEncriptada = encriptarSHA256(pass);

            con.insertUsuario(user, passEncriptada);
            refreshListaUsuario();
            
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

        private void DataGridView1_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            String codUsuario = this.gridUsuarios.CurrentRow.Cells[0].Value.ToString();
            this.Hide();
            AbmUsuario.UpdateUsuario pantallaUsuario = new AbmUsuario.UpdateUsuario(codUsuario);
            pantallaUsuario.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            con.borrarUsuario(user);
            refreshListaUsuario();
        }

    }
}
