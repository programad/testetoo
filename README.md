[![Build Status](https://programad.visualstudio.com/testetoo/_apis/build/status/programad.testetoo?branchName=master)](https://programad.visualstudio.com/testetoo/_build/latest?definitionId=19?branchName=master)

[Live Demo](https://testetoo.azurewebsites.net)

[Live API](https://testetooapi.azurewebsites.net/api/usuario)

# Teste Too Seguros

Olá, esse é o teste para desenvolvedor da Too Seguros, nosso intuito é verificar seus conhecimentos quanto à algumas tecnologias que já utilizamos, sua desenvoltura com dotnet e estruturação de código. Nosso intuito não é analisar a estética, mas sim como você estrutura a solução.

## Estrutura base do teste

*   Você deve criar uma solução conforme instruções abaixo, sendo dividida em BackEnd e FrontEnd;
*   Para backend, deverá ser uma WebAPI utilizando dotnet core;
*   Para frontend, deverá utilizar Angular (versão 6 ou maior);
*   Para armazenamento (banco de dados), deverão ser utilizados o MongoDb ou SQL;
*   Caso opite por Base de Dados SQL, utilize EntityFramework;

## O teste

*   Crie uma aplicação que possua as seguintes telas:
*   Criação de usuário
*   Upload de arquivo
*   Lista e download dos arquivos dos usuários

## Detalhes das funcionalidades

### Tela de criação de usuário

Deverão ser exibidos os campos abaixo:

*   Nome
*   Data de nascimento
*   Usuário
*   Senha

*   Todos os campos são obrigatórios
*   A data de nascimento não pode ser uma data futura
*   A senha deverá conter ao menos 5 dígitos e ao menos um número e uma letra

### Tela de upload de arquivo

*   Só permitir arquivos com extensao: JPG, PNG

### Tela de lista com Uploads

*   Listar os dados do upload e botão para efetuar download do arquivo
