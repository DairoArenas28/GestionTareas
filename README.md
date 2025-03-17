Introducción
El sistema gestiona las tareas diarias de una persona, de manera organizada, con el propósito de facilitar la planeación del día a día. 
Cuenta con dos módulos, tareas y categorías, con la posibilidad de agregar, editar y eliminar, tanto las tareas como en las categorías. 
Además, cuenta con un autenticador integrado en el sistema, ingresando usuario y contraseña.


Diagrama de arquitectura
En el siguiente diagrama se describe el comportamiento interno del sistema, las interacciones de la base de datos, lógica del negocio y vistas.



Estructura de la base de datos
Modelo relacional de la base de datos



Categorías

Esta tabla almacena las categorías de las tareas.

ID: Identificador único de la categoría (PK).
nombre: Nombre de la categoría (obligatorio, hasta 50 caracteres).
descripcion: Descripción detallada de la categoría.
fechaCreacion: Fecha en que se creó la categoría.
inactivo: Indica si la categoría está inactiva (0 = activa, 1 = inactiva).

Tareas

Contiene las tareas que deben realizarse.

ID: Identificador único de la tarea (PK).
categoriaId: Relación con la tabla Categorías (FK1).
usuarioId: Relación con la tabla Usuarios (FK2).
estadoId: Relación con la tabla Estados (FK3).
titulo: Título de la tarea (obligatorio, hasta 100 caracteres).
descripcion: Descripción detallada de la tarea.
fechaCreacion: Fecha en que se creó la tarea.
fechaVencimiento: Fecha en que vence la tarea.
inactivo: Indica si la tarea está inactiva.

Estados

Define los diferentes estados de las tareas (ej. "Pendiente", "En progreso", "Completada").

ID: Identificador único del estado (PK).
nombreEstado: Nombre del estado de la tarea (obligatorio, hasta 50 caracteres).

Usuarios

Almacena los datos de los usuarios que gestionan las tareas.

ID: Identificador único del usuario (PK).
nombreUsuario: Nombre del usuario (obligatorio, hasta 50 caracteres).
contrasena: Contraseña encriptada (hasta 250 caracteres).
correo: Correo electrónico del usuario.
fechaCreacion: Fecha de registro del usuario.

Relaciones entre tablas
Tareas → Categorías: Cada tarea pertenece a una categoría (relación muchos a uno).
Tareas → Usuarios: Cada tarea está asignada a un usuario (relación muchos a uno).
Tareas → Estados: Cada tarea tiene un estado asignado (relación muchos a uno).

Módulos de la aplicación
Módulo de Autenticación

Este módulo se encarga del acceso seguro de los usuarios al sistema.

Funciones principales:
Registro de usuarios: Permite a los nuevos usuarios crear una cuenta.
Inicio de sesión: Valida las credenciales (nombreUsuario y contrasena) y permite el acceso.
Cifrado de contraseñas: Almacena las contraseñas de manera segura (por ejemplo, usando bcrypt).
Gestión de sesiones: Mantiene la sesión del usuario activa tras iniciar sesión.
Recuperación de contraseña: Permite a los usuarios restablecer su contraseña a través de su correo (correo).
Cierre de sesión: Finaliza la sesión del usuario.

Tablas relacionadas:
Usuarios: Contiene las credenciales y datos de cada usuario.

Módulo de Gestión de Tareas

Este módulo permite la administración y seguimiento de las tareas asignadas a los usuarios.

Funciones principales:
Crear tareas: Los usuarios pueden agregar nuevas tareas con título, descripción, estado y fecha de vencimiento.
Editar tareas: Permite modificar la información de una tarea existente.
Eliminar tareas: Permite eliminar tareas que ya no sean necesarias.
Listar tareas: Muestra todas las tareas del usuario, filtradas por estado o fecha de vencimiento.
Asignación de estados: Permite cambiar el estado de una tarea (Ejemplo: "Pendiente" → "En progreso" → "Completada").
Notificaciones: Envía recordatorios a los usuarios sobre tareas próximas a vencer.

Tablas relacionadas:
Tareas: Contiene los detalles de cada tarea.
Estados: Permite asignar estados a las tareas.

Módulo de Categorías

Este módulo gestiona las categorías en las que se pueden clasificar las tareas.

Funciones principales:
Crear categorías: Permite a los usuarios definir nuevas categorías.
Editar categorías: Modifica el nombre o descripción de una categoría existente.
Eliminar categorías: Permite eliminar categorías que ya no sean necesarias.
Listar categorías: Muestra todas las categorías creadas.

Tablas relacionadas:
Categorías: Contiene la información de cada categoría.
Tareas: Relaciona cada tarea con una categoría específica.




Conexión a la base de datos
La clase ConexionDB en C# es una implementación de una conexión a una base de datos SQL Server utilizando ADO.NET. Veamos su explicación paso a paso:

public class ConexionDB
{
    private static readonly string conexionString = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;

    public static SqlConnection GetConnection()
    {
        
        return new SqlConnection
        (
            conexionString
        );
    }
}

public class ConexionDB

Declara una clase pública llamada ConexionDB.
Se usa para administrar la conexión a la base de datos.

private static readonly string conexionString = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;

private: La variable solo es accesible dentro de la clase.
static: Es una variable de clase y no de instancia (no necesitas crear un objeto de ConexionDB para acceder a ella).
readonly: Su valor solo se puede asignar en la declaración o en el constructor de la clase.
conexionString: Almacena la cadena de conexión a la base de datos, obtenida desde el archivo App.config o Web.config.

ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString:

Usa ConfigurationManager para leer la cadena de conexión definida en el archivo de configuración del proyecto.
"ConexionString" es la clave definida en el App.config.

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
    </configSections>
    <connectionStrings>
        <add name="ConexionString"
            connectionString="data source = LAPTOP-3NFVNUT5\SQLEXPRESS; initial catalog = TareasDB; user id = sa; password = 12345" />
    </connectionStrings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
    </startup>
</configuration>

public static SqlConnection GetConnection()

public: Se puede acceder desde cualquier parte del código.
static: No necesitas instanciar ConexionDB para usarlo.
Devuelve un SqlConnection, que representa la conexión a la base de datos

return new SqlConnection(conexionString);

Crea un nuevo objeto SqlConnection usando la cadena de conexión obtenida.
Este objeto es el que se usa para abrir y manejar la conexión con la base de datos.
