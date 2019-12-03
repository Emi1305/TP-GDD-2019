using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class FormComprarOferta : Form
    {

        private Conexion con = new Conexion();

        public FormComprarOferta()
        {
            InitializeComponent();
        }

        private void FormComprarOferta_Load(object sender, EventArgs e)
        {
            refreshlistaClientes();
            refreshListaOfertas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Menu().Show();
        }

        private void btn_comprar_Click(object sender, EventArgs e)
        {
            int idOferta = Convert.ToInt32(this.dataGrid_Ofertas.CurrentRow.Cells[0].Value.ToString());
            int idCliente = Convert.ToInt32(this.comboBox_clientes.SelectedValue);
            double precio = Convert.ToDouble(this.dataGrid_Ofertas.CurrentRow.Cells[2].Value.ToString());

            if (con.isSaldoSuficiente(idCliente, precio))
            {
                String msg = "¿Esta seguro que quiere comprar la oferta #" + idOferta + " por $" + precio + "?";
                DialogResult dialogResult = MessageBox.Show(msg, "Comprar Oferta", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    con.comprarOferta(idCliente, idOferta, precio);
                }
            }
            else 
            {
                MessageBox.Show("Credito insuficiente para realizar la compra.");
            }
            

            refreshListaOfertas();
        }

        private void refreshListaOfertas()
        {
            DataTable listaOfertas = con.getOfertasVigentes();
            this.dataGrid_Ofertas.DataSource = listaOfertas;
        }

        private void refreshlistaClientes()
        {
            DataSet clientes = con.getClientes();
            comboBox_clientes.DataSource = clientes.Tables[0];
            comboBox_clientes.ValueMember = "idCliente";
            comboBox_clientes.DisplayMember = "nombre_completo";
        }
    }
}
