# Clean Architecture .NET 10 Starter Template — MediatR, EF Core, API & Tests
### Project Overview
**MySolution Clean Architecture Starter** - A minimal, production-ready Clean Architecture scaffold for .NET 10 backends.  
Use this repository as a starting point for enterprise backends or as a reference implementation to learn Clean Architecture, MediatR, EF Core, and test patterns.

**Key features**
- Domain centric project layout: **Core**, **Application**, **Infrastructure**, **API**
- MediatR for use-case orchestration
- EF Core with SQLite for local development
- Minimal, clear examples for repository, handler, and controller
- Unit and integration test projects with xUnit, Moq, FluentAssertions, and EF InMemory
- Bootstrap PowerShell scripts to scaffold the solution and tests quickly

---

### Quick Start
**Prerequisites**
- .NET 10 SDK installed
- Git
- Optional: Docker, dotnet-ef tool for migrations

**Clone and bootstrap**
```bash
git clone https://github.com/pravinharchandani/dotnet-clean-architecture-starter.git
cd dotnet-clean-architecture-starter
```

**Restore, build, and run**
```bash
dotnet restore
dotnet build
# Create EF migrations (optional)
dotnet tool install --global dotnet-ef
dotnet ef migrations add Init -p src/MySolution.Infrastructure -s src/MySolution.API
dotnet ef database update -p src/MySolution.Infrastructure -s src/MySolution.API
# Run the API
dotnet run --project src/MySolution.API
```

**Open API docs**
- In development the project exposes Swagger UI at `http://localhost:5000/swagger` (or the port shown in console).

---

### Tests and Validation
**Run all tests**
```bash
dotnet test
```

**Run a single test project**
```bash
dotnet test tests/MySolution.Application.Tests
```

**Notes**
- API integration tests use `WebApplicationFactory` and an in-memory EF provider for isolation.
- Use unique in-memory DB names or reset state between tests to avoid cross-test interference.

---

### Project Layout
```
MySolution/
 ├─ src/
 │  ├─ MySolution.Core/          # Domain models, entities, interfaces
 │  ├─ MySolution.Application/   # Use cases, MediatR requests and handlers
 │  ├─ MySolution.Infrastructure/# EF Core DbContext, repositories
 │  └─ MySolution.API/           # ASP.NET Core Web API, Program.cs, controllers
 └─ tests/
    ├─ MySolution.Core.Tests
    ├─ MySolution.Application.Tests
    ├─ MySolution.Infrastructure.Tests
    └─ MySolution.API.Tests
```

---

### How to Use This Project
- **As a starter**: Clone, adapt domain models, add DTOs, validation, and business rules. Replace SQLite with your production DB provider in `Program.cs` and `AppDbContext` configuration.
- **As a reference**: Study how the composition root (API) wires dependencies, how Application handlers call repository interfaces, and how Infrastructure implements those interfaces.
- **For teams**: Use the layered layout to assign ownership by team (domain, application, infra, API) and to enable independent evolution of layers.

**Recommended next steps**
- Add DTOs and mapping (AutoMapper or Mapster)
- Add FluentValidation for request validation
- Add Serilog for structured logging
- Add health checks and metrics endpoints
- Add CI pipeline (GitHub Actions) to run `dotnet build` and `dotnet test`
- Containerize the API with a Dockerfile and add a deployment pipeline

---

### Contribution and Support
Contributions, issues, and suggestions are welcome. Use the GitHub Issues tab to report bugs or request features. When opening a PR, include:
- A clear description of the change
- The reason for the change
- Tests that demonstrate the fix or feature

**Usage note**
> You are free to use this project for your own projects or take it as a reference. The code is provided as a starting point and educational example. Adapt it to your needs and production standards.
