# Controle de Atendimentos

Sistema web para gerenciamento de chamados, setores e prioridades, desenvolvido com ASP.NET Core MVC e PostgreSQL.

---

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started) (para subir o banco via Docker Compose)


---

## Rodando o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/MarceloBarross/Controle-de-Atendimentos.git
cd ControleAtendimentos
```

### 2. Suba o container do banco:

```bash
docker compose up -d
```

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Aplique as migrations

```bash
dotnet ef database update
```

### 4. Execute

```bash
dotnet run
```

Acesse: `http://localhost:5200`

---

## Estrutura do projeto

```
ControleAtendimentos/
├── Controllers/         # Controladores MVC
├── Data/                # DbContext
├── DTOs/                # DTOs e Mappers
├── Migrations/          # Migrations do Entity Framework
├── Models/              # Modelos de domínio
├── Repositorys/         # Acesso a dados
├── Services/            # Regras de negócio
├── Views/               # Telas Razor
├── appsettings.json     # Configurações
└── Program.cs           # Ponto de entrada
```

---

## Tecnologias

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core 10
- PostgreSQL + Npgsql
- Bootstrap 5
- Docker
