# Vulcano

> 🚀 Projeto base em .NET com arquitetura em camadas e testes automatizados.

## 📁 Estrutura do Projeto

A solução segue uma arquitetura limpa com separação por responsabilidades. Todos os projetos ficam dentro da pasta `src/`, enquanto a solução `.sln` está na raiz.

```
Vulcano/
├── Vulcano.sln              # Arquivo da solução
└── src/
    ├── Vulcano.Domain/       # Entidades, interfaces e regras de negócio
    │   ├── Entities/
    │   ├── ValueObjects/
    │   ├── Interfaces/
    │   ├── Exceptions/
    │   └── Base/
    │
    ├── Vulcano.Application/  # Casos de uso, interfaces e DTOs
    │   ├── UseCases/
    │   ├── DTOs/
    │   └── Interfaces/
    │
    ├── Vulcano.Infrastructure/ # Implementações técnicas (persistence, serviços, etc.)
    │   ├── Persistence/
    │   └── Services/
    │
    ├── Vulcano.WebApi/       # API REST (camada de entrada)
    │   ├── Controllers/
    │   ├── Middlewares/
    │   └── Filters/
    │
    └── Vulcano.Tests/        # Testes unitários e de integração
        ├── Application/
        ├── Domain/
        └── Infrastructure/
```

## 🛠️ Tecnologias

- .NET 6 ou superior
- WebAPI
- xUnit (para testes)

## ▶️ Como executar o projeto

```bash
cd src/Vulcano.WebApi
dotnet run
```

A aplicação estará disponível em: `https://localhost:5001` ou `http://localhost:5000`.

## ✅ Próximos passos sugeridos

- Configurar injeção de dependência no `Program.cs`.
- Implementar casos de uso e serviços reais.
- Criar testes unitários para a camada `Domain` e `Application`.
