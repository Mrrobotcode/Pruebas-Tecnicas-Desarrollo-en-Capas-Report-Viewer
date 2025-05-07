using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NCategorias
    {
        public static DataTable Listar_ca(string texto)
        {
           DCategorias datos = new DCategorias();
           return datos.Listar_ca(texto);
        }

        public static string Guardar_ca(int opcion,ECategorias ca)
        {
            DCategorias datos = new DCategorias();
            return datos.Guardar_ca(opcion, ca);
        }

        public static string Eliminar_ca(int codigo)
        {
            DCategorias datos = new DCategorias();
            return datos.Eliminar_ca(codigo);
        }
    }
}
