# Desafio Forno
API Rest com o objetivo de Simular um Forno Virtual

## Como executar o projeto:
- Clonar o Projeto
```
git clone https://github.com/anaJuliaPaixao/forno-virtual.git
```
- Abrir em IDE com suporte ao [.Net6](<https://dotnet.microsoft.com/en-us/download/dotnet/6.0>) (Recomendo [Visual Studio 2022](<https://visualstudio.microsoft.com/pt-br/vs/>))
- Fazer o Download do Oracle XE (Banco de dados) [Oracle](<https://www.oracle.com/br/database/technologies/xe-downloads.html>)

- Fazer o Download e Configurar o Oracle SQL Developer ([SQL DEVELOPER](<https://www.oracle.com/database/sqldeveloper/technologies/download/>)) com os seguintes códigos: 
```
alter session set "_ORACLE_SCRIPT"=true; // Para aceitar os scripts

CREATE USER admin IDENTIFIED BY admin DEFAULT tablespace users;  // este usuário deve estar correspondendo com a string de conexão que veremos mais tarde

GRANT connect, resource TO admin;         // Liberar a conexao apra o usuário


````
- Executar o comando no console nugget o seguinte comando, para gerar o banco de dados
```
Update-Database
````
- Ao rodar a aplicação a documentação irá abrir com o Swagger:

  <https://localhost:7224/swagger>

## Principais End-Points:
- **POST** api/forno : Iniciar um forno ( Caso executar duas vezes Inicio Rapido)
- **GET** api/forno : Lista os fornos
- **PUT** api/forno : Cancela o Forno
- **PUT** api/forno/Pausar-Forno : Pausa o Forno
- **POST** api/forno/Cadastrar-Alimento : Cadastra Alimento para Padrão do forno


- Banco de dados
Foi utilizado o Oracle com os frameworks:
```
 Microsoft.entityframeworkcore.7.0.3
 Oracle.entityframeworkcore.7.21.9
```

## Documentação api:

<img align="center" alt="AnaJulia Swagger" height="400" width="1000" src="https://github.com/anaJuliaPaixao/forno-virtual/blob/main/swagger.png?raw=true">




