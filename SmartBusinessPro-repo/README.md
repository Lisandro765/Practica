# SmartBusinessPro

Aplicación Windows Forms (.NET 8) que se conecta a SQL Server mediante **Entity Framework Core**
usando un contexto centralizado (`SmartBusinessContext`) y una cadena de conexión en `App.config`.

## Estructura

```
SmartBusinessPro/
├── SmartBusinessPro.sln
├── database/SmartBusinessPro.sql     Script de la base de datos y datos de prueba
├── docs/                             Evidencias y documento
└── SmartBusinessPro/
    ├── App.config                    Cadena de conexión
    ├── Program.cs
    ├── Form1.cs / Form1.Designer.cs  Formulario con DataGridView
    ├── Data/SmartBusinessContext.cs  DbContext (UseSqlServer)
    └── Models/                       Entidades Producto y Categoria
```

## Requisitos

- Visual Studio 2022 o superior (carga de trabajo de escritorio de .NET)
- .NET 8 SDK
- SQL Server (Express, Developer o LocalDB) y SSMS

## Cómo ejecutar

1. Ejecute `database/SmartBusinessPro.sql` en SSMS.
2. Abra `SmartBusinessPro.sln` en Visual Studio.
3. Ajuste el valor `Server` en `SmartBusinessPro/App.config` según su equipo.
4. Ejecute con F5. Presione **Probar conexión** y luego **Consultar productos**.

## Paquetes NuGet

- `Microsoft.EntityFrameworkCore.SqlServer`
- `System.Configuration.ConfigurationManager`

## Cadena de conexión

```
Server=localhost\SQLEXPRESS;Database=SmartBusinessPro;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=15;
```

| Parte | Descripción |
|---|---|
| Server | Servidor e instancia de SQL Server |
| Database | Base de datos SmartBusinessPro |
| Trusted_Connection | Autenticación de Windows |
| TrustServerCertificate | Acepta el certificado local (solo desarrollo) |
| Connect Timeout | Segundos de espera para conectar |

## Manejo de errores

| Número SqlException | Significado |
|---|---|
| 53, -1, 2 | Servidor no encontrado o servicio detenido |
| 4060 | Base de datos inexistente o sin acceso |
| 18456 | Credenciales incorrectas |
