using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

//yahshuah2005
//23012464@3STUD14NT3S
//wrln.cruz

namespace CapaDatos
{
    public class Productos
    {
        #region Utilizacion de los stored procedure

        public DataTable Listar_cat()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexion.GetInstancia().CreaConexion())
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListadoProductos", conexion))
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

        public string Guardar_producto(Entidades datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_GuardarProducto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre_Producto", SqlDbType.VarChar).Value = datos.NombreProducto;
                cmd.Parameters.Add("@ID_Medida", SqlDbType.Int).Value = datos.IDMedida;
                cmd.Parameters.Add("@ID_Categoria", SqlDbType.Int).Value = datos.IDCategoria;
                cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = datos.PrecioProducto;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = datos.Stock;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = datos.Activo;
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

        public DataTable Listar_Categorias()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexion.GetInstancia().CreaConexion())
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Listar_Categorias", conexion))
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

        public DataTable Listar_Medidas()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexion.GetInstancia().CreaConexion())
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Listar_Medidas", conexion))
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

        public DataTable Buscar_producto(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_BuscarProductoPorNombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre_Producto", SqlDbType.VarChar).Value = valor;
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

        public string Eliminar_producto(Entidades datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_Producto", SqlDbType.Int).Value = datos.IDProducto;
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

        public string Actualizar_producto(Entidades datos)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID_Producto", SqlDbType.Int).Value = datos.IDProducto;
                cmd.Parameters.Add("@Nombre_Producto", SqlDbType.VarChar).Value = datos.NombreProducto;
                cmd.Parameters.Add("@ID_Medida", SqlDbType.Int).Value = datos.IDMedida;
                cmd.Parameters.Add("@ID_Categoria", SqlDbType.Int).Value = datos.IDCategoria;
                cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = datos.PrecioProducto;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = datos.Stock;
                cmd.Parameters.Add("@Activo", SqlDbType.Int).Value = datos.Activo;
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

        #endregion
    }
}