# 🌐 HardwareStoreAPI

API REST desarrollada en C# con .NET 8 para la gestión de una tienda de productos informáticos. Permite la gestión de usuarios, productos, listas de favoritos y carritos de compra.

## 📌 Descripción

HardwareStoreAPI es el servicio backend encargado de todas las operaciones relacionadas con usuarios, productos, favoritos y carritos de compra. Está diseñada con un enfoque modular y sigue los principios RESTful para facilitar la integración con múltiples clientes (aplicaciones móviles, web, etc.).
Entre sus objetivos principales se incluyen:

- **Operaciones CRUD eficientes** - Permite crear, leer, actualizar y eliminar usuarios, productos, favoritos y elementos del carrito con respuestas estandarizadas y manejo de errores detallado.
- **Integridad y consistencia de datos** - Emplea Entity Framework Core y MySQL en Google Cloud SQL, con triggers y validaciones en el servidor para garantizar datos fiables.
- **Escalabilidad y despliegue continuo** - Empaquetada en un contenedor Docker y desplegada en Google App Engine Flexible, permite escalar automáticamente según la demanda.
- **Mantenibilidad y monitorización** - Código organizado en capas (Controllers, Services, Data, Models), con registros de actividad (logging) y métricas exportables para análisis de rendimiento.

## 🛠️ Tecnologías utilizadas

- **ASP.NET Core 8** – Framework de la API.  
- **Entity Framework Core** – ORM para mapeo objeto-relacional.  
- **MySQL** – Base de datos en Google Cloud SQL.  
- **Docker** – Contenedor para despliegue en App Engine Flexible.  
- **Google Cloud Platform** – App Engine Flexible y Cloud SQL

## 📦 Funcionalidades implementadas

- **Registro** e **inicio de sesión** de usuarios.  
- **CRUD** de productos: creación, consulta, actualización y borrado.  
- Gestión de **favoritos** y **carrito de compra** por usuario.  
- Lógica de negocio para evitar duplicados en favoritos/carrito.  
- Conexión a la base de datos MySQL con triggers para mantener integridad de categorías.

## 👨‍💻 Autores

Daniel Pajarón y Roberto Jiang

Trabajo Fin de Grado – IES Valle Inclán (Curso 2024–2025)
