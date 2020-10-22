# Teste Desenvolvedor .NET - Ponto iD

## 🚀 O teste é composto de 3 objetivos:

[X] **1º:** Modelar um banco de dados simples, no qual deverá possuir no mínimo três tabelas e de preferência do tipo self-contained.
A primeira tabela irá armazenar as informações da Escola: Nome e Código INEP;
A segunda tabela será responsável por armazenar as informações das Turmas: Descrição, Série e turno;
Já a terceira tabela será responsável por armazenar as informações do Aluno:  Nome, Data de Nascimento e CPF.

[X] **2º:** Desenvolver em C# (ASP.NET Core preferencialmente) uma API REST, fornecendo as operações CRUD para as tabelas modeladas. É desejável que a camada de persistência utilize o Entity Framework.

[X] **3º** Desenvolver um aplicativo Web MVC, SIMPLES, que faça as operações básicas modeladas, acessando os endpoints da API desenvolvida, para alimentar o banco de dados.

## 🎲 O projeto

O teste é composto de 4 projetos:
1. Teste.Dominio - Onde são armazenados as informações relacionados aos modelos da aplicação (Models e Enums).
2. Teste.Infra - Projeto responsável por fazer a comunicação com o banco de dados, aqui estão as interfaces, repositórios, services e DbContext.
3. Teste.WebApi - Projeto que contem a API para comunicação do sistema, nele estão contidos os controllers com os endpoints da aplicação, juntamente com suas rotas.
4. Teste.Web - Projeto que contém a aplicação Web, aqui estão contidos os controladores, views e serviços responsáveis pela navegação e acesso a API.

## 🛠 Orientações

1. Baixe ou clone o repositório
2. Abra a solução (encontra-se dentro da pasta PontoiD-Teste) ou o Visual Studio na pasta do repositório
3. Configure sua string connection nos arquivos 'appsettings.json', tanto do projeto Teste.Web quanto do projeto Teste.WebApi
4. Abra terminal de pacotes do NuGet
	4.1 Selecione o projeto Teste.Infra
	4.2 Execute o comando 'Add-Migration Teste'
	4.3 Execute o comando 'Update-Database' para criar o banco de dados e alimentar com a carga inicial de dados
5. Abra a pasta Teste.WebApi
	5.1 Abra o terminal (dentro da pasta) e execute o comando 'dotnet watch run' para executar api
6. No Visual Studio, execute a aplicação com o projeto 'Teste.Web'
7. Navegue entre as telas e os endpoints da API

## 🎁 Template

https://www.creative-tim.com/product/material-dashboard