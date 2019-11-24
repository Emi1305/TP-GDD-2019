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
            DataSet listaFuncionalidades = con.getRolesComunes();
            cmbRoles.DataSource = listaFuncionalidades.Tables[0];
            cmbRoles.DisplayMember = "descripcion";
            cmbRoles.ValueMember = "codigo";
        }

        private void addItemToCmb(String text, String value)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string passEncriptada = encriptarSHA256(pass);
            if (String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Ingresar usuario y contrasena");
            }
            else
            {
                DataSet listaUsuario = con.getUsuario(user);
                if (listaUsuario.Tables[0].Rows.Count == 0)
                {
                    this.Hide();
                    Login menu = new Login();
                    menu.Show();
                }
                else 
                {
                    MessageBox.Show("El nombre de usuario ya existe, elija otro");
                    txtUser.Text = "";
                    txtPass.Text = "";
                }
            }
            con.insertUsuario(user, passEncriptada);
            
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
            MenuForm menu = new MenuForm();
            menu.Show();
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
