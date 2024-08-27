# arch-challenge

Para este projeto, a implementação planejada iria utilizar as seguintes soluções:
- .NET 8
- CQRS
- DDD (Domain Driven Design)
- Fluent Validations (validar entrada de dados)
- Mensageria com RabbitMQ (Producer e Consumer)
- Cache Distribuido com REDIS
- Serilog
- Principios de SOLID
- Dapper e Entity Framework Core
- SQL Server
- Testes de Unidade (xUnit)
- Testes Integrados e TDD (Specflow)
- Docker

  Infelizmente, devido ao tempo e as rotinas diárias, não consegui dedicar muito tempo ao projeto, mas seria bacana se pudéssemos ter a oportunidade de conversar. Eu teria a chance de explicar os passos e decisões para a 
  solução. Não consegui implementar tudo, porém dá pra ter uma ideia do rumo que o projeto iria tomar.

  Passos:
  - Baixar uma imagem do SQL Server e RabbitMQ no Docker;
  - Rodar a DbMigration para criar o Banco de Dados;
  - Executar a API;
  - Consumir o Endpoint de Registro para inserir os lançamentos;
  - Consultar o Endpoint Consolidado para ver as informações desejadas por data.
