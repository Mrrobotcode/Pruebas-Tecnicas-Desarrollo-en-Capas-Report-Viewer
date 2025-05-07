# Gestion de Categorias - Prueba Tecnica de Windows Form y Report Viewer

Sistema de gestión de categoria desarrollado en C# con arquitectura en capas (Capas de Datos, Capas de Negocio, Capa de Presentación y Capa de Entidades), utilizando Windows Forms, SQL Server para la persistencia de datos y Report Viewer.

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
3. Configurar la cadena de conexión en el archivo `app.config` de **CapaDatos** o cambiar la cadena de conexion en la clase Conexion.cs:

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

* Gestión de usuarios
* Gestión de productos
* Gestión de ventas
* Reportes detallados

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
public class UsuarioNegocio
{
    public bool ValidarUsuario(string usuario, string contraseña)
    {
        // Lógica de validación
        return usuario == "admin" && contraseña == "1234";
    }
}
```

### CapaEntidades - Ejemplo de Entidad:

```csharp
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
}
```

### CapaPresentacion - Ejemplo de Windows Forms:

```csharp
private void btnIngresar_Click(object sender, EventArgs e)
{
    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
    if (usuarioNegocio.ValidarUsuario(txtUsuario.Text, txtContraseña.Text))
    {
        MessageBox.Show("Bienvenido al sistema.");
    }
    else
    {
        MessageBox.Show("Usuario o contraseña incorrectos.");
    }
}
```

## 🤝 Contribución

Si deseas contribuir, crea un fork del proyecto y envía un pull request con tus cambios.

## 👤 Autor

Proyecto desarrollado por Jose Genuel Mercedes Abreu A.K.A **Mrrobotcode**.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - mira el archivo [LICENSE](LICENSE) para más detalles.
