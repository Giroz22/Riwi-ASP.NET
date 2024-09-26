# API RESTful - Gestor de Tareas (To-Do List)

Esta API RESTful permite a los usuarios gestionar una lista de tareas.
Incluye operaciones para crear, leer, actualizar y eliminar tareas,
utilizando la técnica de SoftDeleted para las eliminaciones.

## Objetivo

Crear una API que permita a los usuarios gestionar sus tareas de manera eficiente.
Las funcionalidades principales incluyen la capacidad de agregar nuevas tareas,
leer las tareas existentes, actualizarlas y eliminarlas de forma segura.

## SoftDeleted

Esta API implementa la técnica de SoftDeleted, lo que significa que cuando una tarea
se "elimina", simplemente se marca como eliminada en lugar de ser eliminada físicamente
de la base de datos. Esto permite mantener un registro histórico de las tareas eliminadas.

## Entregables

- **Código Fuente**: Disponible en el repositorio de Git.
- **Colección de Postman**: Incluye todos los servicios para probar los endpoints,
  organizada con ejemplos de datos válidos y errores de validación.
