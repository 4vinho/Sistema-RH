# 📘 Sistema-RH

Sistema de Recursos Humanos moderno e escalável, desenvolvido com arquitetura de microsserviços. Possui uma interface intuitiva no front-end com Blazor WebAssembly e um back-end robusto com ASP.NET Core, aplicando DDD e Clean Architecture.

## 🚀 Tecnologias Utilizadas

### Backend
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQL Server
- Microsserviços
- DDD (Domain-Driven Design)
- Clean Architecture

### Frontend
- Blazor WebAssembly
- MudBlazor

## 📦 Funcionalidades

- Cadastro, edição e exclusão de funcionários
- Gestão de cargos e departamentos
- Controle de folhas de pagamento
- Interface web moderna e responsiva
- Comunicação entre microsserviços
- Autenticação e segurança

## ⚙️ Como Executar o Projeto

### 1. Clonar o repositório
git clone https://github.com/4vinho/Sistema-RH.git
cd Sistema-RH

### 2. Configurar variáveis de ambiente
Crie um arquivo `.env` com as variáveis necessárias:

ASPNETCORE_ENVIRONMENT=Development
ConnectionStrings__DefaultConnection=YOUR_CONNECTION_STRING

### 3. Aplicar migrações do banco de dados
dotnet ef database update

### 4. Executar os microsserviços
Dentro de cada projeto de microsserviço, execute:
dotnet run

### 5. Executar o frontend
cd FrontEnd/RHFrontEnd
dotnet run

Acesse o sistema em: http://localhost:5000

## 🧪 Testes
Para rodar os testes automatizados:
dotnet test

## 📄 Licença
Este projeto está licenciado sob a Licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 🤝 Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.
