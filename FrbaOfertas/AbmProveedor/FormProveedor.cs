using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class FormProveedor : Form
    {
        Conexion con = new Conexion();

        public FormProveedor()
        {
            InitializeComponent();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            refreshlistaProveedores();
            refreshlistaRubro();
            cmbRubro.Visible = false;
            gridProveedores.Columns["idProveedor"].Visible = false;
            gridProveedores.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void refreshlistaProveedores()
        {
            DataTable listaProveedores = con.getListaProveedores();
            gridProveedores.DataSource = listaProveedores;
        }

        private void refreshlistaRubro()
        {
            DataSet listaRubros = con.getRubros();
            cmbRubro.DataSource = listaRubros.Tables[0];
            cmbRubro.ValueMember = "nombre";
            cmbRubro.DisplayMember = "nombre";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrbaOfertas.Menu menu = new FrbaOfertas.Menu();
            menu.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTextoExacto.Text = "";
            txtTextoLibre.Text = "";
            check.Checked = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            String textoExacto = txtTextoExacto.Text;
            String textoLibre = txtTextoLibre.Text;
            String rubro = "";
            if (check.Checked)
            {
                rubro = cmbRubro.SelectedValue.ToString();
            }
            DataTable ds = con.getProveedoresByFiltro(textoExacto, textoLibre, rubro);
            gridProveedores.DataSource = ds;
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked)
            {
                cmbRubro.Visible = true;
            }
            else
            {
                cmbRubro.Visible = false;
            }
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            this.Hide();
            String a = "";
            int idProveedor = 0;
            FormProveedorNuevo form = new FormProveedorNuevo("INSERT", a, a, a, a, a, a, a, a, a, a, idProveedor);
            form.Show();
        }

        private void gridProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            String razonSocial = this.gridProveedores.CurrentRow.Cells[0].Value.ToString();
            String domicilio = this.gridProveedores.CurrentRow.Cells[1].Value.ToString();
            String ciudad = this.gridProveedores.CurrentRow.Cells[2].Value.ToString();
            String telefono = this.gridProveedores.CurrentRow.Cells[3].Value.ToString();
            String cuit = this.gridProveedores.CurrentRow.Cells[4].Value.ToString();
            String rubro = this.gridProveedores.CurrentRow.Cells[5].Value.ToString();
            String estadoBaja = this.gridProveedores.CurrentRow.Cells[6].Value.ToString();
            String mail = this.gridProveedores.CurrentRow.Cells[7].Value.ToString();
            String codigoPostal = this.gridProveedores.CurrentRow.Cells[8].Value.ToString();
            String contacto = this.gridProveedores.CurrentRow.Cells[9].Value.ToString();
            int idProveedor = Convert.ToInt32(this.gridProveedores.CurrentRow.Cells[10].Value.ToString());

            FormProveedorNuevo form = new FormProveedorNuevo("UPDATE", razonSocial, domicilio, ciudad, telefono, cuit, rubro, estadoBaja, mail, codigoPostal, contacto, idProveedor);
            form.Show();
        }

        private void gridProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
