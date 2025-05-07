using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    #region Conexion de la base de datos
    public class Conexion
    {
        private static Conexion instancia = null;

        private string conexionDB = "Server = DESKTOP-3HAPOGA; Database = Ventas; Integrated security = true;";

        public static Conexion GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Conexion();
            }
            return instancia;
        }

        public SqlConnection CreaConexion()
        {
            SqlConnection conexion = new SqlConnection(conexionDB);
            return conexion;
        }
    }

    #endregion
}