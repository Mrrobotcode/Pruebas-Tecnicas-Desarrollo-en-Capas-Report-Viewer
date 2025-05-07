using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class Logica
    {

        #region Validaciones
        public static bool ValidacionesGuardar(Entidades validaciones)
        {
            if (validaciones == null || string.IsNullOrWhiteSpace(validaciones.NombreProducto) || validaciones.PrecioProducto == null || validaciones.Stock == null)
            {
                return true;
            }

            return false;
        }

        public static bool ValidacionesBuscar(Entidades validaciones)
        {
            if (validaciones == null || string.IsNullOrWhiteSpace(validaciones.NombreProducto))
            {
                return true;
            }

            return false;
        }

        public static bool ValidacionesEliminar(int? id)
        {
            if (id == null)
            {
                return true;
            }

            return false;
        }

        public static bool ValidacionesActualizar(Entidades validaciones)
        {
            return ValidacionesGuardar(validaciones);
        }
        #endregion

        #region Metodos
        public static DataTable Listar_cat()
        {
            Productos datos = new Productos();
            DataTable resultado = datos.Listar_cat();
            return resultado;
        }

        public static DataTable Listar_categoria()
        {
            Productos datos = new Productos();
            DataTable resultado = datos.Listar_Categorias();
            return resultado;
        }

        public static DataTable Listar_medidas()
        {
            Productos datos = new Productos();
            DataTable resultado = datos.Listar_Medidas();
            return resultado;
        }

        public static string Guardar_pro(Entidades datos)
        {
            Productos data = new Productos();
            return data.Guardar_producto(datos);
        }

        public static DataTable Buscar_pro(string dato)
        {
            Productos datos = new Productos();
            DataTable resultado = datos.Buscar_producto(dato);
            return resultado;
        }

        public static string Eliminar_pro(Entidades id)
        {
            Productos num = new Productos();
            return num.Eliminar_producto(id);
        }

        public static string Actualizar_pro(Entidades datos)
        {
            Productos actualizarDatos = new Productos();
            return actualizarDatos.Actualizar_producto(datos);
        }
        #endregion
    }
}