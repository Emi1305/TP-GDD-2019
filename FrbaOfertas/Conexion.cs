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

        public DataTable getListaUsuarios()
        {
            DataTable dt = new DataTable();
            string q = "select u.codUsuario, ec.bloqueada, ec.baja from Usuario u LEFT JOIN EstadoCuenta ec ON u.codUsuario = ec.codUsuario";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getListaUsuarios : " + e.ToString());
            }

            return dt;
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

        public bool insertUsuario(string codUsuario, string pass)
        {

            string q = "Insert into Usuario (codUsuario,password) values ('" + codUsuario + "','" + pass + "')";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void insertRolUsuario(string codUsuario, string codRol)
        {
            string q = "Insert into UsuarioRol (codigoUsuario,codigoRol) values ('" + codUsuario + "','" + codRol + "')";
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
                MessageBox.Show("Error ejecutando query getRolesUsuario : " + e.ToString());
            }

            return ds;
        }

        public DataTable getRolesFiltroExacto(String palabraFiltroExacto)
        {
            DataTable dataTable = new DataTable();
            string q = "Select * from Rol where descripcion = '" + palabraFiltroExacto + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getRolesFiltroExacto : " + e.ToString());
            }

            return dataTable;
        }

        public DataTable getRolesFiltroLibre(String palabraFiltroLibre)
        {
            DataTable dataTable = new DataTable();
            string q = "Select * from Rol where descripcion like '%" + palabraFiltroLibre + "%'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getRolesFiltroLibre : " + e.ToString());
            }

            return dataTable;
        }

        public DataTable getRolesFiltroMix(String palabraFiltroLibre, String palabraFiltroExacto)
        {
            DataTable dataTable = new DataTable();
            string q = "Select * from Rol where descripcion like '%" + palabraFiltroLibre + "%' and descripcion = '" + palabraFiltroExacto + "'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getRolesFiltroMix : " + e.ToString());
            }

            return dataTable;
        }

        public bool agregarRol(String codRol, String descRol)
        {
            string q = "Insert into Rol(codigo,descripcion) values ('" + codRol + "','" +descRol+ "')";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteRol(String codRol)
        {
            string q = "Delete from Rol where codigo = '" + codRol + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool ActualizarRol(String codRol,String descRol){
            string q = "Update Rol set descripcion = '" + descRol + "' where codigo = '" + codRol + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteFuncionalidadRol(String codRol)
        {
            string q = "Delete from FuncionalidadRol where codRol = '" + codRol + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable getFuncionalidadesPorCodRol(String codRol)
        {
            DataTable dataTable = new DataTable();
            string q = "Select f.codFuncionalidad, f.descFuncionalidad from FuncionalidadRol fr, Funcionalidad f where fr.codRol = '" + codRol + "' and fr.codFuncionalidad = f.codFuncionalidad";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getFuncionalidadesPorCodRol : " + e.ToString());
            }

            return dataTable;
        }

        public DataSet getFuncionalidades()
        {
            DataSet ds = new DataSet();
            string q = "Select * from Funcionalidad ";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getFuncionalidades : " + e.ToString());
            }

            return ds;
        }

        public bool agregarFuncionalidadARol(String codFuncionalidad, String codRol)
        {
            string q = "Insert into FuncionalidadRol(codFuncionalidad,codRol) values ('" + codFuncionalidad + "','" + codRol + "')";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable getUsuarioByFiltro(String textoExacto, String textoLibre, String estadoCuenta)
        {
            StringBuilder q = new StringBuilder("select u.codUsuario, ec.bloqueada, ec.baja from Usuario u LEFT JOIN EstadoCuenta ec ON u.codUsuario = ec.codUsuario where 1=1 ", 500);
            if (!String.IsNullOrEmpty(textoExacto))
            {
                q.Append(" and u.codUsuario= '" + textoExacto + "' ");
            }
            if (!String.IsNullOrEmpty(textoLibre))
            {
                q.Append(" and u.codUsuario like '%" + textoLibre + "%' ");
            }
            if (String.Equals(estadoCuenta,"Baja"))
            {
                q.Append(" and ec.baja = 'S' ");
            }
            else if (String.Equals(estadoCuenta, "Bloqueada"))
            {
                q.Append(" and ec.bloqueada = 'S' ");
            }

            DataTable ds = new DataTable();
            
            try
            {
                Console.WriteLine(q.ToString());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q.ToString(), cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getUsuarioByFiltro : " + e.ToString());
            }

            return ds;
        }
        public void borrarUsuario(string codUsuario)
        {

            string q = "Delete Usuario where codUsuario = '" + codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query borrarUsuario : " + e.ToString());
            }
        }

        public void deleteEstadoUsuario(string codUsuario)
        {

            string q = "Delete EstadoCuenta where codUsuario = '" + codUsuario + "'";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query deleteEstadoUsuario : " + e.ToString());
            }
        }

        public DataSet getRolesComunes()
        {
            DataSet ds = new DataSet();
            string q = "Select * from Rol where codigo != 'ADM'";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getRolesComunes : " + e.ToString());
            }

            return ds;
        }

        public DataSet getRubros()
        {
            DataSet ds = new DataSet();
            string q = "Select * from Rubro";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getRubros : " + e.ToString());
            }

            return ds;
        }

        public DataTable getListaProveedores()
        {
            DataTable dt = new DataTable();
            string q = "select p.razonSocial, p.domicilio, p.ciudad, p.telefono, p.cuit, r.nombre  as rubro ,p.baja as EstadoProveedor,p.mail,p.codigoPostal,p.contacto ,p.idProveedor from Proveedor p , Rubro r";
            try
            {
                Console.WriteLine(q);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q, cn);
                dataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getListaProveedores : " + e.ToString());
            }

            return dt;
        }

        public DataTable getProveedoresByFiltro(String textoExacto, String textoLibre, String rubro)
        {
            StringBuilder q = new StringBuilder("select p.razonSocial, p.domicilio, p.ciudad, p.telefono, p.cuit, r.nombre as rubro ,p.baja as EstadoProveedor,p.mail,p.codigoPostal,p.contacto ,p.idProveedor from Proveedor p , Rubro r where p.rubro = r.id", 800);
            if (!String.IsNullOrEmpty(textoExacto))
            {
                q.Append(" and (p.razonSocial= '" + textoExacto + "' or p.mail = '" + textoExacto + "' or p.cuit = '" + textoExacto + "') ");
            }
            if (!String.IsNullOrEmpty(textoLibre))
            {
                q.Append(" and (p.razonSocial like '%" + textoLibre + "%' or p.mail like  '%" + textoLibre + "%' or p.cuit like '%" + textoLibre + "%') ");
            }
            if (!String.IsNullOrEmpty(rubro))
            {
                q.Append(" and (r.nombre = '"+rubro+  "')");
            }

            DataTable dt = new DataTable();

            try
            {
                Console.WriteLine(q.ToString());
                SqlDataAdapter dataAdapter = new SqlDataAdapter(q.ToString(), cn);
                dataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query getProveedoresByFiltro : " + e.ToString());
            }

            return dt;
        }

        public void insertProveedor(String razonSocial, String domicilio, String ciudad, String telefono, String cuit, int rubro, String estadoBaja, String mail, String codigoPostal, String contacto)
        {
            long longCodigoPostal = !String.IsNullOrEmpty(codigoPostal) ? Convert.ToInt64(codigoPostal) : 0L;
            int intTelefono = !String.IsNullOrEmpty(telefono) ? Convert.ToInt32(telefono) : 0;
            string q = "Insert into Proveedor(razonSocial,domicilio,ciudad,telefono,mail,codigoPostal,contacto,cuit,baja,rubro) values ('" + razonSocial + "','" + domicilio + "','" + ciudad + "'," + intTelefono + ",'" + mail + "', " + longCodigoPostal + ", '" + contacto + "','" + cuit + "','" + estadoBaja + "'," + rubro + ")";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query insertProveedor : " + e.ToString());
            }
        }

        public void updateProveedor(String razonSocial, String domicilio, String ciudad, String telefono, String cuit, int rubro, String estadoBaja, String mail, String codigoPostal, String contacto, int idProveedor)
        {
            long longCodigoPostal = !String.IsNullOrEmpty(codigoPostal) ? Convert.ToInt64(codigoPostal) : 0L;
            int intTelefono = !String.IsNullOrEmpty(telefono) ? Convert.ToInt32(telefono) : 0;
            string q = "Update Proveedor set razonSocial = '" + razonSocial + "' , domicilio = '" + domicilio + "' , ciudad = '" + ciudad + "', telefono =  " + intTelefono + ", mail = '" + mail + "', codigoPostal = " + longCodigoPostal + ",contacto = '" + contacto + "',cuit='" + cuit + "',baja = '" + estadoBaja + "',rubro = " + rubro + " where idProveedor = " + idProveedor + "";
            try
            {
                Console.WriteLine(q);
                cmd = new SqlCommand(q, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error ejecutando query updateProveedor : " + e.ToString());
            }
        }

    }
}
