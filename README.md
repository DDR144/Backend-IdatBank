# Proyecto Final: IdatBank

## Descripción

* Aplicación bancaria digital (frontend + backend)
* Proyecto final del curso **Herramientas de Programación II**
* Funcionalidades principales:

  * Autenticación de usuarios (login)
  * Visualización de cuentas
  * Transferencias entre cuentas

## Tecnologías Utilizadas

* **Backend**

  * .NET 8 Web API
  * Entity Framework Core
  * Entity Framework Core (In Memory)
  * Swagger (documentación de API)

* **Control de versiones**

  * Git + GitHub 

## Instalación

### Backend

1. Clonar repositorio

   ```bash
   git clone https://github.com/DDR144/Backend-IdatBank.git
   ```
2. Entrar en carpeta backend

   ```bash
   cd Backend-IdatBank
   ```
3. Restaurar dependencias

   ```bash
   dotnet restore
   ```
4. Ejecutar proyecto

   ```bash
   dotnet run
   ```
5. API disponible en `http://localhost:5134/swagger`

## Uso

* Iniciar sesión con un usuario de prueba
* Ver cuentas y saldos
* Realizar transferencias
* Consultar historial de movimientos

## Estructura del Proyecto

* **backend/**

  * Controllers/ → Lógica de API (auth, cuentas, transferencias)
  * Models/ → Clases de negocio (usuarios, cuentas, transferencias)
  * Data/ → DbContext y Seeder

## Autores

* Didier Huerta Rojas
* Amalia Ortiz Chavez
* Luis Pozo Gomez
