# GastroX Monolith

Uma plataforma de experiência gastronômica construída como um monolito modular, utilizando os conceitos do Clean Architecture. Este projeto foi desenvolvido para demonstrar conhecimentos em boas práticas (SOLID, DDD, Clean Code), injeção de dependências, Entity Framework Core, MediatR, testes unitários e muito mais – tudo de forma modular e escalável, mas com a simplicidade de um monolito.

## Sumário

- [Visão Geral](#visão-geral)
- [Funcionalidades](#funcionalidades)
- [Arquitetura e Tecnologias](#arquitetura-e-tecnologias)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Executando a Aplicação](#executando-a-aplicação)
- [Testes](#testes)
- [Contribuindo](#contribuindo)
- [Licença](#licença)
- [Contato](#contato)

## Visão Geral

O **GastroX Monolith** é uma aplicação web que conecta entusiastas da gastronomia a experiências e reservas em restaurantes. Este projeto foi desenvolvido para servir como portfólio e demonstrar um domínio completo de tecnologias .NET com um design modular, sem os custos e complexidades de uma arquitetura de microserviços.

## Funcionalidades

- **API RESTful:** Endpoints para cadastro de restaurantes, gerenciamento de menus, reservas e avaliações.
- **Autenticação JWT:** Controle de acesso para usuários e administradores.
- **Camadas bem definidas:** Separação entre Domain, Application, Infrastructure e Presentation, seguindo os princípios do Clean Architecture.
- **Testes Unitários:** Cobertura de testes para as regras de negócio e casos de uso.
- **Injeção de Dependência:** Utilização do container nativo do .NET para gerenciar dependências.
- **Entity Framework Core:** Acesso a dados com migrações automatizadas e uso de SQL Server (ou outra provider configurável).

## Arquitetura e Tecnologias

- **Monolito Modular:** Estrutura que organiza o código em módulos independentes, facilitando a manutenção e a escalabilidade futura.
- **Clean Architecture:** Separação clara das camadas de domínio, aplicação, infraestrutura e apresentação.
- **ASP.NET Core Web API:** Projeto de entrada para expor os endpoints.
- **Entity Framework Core:** ORM para acesso a dados.
- **MediatR:** Implementação do padrão Mediator para comandos e queries.
- **.NET 8 ou superior:** Plataforma de desenvolvimento.
- **Swagger:** Documentação interativa dos endpoints da API.

## Estrutura do Projeto

A solução está organizada da seguinte forma:

```
/GastroXMonolith
 ├── /src
 │    ├── /Presentation       # Projeto ASP.NET Core Web API (Entry point)
 │    ├── /Application        # Casos de uso, comandos, queries, handlers (MediatR)
 │    ├── /Domain             # Entidades, interfaces e regras de negócio
 │    └── /Infrastructure     # Implementação de acesso a dados, repositórios, etc.
 └── /tests                   # Projetos de testes unitários para Application e Domain
```

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server Express ou LocalDB](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
- Ferramentas de linha de comando (Terminal, PowerShell ou similar)

## Instalação e Configuração

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/lucasoaresdev/GastroXMonolith.git
   cd GastroXMonolith
   ```

2. **Configure a solução:**

   - Abra a solução `GastroXMonolith.sln` no Visual Studio ou na sua IDE preferida.
   - Verifique se as referências entre os projetos estão corretas.

3. **Configuração do Banco de Dados:**

   No arquivo `appsettings.json` do projeto **Presentation**, configure a string de conexão.

4. **Instale as dependências:**

   ```bash
   dotnet restore
   ```

## Executando a Aplicação

1. **Aplicando Migrações:**

   ```bash
   dotnet ef migrations add InitialCreate --startup-project ../Presentation --output-dir Persistence/Migrations
   dotnet ef database update --startup-project ../Presentation
   ```

2. **Rodando a API:**

   ```bash
   dotnet run
   ```

   Acesse o Swagger em `https://localhost:5001/swagger`

## Testes

- Para executar os testes, utilize o comando:

  ```bash
  dotnet test
  ```

## Contribuindo

Contribuições são bem-vindas! Siga os passos do README para contribuir.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

## Contato

- **Email:** [lucasoaresdev@gmail.com](mailto:lucasoaresdev@gmail.com)
- **GitHub:** [lucasoaresdev](https://github.com/lucasoaresdev)
