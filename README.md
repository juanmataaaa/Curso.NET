# 🚀 API de Gestión de Usuarios - TechHive Solutions

Este proyecto consiste en el desarrollo de una **API RESTful** robusta construida con **ASP.NET Core**, diseñada para gestionar el registro de usuarios de la empresa TechHive Solutions. Durante el desarrollo, se utilizó **Microsoft Copilot** como asistente para la generación de código, depuración y optimización de middlewares.

## 📋 Características del Proyecto

El proyecto cumple con los 5 pilares fundamentales de la evaluación:

### 1. Operaciones CRUD Completas
Se implementó un controlador de usuarios que permite realizar todas las operaciones básicas:
* **GET**: Recuperar la lista completa de usuarios o un usuario específico por ID.
* **POST**: Añadir nuevos registros al sistema.
* **PUT**: Actualizar la información de usuarios existentes.
* **DELETE**: Eliminar registros del sistema.

### 2. Validación de Datos
El modelo de usuario incluye anotaciones de datos para garantizar la integridad de la información:
* Campos obligatorios para evitar registros vacíos.
* Validación de formato de correo electrónico.
* Restricciones de longitud en los nombres de usuario.

### 3. Depuración y Manejo de Errores
El código fue depurado para manejar escenarios críticos y asegurar la fiabilidad:
* Implementación de bloques **try-catch** para prevenir cierres inesperados de la API.
* Mensajes de error personalizados cuando no se encuentra un ID específico.

### 4. Middleware Personalizado
Se configuró una canalización (pipeline) de middleware para mejorar la gestión y seguridad:
* **Logging Middleware**: Registra automáticamente cada solicitud HTTP (método y ruta) y su respuesta en la consola.
* **Error Handling Middleware**: Captura excepciones globales y devuelve una respuesta estandarizada en formato JSON.

### 5. Seguridad (Autenticación por Token)
La API está protegida mediante un middleware de autenticación basado en **API Key**:
* Todas las solicitudes requieren la validación de tokens de las solicitudes entrantes.
* Las peticiones sin un token válido reciben una respuesta **401 Unauthorized**.

## 🛠️ Tecnologías Utilizadas
* **Lenguaje**: C#
* **Framework**: ASP.NET Core Web API
* **Herramientas de IA**: Microsoft Copilot
* **Repositorio**: GitHub
