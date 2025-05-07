# Mantenimiento de Productos

Sistema de mantenimiento de productos desarrollado en C# con arquitectura en capas (Capas de Datos, Capas de Negocio, Capa de Presentación y Capa de Entidades), utilizando Windows Forms, SQL Server para la persistencia de datos y Report Viewer (Reportes).

## 📂 Estructura del Proyecto

* **CapaDatos**: Manejo de la conexión a la base de datos y ejecución de consultas SQL.
* **CapaNegocio**: Lógica de negocio y validación de datos antes de acceder a la capa de datos.
* **CapaPresentacion**: Interfaz gráfica de usuario desarrollada en Windows Forms.
* **CapaEntidades**: Definición de las entidades que representan los datos del sistema.

## 🛠️ Requisitos

* Visual Studio 2022 o superior
* .NET Framework 4.7.2 o superior
* SQL Server

## ⚙️ Configuración

1. Clonar el repositorio:

   ```bash
   git clone <url-del-repositorio>
   ```

2. Abrir el proyecto en Visual Studio.
3. Configurar la cadena de conexión en el archivo `app.config` de **CapaDatos**:

   ```xml
   <connectionStrings>
       <add name="MiConexion" connectionString="Data Source=SERVIDOR;Initial Catalog=BaseDatosEmpresa;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. Ejecutar el script SQL proporcionado para crear la base de datos y las tablas necesarias.

## 🚀 Ejecución

1. Establecer **CapaPresentacion** como el proyecto de inicio.
2. Ejecuta el script de SQL.
3. Cambia la cadena de conexion de la clase Conexion.cs o cambia el archivo app.config
4. Compilar y ejecutar el proyecto.
5. Navegar a través de las funcionalidades del sistema desde la interfaz gráfica.

## ✨ Funcionalidades

* Gestión de productos
* Gestión de ventas
* Reportes detallados
* Visualizacion de productos

## 📝 Ejemplos de Código

### CapaDatos - Ejemplo de Conexión:

```csharp
public class Conexion
{
    private SqlConnection conexion = new SqlConnection("Data Source=SERVIDOR;Initial Catalog=BaseDatosEmpresa;Integrated Security=True");

    public SqlConnection AbrirConexion()
    {
        if (conexion.State == ConnectionState.Closed)
            conexion.Open();
        return conexion;
    }

    public SqlConnection CerrarConexion()
    {
        if (conexion.State == ConnectionState.Open)
            conexion.Close();
        return conexion;
    }
}
```

### CapaNegocio - Ejemplo de Lógica de Negocio:

```csharp
public class ClienteNegocio
{
    public bool ValidarCliente(string nombre, string documento)
    {
        // Lógica de validación
        return !string.IsNullOrEmpty(nombre) && documento.Length == 10;
    }
}
```

### CapaEntidades - Ejemplo de Entidad:

```csharp
public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Documento { get; set; }
    public string Telefono { get; set; }
}
```

### CapaPresentacion - Ejemplo de Windows Forms:

```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    ClienteNegocio clienteNegocio = new ClienteNegocio();
    if (clienteNegocio.ValidarCliente(txtNombre.Text, txtDocumento.Text))
    {
        MessageBox.Show("Cliente registrado correctamente.");
    }
    else
    {
        MessageBox.Show("Datos inválidos, por favor revise la información.");
    }
}
```

## 🤝 Contribución

Si deseas contribuir, crea un fork del proyecto y envía un pull request con tus cambios.

## 👤 Autor

Proyecto desarrollado por Jose Genuel Mercedes Abreu A.K.A **Mrrobotcode**.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - mira el archivo [LICENSE](LICENSE) para más detalles.