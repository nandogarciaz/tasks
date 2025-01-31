# Gerenciamento de Tarefas
Sistema para gerenciar de tarefas por usuários.

O projeto cria automaticamente os dados iniciais para serem testado, quando executado. Se não houver dados no banco de dados.

Este projeto irá rodar sem precisar de instalações de dependencias de outros serviços, com o banco de dados, por usar o banco de dados InMemory.


### Instalando 
Para rodar o projeto não precisa instalar nenhum banco de dados, pois esta sendo usado o banco de dados InMemory.

Caso não tenha os pacotes instalados, rodar o comando abaixo, na pasta raiz do projeto, com command line, para instalar os pacotes nuget.

    dotnet restore tasks.sln

### Executando 
Para rodar o projeto, basta rodar o comando abaixo na pasta raiz do projeto.

    dotnet run

#### Documentação Swagger
Os testes podem ser feito diretamente no swagger, ou utilizando o cUrl para testar os endpoints via Postman.

http://localhost:5092/swagger/index.html


## Informações Técnicas
   - Net Core 8.0
   - Entity Framework
   - Banco de dados InMemory

### Autor
Fernando Garcia de Azevedo