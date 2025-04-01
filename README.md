# Sistema de RH #

## Sobre o Projeto ##

Este é um sistema de Recursos Humanos desenvolvido para facilitar a gestão de colaboradores. Ele permite cadastrar, editar e excluir funcionários, além de gerenciar folhas de pagamento, cargos e departamentos. O objetivo é oferecer uma solução eficiente e acessível para empresas que precisam organizar melhor seus processos de RH.

### Tecnologias Utilizadas ###

Backend: ASP.NET Core, Entity Framework Core, AutoMapper, Microsserviços

Frontend: Blazor WebAssembly, MudBlazor

### Infraestrutura: ###

Arquitetura: DDD, Arquitetura Limpa

Como Configurar e Rodar o Projeto

1. Clonar o Repositório

git clone https://github.com/4vinho/NOME_DO_REPOSITORIO.git
cd NOME_DO_REPOSITORIO

2. Configurar as Variáveis de Ambiente

3. Configurar Banco de Dados
   Modificar os microsserviços e modificar o local do banco de dados de InMemory para o de sua preferencia

5. Iniciar as APIs

dotnet run --project src/Backend/Api

5. Iniciar o Frontend

dotnet run --project src/Frontend

Após isso, a aplicação estará disponível em http://localhost:5000.

### Estrutura do Projeto ###
```
SistemaRH/
├── src/
│   ├── Backend/  → Microsserviços de API
│   ├── Frontend/ → Interfaces Blazor
│   ├── Docs/     → Informações sobre o App
├── README.md
```
### Endpoints Principais ###

-EmployeeServiceAPI
  ```http
  GET
  /api/Employee/status/statusEnum
  ```
  ```http
  GET
  /api/Employee/{id}
  ```
  ```http
  DELETE
  /api/Employee/{id}
  ```
  ```http
  GET
  /api/Employee/cpf/{CPF}
  ```
  ```http
  POST
  /api/Employee
  ```
  ```http
  PUT
  /api/Employee
  ```
-MissionServiceAPI
  ```http
  GET
  /api/Mission/status/{statusEnum}
  ```
  ```http
  GET
  /api/Mission/{id}
  ```
  ```http
  DELETE
  /api/Mission/{id}
  ```
  ```http
  GET
  /api/Mission/employeeId/{employeeId}
  ```
  ```http
  POST
  /api/Mission
  ```
  ```http
  PUT
  /api/Mission
  ```

Desenvolvido por Eduardo Alves Nascimento
