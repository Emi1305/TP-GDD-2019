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
    public partial class FormProveedorNuevo : Form
    {
        Conexion con = new Conexion();
        String tipoFormulario;
        String razonSocial;
        String domicilio;
        String ciudad;
        String telefono;
        String cuit;
        String rubro;
        String estadoBaja;
        String mail;
        String codigoPostal;
        String contacto;
        int idProveedor;

        public FormProveedorNuevo(String tipoFormulario, String razonSocial, String domicilio, String ciudad, String telefono, String cuit, String rubro, String estadoBaja, String mail, String codigoPostal, String contacto, int idProveedor)
        {
            this.tipoFormulario = tipoFormulario;
            this.razonSocial = razonSocial;
            this.domicilio = domicilio;
            this.ciudad = ciudad;
            this.telefono = telefono;
            this.cuit = cuit;
            this.rubro = rubro;
            this.estadoBaja = estadoBaja;
            this.mail = mail;
            this.codigoPostal = codigoPostal;
            this.contacto = contacto;
            this.idProveedor = idProveedor;
            InitializeComponent();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            refreshlistaRubro();
            cmbEstadoBaja.SelectedIndex = cmbEstadoBaja.FindString("N");

            if (String.Equals(tipoFormulario, "UPDATE"))
            {
                txtCiudad.Text = ciudad;
                txtCodigoPostal.Text = codigoPostal;
                txtContacto.Text = contacto;
                txtCuit.Text = cuit;
                txtDomicilio.Text = domicilio;
                cmbEstadoBaja.SelectedIndex = cmbEstadoBaja.FindString(estadoBaja);
                txtMail.Text = mail;
                txtRazonSocial.Text = razonSocial;
                txtTelefono.Text = telefono;
                cmbRubro.SelectedIndex = cmbRubro.FindStringExact(rubro);
            }

        }

        private void refreshlistaRubro()
        {
            DataSet listaRubros = con.getRubros();
            cmbRubro.DataSource = listaRubros.Tables[0];
            cmbRubro.ValueMember = "id";
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
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormProveedor menu = new FormProveedor();
            menu.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            int rubro = Convert.ToInt32(cmbRubro.SelectedValue.ToString());
            String telefono = txtTelefono.Text;
            String codigoPostal = txtCodigoPostal.Text;
            String ciudad = txtCiudad.Text;
            String contacto = txtContacto.Text;
            String cuit = txtCuit.Text;
            String domicilio = txtDomicilio.Text;
            String estadoBaja = cmbEstadoBaja.SelectedItem.ToString();
            String mail = txtMail.Text;
            String razonSocial = txtRazonSocial.Text;
            

            if (String.Equals(tipoFormulario, "UPDATE"))
            {
                con.updateProveedor(razonSocial, domicilio, ciudad, telefono, cuit, rubro, estadoBaja, mail, codigoPostal, contacto, idProveedor);
            }else{
                con.insertProveedor(razonSocial, domicilio, ciudad, telefono, cuit, rubro, estadoBaja, mail, codigoPostal, contacto);
            }

            this.Hide();
            FormProveedor menu = new FormProveedor();
            menu.Show();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, "  ^ [0-9]"))
            {
                txtTelefono.Text = "";
            }
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCodigoPostal.Text, "  ^ [0-9]"))
            {
                txtCodigoPostal.Text = "";
            }
        }
        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
