Documentação da API

Este documento fornece documentação para os endpoints da API implementados no código fornecido. A API permite realizar operações CRUD (Create, Read, Update, Delete) em TodoItems.

Endpoints
Obter todos os TodoItems
Recupera uma lista de todos os TodoItems.
Método: GET
Parâmetros de URL: Nenhum
Retorno de sucesso: Retorna um objeto JSON contendo uma lista de TodoItems.
Código de status de sucesso: 200 (OK)
Exemplo de resposta:
[
  {
    "id": 1,
    "dsTodoItem": "Fazer compras",
    "completed": false
  },
  {
    "id": 2,
    "dsTodoItem": "Estudar para o exame",
    "completed": true
  }
]


Obter um TodoItem específico
Recupera um TodoItem específico com base no ID fornecido.

URL: [base_url]/api/TodoItems/{id}
Método: GET
Parâmetros de URL:
id (obrigatório): O ID do TodoItem a ser recuperado.
Retorno de sucesso: Retorna um objeto JSON contendo o TodoItem solicitado.
Código de status de sucesso: 200 (OK)
Código de status de erro: 404 (Not Found) se o TodoItem não for encontrado.
Exemplo de resposta:
{
  "id": 1,
  "dsTodoItem": "Fazer compras",
  "completed": false
}

Atualizar um TodoItem
Atualiza um TodoItem com os dados fornecidos.
Método: PUT
Corpo da solicitação: Enviar um objeto JSON contendo os dados atualizados do TodoItem.
Retorno de sucesso: Retorna um código de status 200 (OK) se a atualização for bem-sucedida.
Código de status de erro:
400 (Bad Request) se houver um erro na solicitação.
404 (Not Found) se o TodoItem não for encontrado.
Exemplo de corpo da solicitação:
{
  "id": 1,
  "dsTodoItem": "Fazer compras",
  "completed": true
}

Criar um novo TodoItem
Cria um novo TodoItem com base nos dados fornecidos.
Método: POST
Corpo da solicitação: Enviar um objeto JSON contendo os dados do novo TodoItem.
Retorno de sucesso: Retorna um código de status 201 (Created) e o objeto JSON do novo TodoItem, juntamente com o cabeçalho "Location" contendo a URL para acessar o TodoItem recém-criado.
Código de status de erro:
400 (Bad Request) se houver um erro na solicitação.

Excluir um TodoItem
Exclui um TodoItem com base no ID fornecido.
Método: DELETE
Parâmetros de URL:
id (obrigatório): O ID do TodoItem a ser excluído.
Retorno de sucesso: Retorna um código de status 204 (No Content) se a exclusão for bem-sucedida.
Código de status de erro:
400 (Bad Request) se houver um erro na solicitação.
404 (Not Found) se o TodoItem não for encontrado.
Ao enviar uma solicitação DELETE para a URL especificada com o ID do TodoItem, o TodoItem correspondente será excluído do sistema.


Simular o banco de dados sql server

-- Criação do banco de dados
CREATE DATABASE Todo;
GO
-- Utilização do banco de dados
USE Todo;
GO
-- Criação da tabela TodoItem
CREATE TABLE TodoItem (
    Id INT IDENTITY PRIMARY KEY,
    DsTodoItem NVARCHAR(MAX),
    Completed BIT NOT NULL DEFAULT 0
);
GO

