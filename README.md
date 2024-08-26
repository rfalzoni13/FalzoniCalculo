# Falzoni Cálculo
## Este projeto tem como base uma simples demonstração de cálculo de CDB
O projeto foi construído com um princípio de 3 camadas principais (apresentação, serviço e models), sendo a apresentação dividia em Api e Web com mais 2 camadas de testes, totalizando 7 camadas

O projeto está com a construção principal em .NET, dividindo alguns projetos em C# e outros em VB.NET, porém todos estão com a versão 4.7.2 do .NET Framework, fazendo com que os mesmos tenham total compatibilidade, apesar das linguagens distintas.

A camada de Api está integrada com Swagger e possui bloqueio de Cors com liberação apenas para o projeto Web em questão

O projeto Web está na versão 16 do Angular

Todos os projetos estão centralizados na mesma solution, fazendo com que os mesmos possam ser executados em apenas uma IDE.

Todos os projetos possuem testes unitários.

Nenhuma biblioteca de testes adicional foi incluída.

Para executar o projeto, basta clonar o mesmo na máquina local, limpar e recompilar (clean X rebuild) e executar o mesmo.

Os requisitos para executar o projeto são:
- SDK do .NET Framework 4.7.2
- IDE Visual Studio (2017 ou superior) ou VS Code
- Node.js acima da versão 17
