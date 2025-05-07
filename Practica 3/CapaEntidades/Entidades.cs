using System;

namespace CapaEntidades
{
    #region Entidades
    public class Entidades
    {
        public int IDProducto { get; set; }

        public int IDCategoria { get; set; }

        public int IDMedida { get; set; }

        public string NombreProducto { get; set; }

        public int? PrecioProducto { get; set; }

        public int? Stock { get; set; }

        public int Activo { get; set; }
    }

    #endregion
}
