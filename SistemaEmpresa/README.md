# SistemaEmpresa

Sistema de gestión empresarial desarrollado en C# con arquitectura en capas (Capas de Datos, Capas de Negocio, Capas de Presentación y Capas de Entidades), utilizando Windows Forms y SQL Server para la persistencia de datos.

## Estructura del Proyecto

- **CapaDatos**: Manejo de la conexión a la base de datos y ejecución de consultas SQL.
- **CapaNegocio**: Lógica de negocio y validación de datos antes de acceder a la capa de datos.
- **CapaPresentacion**: Interfaz gráfica de usuario desarrollada en Windows Forms.
- **CapaEntidades**: Definición de las entidades que representan los datos del sistema.

## Requisitos

- Visual Studio 2022 o superior
- .NET Framework 4.7.2 o superior
- SQL Server

## Configuración

1. Clonar el repositorio:
   ```bash
   git clone <url-del-repositorio>

2. Abrir el proyecto en Visual Studio
3. Configurar la cadena de conexión en el archivo app.config de CapaDatos o cambiado la cadena de conexion por la tuya.
4. Ejecutar el script SQL proporcionado para crear la base de datos y las tablas necesarias.

## Ejecucion

1. Establecer CapaPresentacion como el proyecto de inicio.
2. Compilar y ejecutar el proyecto.
3. Navegar a través de las funcionalidades del sistema desde la interfaz gráfica.

## Funcionalidades
1. Gestión de usuarios
2. Gestión de productos
3. Gestión de ventas
4. Reportes Detallados

## Contribución

Si deseas contribuir, crea un fork del proyecto y envía un pull request con tus cambios.

## Autor

Proyecto desarrollado por Jose Genuel Mercedes Abreu A.K.A *Mrrobotcode*.