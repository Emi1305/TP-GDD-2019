using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmUsuario
{
    public partial class UpdateUsuario : Form
    {
        Conexion con = new Conexion();

        public UpdateUsuario(String codUsuario)
        {
            InitializeComponent();
            DataSet ds = con.getRolesUsuario(codUsuario);
            llenarCampos(ds);

        }

        private void FormRol_Load(object sender, EventArgs e)
        {

        }

        private void llenarCampos(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtUsuario.Text = dr["nombre"].ToString();
                txtPassword.Text = dr["password"].ToString();
                cmbRol.Items.Add(dr["descripcion"].ToString());
            }
        }
    }
}
