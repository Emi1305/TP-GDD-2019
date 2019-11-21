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
    }
}
