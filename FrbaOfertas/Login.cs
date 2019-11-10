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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (passwordValida())
            {
                this.textBox_usuario.Clear();
                this.textBox_password.Clear();
                this.Hide();
                MenuForm menu = new MenuForm(this);
                menu.Show();
            }

        }

        private bool passwordValida()
        {
            // TODO: Validar la password
            return true;
        }
    }
}
