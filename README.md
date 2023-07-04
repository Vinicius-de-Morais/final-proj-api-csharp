# final-proj-api-csharp
Backend do Projeto Final da Academia dotNet 6

link para o frontend: https://github.com/Vinicius-de-Morais/final-proj-frontend-csharp

## Sobre

Este é o backend para uma aplicação que cria e gerencia fichas de RPG. A ideia é torná-lo o mais customizável e simples possível, permitindo o cadastro de atributos, raças, classes, habilidades e magias de forma manual.

Os endpoints disponíveis são responsáveis pelo cadastro desses elementos, bem como pelo registro de usuários e seus personagens.

O gerenciamento de usuários logados é feito por meio de tokens armazenados no banco de dados e cookies salvos no lado do cliente. Assim, para cada ação no site, é necessário verificar o token armazenado no cookie, a fim de garantir que o token não tenha expirado e que o usuário esteja devidamente autenticado. As senhas são armazenadas com criptografia e o uso de salt para descriptografá-las. Em nenhum momento, as senhas são enviadas para o cliente ou manipuladas por meio de endpoints específicos.

## Modelo Relacional

O modelo relacional utilizado foi criado com base nas entidades do Entity Framework e representa a estrutura de dados do sistema. Abaixo está uma representação visual do modelo relacional:

![Modelo Relacional](https://github.com/Vinicius-de-Morais/final-proj-api-csharp/assets/83669073/cf38f276-27eb-407e-bb2b-8a8d80874f37)

## Banco de Dados

O banco de dados utilizado é o PostgreSQL no Supabase. Essa escolha foi feita com o objetivo de tornar o projeto pronto para uso e publicação.

## Configuração

Antes de executar a aplicação, é necessário configurar o ambiente. Siga as etapas abaixo:

1. Clone este repositório: `git clone https://github.com/Vinicius-de-Morais/final-proj-api-csharp.git`
2. Configure as informações de conexão com o banco de dados no arquivo `appsettings.json`.
3. Execute as migrações do Entity Framework para criar as tabelas no banco de dados: `dotnet ef database update`
4. Execute a aplicação: `dotnet run`

Certifique-se de ter o .NET SDK instalado em sua máquina para executar a aplicação.

## Contribuição

Contribuições são bem-vindas! Se você encontrar algum problema, tiver alguma sugestão ou quiser colaborar de alguma forma, sinta-se à vontade para abrir uma issue ou enviar um pull request.

