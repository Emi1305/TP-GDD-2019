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

        private void MenuForm_Load(object sender, EventArgs e)
        {
            //this.mostrarMenusValidos();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();

        }
    }
}
