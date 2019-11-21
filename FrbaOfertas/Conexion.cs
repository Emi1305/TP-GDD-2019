using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection(@"Data Source=DESKTOP-BSCUONA\SQLEXPRESS;Initial Catalog=GD2C2019;Integrated Security=True");
                cn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error conectando a BD: " + e.ToString());
            }
        }

        public DataSet getUsuario(String codUsuario, String pass)
        {
            DataSet ds = new DataSet();
            string q = "select * from Usuario where codUsuario = '" + codUsuario + "' and password ='" + pass + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getUsuario : " + e.ToString());
            }

            return ds;
        }

        public DataSet getUsuario(String codUsuario)
        {
            DataSet ds = new DataSet();
            string q = "select * from Usuario where codUsuario = '" + codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getUsuario : " + e.ToString());
            }

            return ds;
        }

        public DataSet getEstadoUsuario(String codUsuario) 
        {
            DataSet ds = new DataSet();
            string q = "select * from EstadoCuenta where codUsuario = '" + codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getEstadoUsuario : " + e.ToString());
            }

            return ds;
        }

        public void insertOrUpdateReintento(String codUsuario)
        {
            string q = "begin tran if exists (select * from EstadoCuenta with (updlock,serializable) where codUsuario = '" + codUsuario + "') begin update EstadoCuenta set cantidadReintentos = 1 where codUsuario = '" + codUsuario + "' end else begin insert into EstadoCuenta values ('" + codUsuario + "','N', 1) end commit tran";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query insertOrUpdateReintento : " + e.ToString());
            }
        }

        public void reiniciarReintentos(String codUsuario)
        {
            string q = "Update EstadoCuenta set cantidadReintentos = 0 where codUsuario = '" + codUsuario + "' ";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query reiniciarReintentos : " + e.ToString());
            }

        }

        public void insertUsuario(string codUsuario, string pass)
        {

            string q = "Insert into Usuario (nombre,password) values ('" + codUsuario + "','" + pass + "')";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query insertUsuario : " + e.ToString());
            }
        }

        public void insertRolUsuario(string codUsuario, string codRol)
        {
            string q = "Insert into UsuarioRol (codigoUsuario,codigoRol) values ('" + codUsuario + "','" + codRol + "')";
        }

        public DataTable getListUsuarios()
        {
            DataTable dataTable = new DataTable();
            string q = "Select * from Usuario";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getListUsuarios : " + e.ToString());
            }

            return dataTable;
        }

        public DataTable getRoles()
        {
            DataTable dataTable = new DataTable();
            string q = "Select * from Rol";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query refreshListaRoles : " + e.ToString());
            }

            return dataTable;
        }

        public DataSet getRolesUsuario(String codUsuario)
        {
            DataSet ds = new DataSet();
            string q = "select u.nombre , u.password, r.descripcion from Usuario u, Rol r, UsuarioRol ur where u.nombre = ur.codigoUsuario and ur.codigoRol = r.codigo and ur.codigoUsuario = '"+ codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getUsuario : " + e.ToString());
            }

            return ds;
        }

        public void borrarUsuario(string codUsuario)
        {

            string q = "Delete Usuario where nombre = '" + codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query insertUsuario : " + e.ToString());
            }
        }
    }
}
