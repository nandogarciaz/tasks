# Gerenciamento de Tarefas
Sistema de tarefas para usuários, utilizando banco de dados InMemory.

Para rodar o projeto não precisa instalar banco de dados, pois esta sendo usado o banco de dados InMemory.

### Instalando 
Caso não tenha os pacotes instalados, rodar o comando abaixo, na pasta raiz do projeto, para instalar os pacotes nuget.

    dotnet restore tasks.sln

### Executando 
Para rodar o projeto, basta rodar o comando abaixo na pasta raiz.

    dotnet run

#### Documentação Swagger
Os testes podem ser feito diretamente no swagger ou pegando o cUrl para usar no Postman.

http://localhost:5092/swagger/index.html


## Informações Técnicas
   - Net Core 8.0
   - Entity Framework
   - Banco de dados InMemory
