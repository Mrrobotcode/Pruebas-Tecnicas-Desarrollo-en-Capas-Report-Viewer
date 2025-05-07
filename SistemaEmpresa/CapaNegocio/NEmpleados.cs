using System;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NEmpleados
    {
        public static DataTable Listar_cat()
        {
            DEmpleados datos = new DEmpleados();
            DataTable resultado = datos.Listar_cat();
            
            if (resultado.Rows.Count == 0)
            {
                throw new Exception("No se encontraron datos en el procedimiento almacenado");
            }
            return resultado;
        }

        public static DataTable Buscar_emp(string valor)
        {
            DEmpleados datos = new DEmpleados();
            DataTable resultado = datos.Buscar_emp(valor);

            if (resultado.Rows.Count == 0)
            {
                throw new Exception("No se encontro este empleado");
            }
            return resultado;
        }

        public static string Guardar_emp(EEmpleados datos)
        {
            DEmpleados emp = new DEmpleados();            
            return emp.Guardar_emp(datos);
        }

        public static string Actualizar_emp(EEmpleados datos)
        {
            DEmpleados emp = new DEmpleados();
            return emp.Actualizar_emp(datos);
        }

        public static string Eliminar_emp(EEmpleados id)
        {
            DEmpleados emp = new DEmpleados();
            return emp.Eliminar_emp(id);
        }

        public static bool ValidacionesGuardar(EEmpleados validaciones)
        {
            if (validaciones == null || validaciones.ID == null || string.IsNullOrWhiteSpace(validaciones.Nombre) || string.IsNullOrWhiteSpace(validaciones.Cargo))
            {
                return true;
            }

            return false;
        }

        public static bool ValidacionesEliminar(EEmpleados validaciones)
        {
            if (validaciones?.ID == null)
            {
                return true;
            }

            return false;
        }

        public static bool ValidacionesActualizar(EEmpleados validaciones)
        {
            return ValidacionesGuardar(validaciones);
        }

        public static bool ValidacionesBuscar(EEmpleados validaciones)
        {
            if (validaciones == null || string.IsNullOrWhiteSpace(validaciones.Nombre))
            {
                return true;
            }

            return false;
        }
    }
}