El uso de los siguientes métodos de HTTP para interactuar con los recursos de la API:

GET: utilizado para recuperar información de un recurso.

POST: utilizado para crear un nuevo recurso.

PUT: utilizado para actualizar un recurso existente.

DELETE: utilizado para eliminar un recurso existente.

La API cuenta con dos controladores, uno para el manejo de categorías (CategoryController) y otro para el manejo de tareas (TaskController). Además, cuenta con un controlador de base de datos (DatabaseController).

En el controlador de categorías, se pueden realizar las siguientes operaciones:

GET /api/Category: obtiene una lista de todas las categorías.

POST /api/Category: crea una nueva categoría. El cuerpo de la solicitud debe contener una representación en formato JSON de la categoría a crear.

PUT /api/Category/{id}: actualiza la categoría con el ID especificado. El cuerpo de la solicitud debe contener una representación en formato JSON de la categoría actualizada.

DELETE /api/Category/{id}: elimina la categoría con el ID especificado.

En el controlador de tareas, se pueden realizar las siguientes operaciones:

GET /api/Task: obtiene una lista de todas las tareas.

POST /api/Task: crea una nueva tarea. El cuerpo de la solicitud debe contener una representación en formato JSON de la tarea a crear.

PUT /api/Task/{id}: actualiza la tarea con el ID especificado. El cuerpo de la solicitud debe contener una representación en formato JSON de la tarea actualizada.
DELETE /api/Task/{id}: elimina la tarea con el ID especificado.

En el controlador de base de datos, se pueden realizar las siguientes operaciones:

GET /api/Database/createdb: crea la base de datos de la aplicación si todavía no existe.

La API también incluye un esquema de datos para la representación de categorías y tareas en formato JSON.
