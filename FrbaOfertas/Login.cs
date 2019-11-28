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

namespace FrbaOfertas
{
    public partial class Login : Form
    {
        Conexion con = new Conexion();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String codUsuario = textBox_usuario.Text;
            String pass = textBox_password.Text;
            if (passwordValida(codUsuario,pass) && usuarioDesbloqueado(codUsuario))
            {
                this.Hide();
                Menu menu = new Menu(this);
                menu.Show();
            }

        }


        private bool passwordValida(String codUsuario, String pass)
        {
            if(existeUsuario(codUsuario))
            {
                DataSet dsUsuario = con.getUsuario(codUsuario, encriptarSHA256(pass));
                if (dsUsuario.Tables[0].Rows.Count > 0)
                {
                    return true; 
                }
                else
                {
                    con.insertOrUpdateReintento(codUsuario);
                    MessageBox.Show("Password Incorrecta");
                    return false;
                }
            }else{
                MessageBox.Show("Usuario no registrado");
                return false;
            }
        }

        private bool existeUsuario(String codUsuario){
            DataSet dsUsuario = con.getUsuario(codUsuario);
            return (dsUsuario.Tables[0].Rows.Count > 0);
        }

        private bool usuarioDesbloqueado(String codUsuario)
        {
            DataSet dsUsuarioBloqueado = con.getEstadoUsuario(codUsuario);
            if (dsUsuarioBloqueado.Tables[0].Rows.Count > 0 && Equals(dsUsuarioBloqueado.Tables[0].Rows[0]["bloqueada"].ToString(),"S"))
            {
                MessageBox.Show("Usuario bloqueado, contactarse con el administrador");
                return false;
            }
            else
            {
                con.reiniciarReintentos(codUsuario);
                return true;
            }
        }

        private string encriptarSHA256(string pass)
        {
            var byteMensaje = Encoding.ASCII.GetBytes(pass);
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

        private void linkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AbmUsuario.AbmUsuarioMain menu = new AbmUsuario.AbmUsuarioMain(this);
            menu.Show();
        }
    }
}
