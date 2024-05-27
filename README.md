🎖️ Entrevista Técnica:

Desenvolver uma aplicação robusta seguindo os princípios da Arquitetura Limpa e enfatizando a qualidade do Software. Este desafio é projetado para simular um cenário de desenvolvimento real, em que a aplicação não só deve atender a requisitos funcionais específicos como garantir a manutenção, a testabilidade e a expansabilidade do código .

📱 Descrição do Projeto:
O tema do projeto é: Aplicação de gerenciamento de uma empresa e seus colaboradores.

⚙️ Tecnologias:
C#;
.NET 8;
ASP.NET Core;
MySQL;
CQRS;
Serilog;
GrafanaLoki;
EventStore;
Docker;
AutoMapper;
Scrutor;

⚙️ Levantamento de Requisitos e Critérios de Aceite:
Funcionalidade Esperada
Deve ser permitido manter o cadastro de colaboradores, empresas, cargos e departamentos.

Requisitos Funcionais:
1. Listagem de Colaboradores:
• O sistema deve exibir todos os colaboradores cadastrados.
• Os colaboradores devem ser apresentados em uma lista ordenada por nome.
3. Gerenciamento de Colaboradores:
• Deve ser possível adicionar um novo colaborador ao sistema.
• Os usuários devem poder editar as informações de um colaborador existente.
• Deve haver a funcionalidade de exclusão lógica para um colaborador do sistema.
4. Informações da Empresa:
• O sistema deve permitir o registro de informações sobre a empresa, como nome, endereço e número de telefone.
Requisitos Não Funcionais:
1. Persistência de Dados:
• Os dados dos colaboradores e informações da empresa devem ser armazenados em um banco de dados.
• Utilizar um framework de ORM para facilitar a persistência dos dados.

Critérios de Aceitação:
1. Listagem de Colaboradores:
• Ao acessar a página de listagem de colaboradores, os colaboradores devem ser apresentados em ordem alfabética ascendente pelo nome.
• A lista deve conter todas as informações relevantes de cada colaborador, como nome, cargo e departamento.
2. Gerenciamento de Colaboradores:
• Deve ser possível adicionar um novo colaborador preenchendo um formulário com todas as informações necessárias.
• As edições feitas em um colaborador devem ser refletidas corretamente na listagem de colaboradores.
• Ao excluir um colaborador, ele não deve mais aparecer na lista de colaboradores.
3. Informações da Empresa:
• As informações da empresa devem ser exibidas de forma clara e acessível na aplicação.
• Deve ser possível editar as informações da empresa conforme necessário.

🧪 Desenvolvimento (Build e Execução do Projeto):
Arquitetura:
A estrutura para o desenvolvimento foi baseada e implementada considerando os principios da Arquitetura Limpa e a divisão em camadas:

Domain;
Infrastructure;
Application;
API;
Testes.
Persistência dos Dados:
O banco de dados escolhido foi o MySQL, por ser um banco relacional e garantir os princípios ACID.

Testes:
O padrão utilizado é pensado nos testes unitários, testes de integração e BDD.

Logging:
Essa aplicação foi construída com logs gerado pelo serilog e disponibilizado para consulta no container do GrafanaLoki.
Para visualiza-los, basta: 
• Iniciar a aplicação e acessa a porta 3000. Ir em Configuration > Data Source > Add Data Source;
• Selecionar o Loki e configurar a url como http://loki:3100 e salvar;
• Vá até a opção explore, selecione o Loki na combo;
• Expanda o log browser, clique no nome da aplicação cesla_api e clique em show logs para exibi-los;

Build e Execução do Projeto:
Para executar esses projetos você precisa seguir as etapas abaixo:

Acessar o repositório do projeto através do link: https://github.com/fillipelsilva/Cesla;
Baixar o zip do projeto ou fazer um fork do mesmo;
Abrir o projeto, preferencialmente, na IDE Visual Studio considerando que facilitará para a execução;
Configurar a api como startup project;
Alterar a informação Server(ConnectionStrings.DefaultConnection), contida dentro do arquivo appsettings.json no projeto da API, de "host.docker.internal" para "localhost";
Rodar o comando update-database no package manage console apontando para o projeto de infraestrutura;
Alterar a informação Server(ConnectionStrings.DefaultConnection), contida dentro do arquivo appsettings.json no projeto da API, de "localhost" para "host.docker.internal";
Clicar na opção, configurar startup projects, selecionar docker-compose como start;
Após iniciar o navegador será iniciado a interação com o sistema (através do swagger), possibilitando o registro das entidades;
