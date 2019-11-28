using System;
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
    public partial class Menu : Form
    {
        private delegate void MostrarMenus();
        private MostrarMenus mostrarMenusValidos;
        private Form loginForm;

        public Menu(Form f )
        {
            InitializeComponent();
            loginForm = f;
        }

        public Menu()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AbmProveedor.FormProveedor formProveedor = new AbmProveedor.FormProveedor();
            formProveedor.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CragaCredito.FormCargaCredito form = new CragaCredito.FormCargaCredito();
            form.Show();
            
        }
    }
}
