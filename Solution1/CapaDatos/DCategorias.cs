using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;


namespace CapaDatos
{
    public class DCategorias
    {
        public DataTable Listar_ca(string texto)
        {
            DataTable tabla = new DataTable();
            SqlDataReader resultado;
            SqlConnection con = new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_listado_categoria",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@texto",texto);
                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con.State==ConnectionState.Open) con.Close();
            }
        }

        public string Guardar_ca(int opcion,ECategorias ca)
        {
            string respuesta = "";
            SqlConnection con= new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_guardar_categoria",con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@opcion",opcion);
                cmd.Parameters.AddWithValue("@codigo_ca", ca.Codigo_ca);
                cmd.Parameters.AddWithValue("@descripcion_ca", ca.Descripcion_ca);
                con.Open();
                respuesta=cmd.ExecuteNonQuery()==1?"OK":"No se ejecutó la consulta.";
            }
            catch (Exception ex)
            {
                respuesta=ex.Message;
            }
            finally
            {
                if (con.State==ConnectionState.Open) con.Close();
            }
            return respuesta;
        }

        public string Eliminar_ca(int codigo)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("sp_eliminar_categoria", con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.AddWithValue("@codigo", codigo);                
                con.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro.";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return respuesta;
        }
    }
}
