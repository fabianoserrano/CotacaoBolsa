## **Projeto CotacaoBolsa**

É uma API que permite o registro e controle da cotação de ativos listados na bolsa de valores brasileira (B3).
A solução foi desenvolvida utilizando a linguagem C# na versão 7.0 do .NET framework e banco de dados SQL Server.

**Requisitos:**
- Disponibilizar endpoints para inclusão, alteração e exclusão de uma determinada cotação de ativo;
- Disponibilizar endpoints para listar todas as cotações, uma específica ou por filtro de data ou ativo;
- O projeto deve ser estruturado para ser escalável, mesmo que num primeiro momento tenha apenas os recursos mencionados acima.

**Critério de aceite:**
- A Cotação deve possuir uma data válida;
- O código do Ativo da Cotação deve possuir de 5 a 6 dígitos;
- O código do Ativo não será validado em um cadastro prévio num primeiro momento, mas essa funcionalidade possivelmente existirá numa versão futura;
- O valor da Cotação deverá ser um número que permita casas decimais.

**Execução:**
- Abra a solução (CotacaoBolsa.sln), preferencialmente, na versão 2022 ou posterior do Microsoft Visual Studio
- Restaure os pacotes dos projetos (Solution Explorer, Solution, Restore NuGet Packages)
- Altere a string de conexão da base de dados (entrada ConnectionString da seção ConnectionStrings no arquivo appsettings.json do projeto CotacaoBolsa.API)
- Crie a base de dados (instruções detalhadas abaixo)
- Rode o projeto CotacaoBolsa.API

**Base de dados:**
A base de dados (SQL Server) pode ser criada de uma das duas formas a seguir:
1) A partir do script (script.sql) junto à solução do projeto (tomando o cuidado de modificar, caso necessário, o caminho dos arquivos .mdf e .ldf); ou
2) Utilizando o Entity Framework (pasta Migrations no projeto CotacaoBolsa.Data)
