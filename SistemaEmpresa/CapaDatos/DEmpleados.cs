using System;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class DEmpleados
    {
        public DataTable Listar_cat()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            
            using (SqlConnection conexion = Conexion.GetInstancia().CreaConexion())
            {
                try
                {
                    conexion.Open();
                    
                    using (SqlCommand cmd = new SqlCommand("sp_LeerEmpleados", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        resultado = cmd.ExecuteReader();
                        tabla.Load(resultado);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
            return tabla;
        }

        public DataTable Buscar_emp(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_BuscarEmpleadoPorNombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre_Empleado", SqlDbType.VarChar).Value = valor;
                conexion.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (SqlException ex)
            {
                conexion = null;
                throw ex;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public string Guardar_emp(EEmpleados datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();
            
            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_InsertaEmpleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_Empleado", SqlDbType.Int).Value = datos.ID;
                cmd.Parameters.Add("@Nombre_Empleado", SqlDbType.VarChar).Value = datos.Nombre;
                cmd.Parameters.Add("@Cargo_Empleado", SqlDbType.VarChar).Value = datos.Cargo;
                conexion.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public string Actualizar_emp(EEmpleados datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_ActualizarEmpleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_Empleado", SqlDbType.Int).Value = datos.ID;
                cmd.Parameters.Add("@Nombre_Empleado", SqlDbType.VarChar).Value = datos.Nombre;
                cmd.Parameters.Add("@Cargo_Empleado", SqlDbType.VarChar).Value = datos.Cargo;
                conexion.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return respuesta;
        }

        public string Eliminar_emp(EEmpleados datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_Empleado", SqlDbType.Int).Value = datos.ID;
                conexion.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return respuesta;
        }
    }
}