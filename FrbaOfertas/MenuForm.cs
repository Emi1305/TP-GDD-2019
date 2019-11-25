﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class MenuForm : Form
    {
        private delegate void MostrarMenus();
        private MostrarMenus mostrarMenusValidos;
        private Form loginForm;

        public MenuForm(Form f )
        {
            InitializeComponent();
            loginForm = f;
        }

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            //this.mostrarMenusValidos();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmUsuario.AbmUsuario pantallaUsuario = new AbmUsuario.AbmUsuario();
            pantallaUsuario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmRol.FormRol pantallaRol = new AbmRol.FormRol();
            pantallaRol.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListadoEstadistico.FormListadoEstadistico formularioEstadistico = new ListadoEstadistico.FormListadoEstadistico();
            formularioEstadistico.Show();
        }
    }
}
