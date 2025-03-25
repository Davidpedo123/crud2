OrdenCompra.sln
├── OrdenCompra.Domain
│   ├── Entities
│   └── Interfaces (Contratos de Repositorio, etc.)
├── OrdenCompra.Application
│   ├── Services / UseCases
│   └── DTOs (si aplica, aunque a veces van en Web)
├── OrdenCompra.Infrastructure
│   ├── Data
│   │   ├── ApplicationDbContext.cs
│   │   └── (Migraciones)
│   └── Repositories
└── OrdenCompra.Web
    ├── Controllers
    │   └── (Todos tus .cs de Controladores)
    ├── Program.cs (entry point)
    ├── appsettings.json
    ├── appsettings.Development.json
    ├── wwwroot (si es MVC)
    └── (Vistas o Razor Pages, si corresponde)
