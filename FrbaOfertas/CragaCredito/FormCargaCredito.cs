using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CragaCredito
{
    public partial class FormCargaCredito : Form
    {
        Conexion con = new Conexion();

        public FormCargaCredito()
        {
            InitializeComponent();
        }

        private void FormCargaCredito_Load(object sender, EventArgs e)
        {
            String fecha = System.Configuration.ConfigurationManager.AppSettings["fecha"];
            label5.Text = fecha ;
            refreshlistaTipoPago();
        }

        private void refreshlistaTipoPago()
        {
            DataSet listaRubros = con.getTipoPago();
            cmbTipoPago.DataSource = listaRubros.Tables[0];
            cmbTipoPago.ValueMember = "codigo";
            cmbTipoPago.DisplayMember = "descripcion";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrbaOfertas.Menu form = new FrbaOfertas.Menu();
            form.Show();
        }

        private void btnCargarCredito_Click(object sender, EventArgs e)
        {
            long numeroTarjeta = Convert.ToInt64(txtNumTarjeta.Text);
            int tipoPago = Convert.ToInt32(cmbTipoPago.SelectedValue.ToString());
            long monto = Convert.ToInt64(txtMonto.Text);
            String fecha = label5.Text ;
            int idCliente = 1 ;
            con.insertCarga(monto,fecha,tipoPago,idCliente,numeroTarjeta);
        }
    }
}
