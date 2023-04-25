# GestaoEscolar.API

API de gestão escolar desenvolvida com .NET Core e Angular

## tecnologias contidas:

- CQRS pattern com MediatR
- EntityFrameworkCore
- DependencyInjection
- Swagger Documentation
- Identity

## Author

- [@lucaslimadevs](https://www.github.com/lucaslimadevs)

# Para rodar o projeto siga as intruções abaixo:

### 1. instale docker desktop

	https://www.docker.com/products/docker-desktop/
		
### 2. instale WSL2

	https://learn.microsoft.com/pt-br/windows/wsl/install 

### 3. Com o docker em execução, abra o prompt de comando dentro da pasta do projeto ~/GestaoEscolar.API e execute o comando "docker-compose up" para criar a imagem do docker

### 4. Para criar a estrutura de banco de dados abra o SQL Server Management Studio e rode os script_banco.sql contidos na pasta ~/GestaoEscolar.API ou siga as instruções abaixo: (caso já tenha rodado os scripts pode pular as instruções do passo 4)

  #### Com o projeto aberto no visual studio, abra o packge manager selecione GEscolar.Api e rode o comando:
    update-database -Context ApplicationDbContext
![image](https://user-images.githubusercontent.com/117870158/234154391-76453084-7775-4459-a7ed-4a02c5040202.png)

  #### Com o projeto aberto no visual studio, abra o packge manager selecione GEscolar.Infra.SqlServer e rode o comando:
       update-database -Context EscolarDbContext
![image](https://user-images.githubusercontent.com/117870158/234154592-199a7bc0-5ae9-4091-9f0b-aa498be5cbda.png)

### 5. Na Solution explorer do Visual Studio selecione GEscolar.API como Startup project e rode o projeto
![image](https://user-images.githubusercontent.com/117870158/234155356-c8baef8f-0e5b-43bc-add7-42aece2424be.png)

### 6. Projeto funcionando!
![image](https://user-images.githubusercontent.com/117870158/234155547-9af724a3-3ad4-4816-8e33-aa6f8e2b3251.png)

