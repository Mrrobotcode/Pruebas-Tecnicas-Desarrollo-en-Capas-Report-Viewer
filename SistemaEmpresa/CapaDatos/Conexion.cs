using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private static Conexion instancia = null;

        private string conexionDB = "Server = DESKTOP-3HAPOGA; Database = Empresa; Integrated security = true;";

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
}
