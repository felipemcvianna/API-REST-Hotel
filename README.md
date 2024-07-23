# API de Hotelaria 🏨

Esta é uma API REST para gerenciamento de um sistema de hotelaria. Ela permite a criação, leitura, atualização e exclusão de reservas, gerenciamento de hóspedes e quartos.

## Arquitetura do Sistema
Utilizo a camada de contexto para separar os diferentes contextos da aplicação. Dentro de cada contexto, as seguintes camadas são utilizadas:
### Models
Esta camada é utilizada para armazenar as entidades do contexto atual. Cada entidade representa uma tabela no banco de dados e define a estrutura dos dados que serão manipulados.
### Controllers
Responsável por controlar as requisições do usuário, validar as entradas e passar a requisição para a camada de serviço. Os controllers são a interface entre o usuário e a lógica de negócio da aplicação.
### Services 
Onde a lógica de negócio é armazenada. Essa camada é responsável por receber as requisições da camada de controle, acessar a base de dados através do DBContext e processar os dados conforme a lógica necessária.
### DTOs (Data Transfer Objects)
Responsável por garantir a segurança no acesso aos dados sensíveis das tabelas. Os DTOs são usados para transferir dados entre a camada de controle e a camada de serviço, expondo apenas as informações necessárias.

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Swagger para documentação

## Funcionalidades

- **Reserva**: CRUD de reservas
- **Hóspede**: CRUD de hóspedes
- **Quarto**: Gerenciamento de quartos

## UI SWAGGER


## Como Executar

### Pré-requisitos

- .NET SDK 8.0.303
- PostgreSQL

### Passos

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/hotel-api.git
   cd hotel-api
