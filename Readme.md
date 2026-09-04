## DiamondStore

* Um projeto backend que fornece uma API para um repositorio de jogos, onde operações fundamentais (CRUD) podem ser realizadas nessa coleção de jogos através das routes. De forma geral, é um projeto que teve como principais objetivos:
    * Desenvolver pratica com criação de APIs usando ASP.NET Core, unido a principios fundamentais de OOP;
    * Aplicação de conceitos fundamentais como routes, endpoints, requisições e respostas, verbos HTTP etc...;
    * Validação de requisições;

## Dependencias

- `Microsoft.EntityFrameworkCore.Design v10.0.11`
- `Microsoft.EntityFrameworkCore.Sqlite v10.0.11`
- `Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore v10.0.11`

## Tecnologias utilizadas

- `.NET 10`
- `C# 14`
- `Sqlite`
- `Postman`
- `ASP.NET Core`

## Banco de Dados

Esse projeto utiliza o Sqlite para armazenar registros. Foi escolhido porque é menos custoso em questão de recursos e dispensa as configurações de outros bancos de dados como Microsoft SQL Server ou PostgreSQL, de tal maneira que facilita o uso do projeto. O banco de dados é o arquivo `app.db`, encontrado no diretorio raiz do projeto.

## Configuração do projeto

Para configurar o projeto:

- 1. Clonar o repositorio
>    ```Bash
>    git clone https://github.com/GuilhermeMorais81/DiamondStore.git
>    ```
- 2. Possuir o .NET 10.0 instalado (Disponivel em https://dotnet.microsoft.com/pt-br/download)

- 4. instalar as dependencias do projeto
>    ```Bash
>    dotnet restore
>    ```

- 5. Compilar o projeto
>    ```Bash
>    dotnet build
>    ```

## Como testar

* Como dito na introdução, essa API fornece um CRUD como operações. Nessa seção será disponibilizado as routes para essas operações.
* Durante o desenvolvimento, foi utilizado o Postman para testar as requisições, e recomenda-se utiliza-lo para testar esse projeto também.
* Para adicionar novos jogos, pode ser utilizada [essa ferramenta](https://guidgenerator.com/tools/uuid-v4-generator) para gerar o campo do Id.

### Executando a aplicação

* Para o servidor da aplicação sempre estar recebendo as requisições, não esqueça de mante-la executando:
    >    ```Bash
    >    dotnet run
    >    ```
* O output do terminal dirá qual porta o servidor está escutando para requisições:
    >```` cmd
    >    Now listening on: http://localhost:5067
    >````
* Nesse caso é 5067, no entanto, pode ser diferente dependendo da versão do .NET.

### Listar jogos:

* Verbo HTTP: GET
* Route: ` http://localhost:<PORTA>/games/get-all `

### Adicionar jogos

* Verbo HTTP: POST
* Route: `http://localhost:<PORTA>/games/`
* Exemplo de body:
    ````json
        {
            "Id": "0a07e361-45e9-4c85-9983-197191f95192",
            "Title": "Metal Gear Solid V: Ground Zeroes",
            "ReleaseDate": "2014-03-18"
        }
    ````

### Buscar jogo

* Verbo HTTP: GET
* Route: `http://localhost:<PORTA>/games/<Id-do-jogo>`

### Deletar jogo

* Verbo HTTP: DELETE
* Route: `http://localhost:<PORTA>/games/<Id-do-jogo>`

### Editar jogo

* Verbo HTTP: PUT
* Route: `http://localhost:<PORTA>/games/<Id-do-jogo>`
* Exemplo de body (O id da route deve ser igual ao do body):
    ````json
        {
            "Id": "0a07e361-45e9-4c85-9983-197191f95192",
            "Title": "Metal Gear Solid 2: Sons of Liberty",
            "ReleaseDate": "2001-11-13"
        }
    ````

## Contribuição

Caso você deseje reportar um bug, possiveis funcionalidades novas ou fazer comentarios relevantes relacionados ao projeto, pode me contatar pelo email registrado em meu perfil.

## Licenças

Para duvidas em relação à licença e direitos autorais, acesse o arquivo `LICENSE`, presente no diretorio raiz do projeto.
