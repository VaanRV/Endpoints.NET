# Endpoints.NET
Entrevista técnica - Ingeniero de Software en .NET

SUPUESTO:
-En caso de que el dominio del email no sea valido, la API entrega una respuesta 404
-La mayoría de validaciones se harían en la parte de front, con HTML los formularios, input o cualquier dato que se quiera envía a la API pueden ser facilmente controlados. Algunos de ellos son:
  * Campos requeridos.
  * Largo y formato de la contraseña.
  * Validación del Email con el formato correcto.
  * Al momemnto de desencriptar aceptar solamente datos en formato byte.
- Para encriptar y desencriptar están hardcoded la llave de encriptación y los vectores de inicialización para que pueda ser desencriptado sin ningún problema el mensaje.
