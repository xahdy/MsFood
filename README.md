# MsFood
**Objetivo:** Praticar a integração entre microsserviços, monitoramento, mensageria e Docker.

## Resumo
O projeto **MsFood** é uma plataforma de microsserviços criada para praticar a integração de sistemas distribuídos e conceitos de microsserviços. Ele utiliza um conjunto de tecnologias e ferramentas, incluindo:

- **.NET**: A estrutura principal usada para o desenvolvimento dos microsserviços.

- **PostgreSQL**: Banco de dados relacional usado para armazenar informações sobre restaurantes, pratos e localizações.

- **ActiveMQ**: Sistema de mensageria utilizado para a comunicação assíncrona entre os microsserviços.

- **Grafana**: Ferramenta de monitoramento e visualização que permite acompanhar o desempenho e o estado dos microsserviços.

- **Jaeger**: Plataforma de rastreamento distribuído que fornece insights sobre o fluxo de solicitações entre os microsserviços.

- **Docker**: Plataforma de contêineres usada para empacotar e distribuir os microsserviços e suas dependências de forma consistente.

### Microsserviço de Cadastro

O Microsserviço de Cadastro é responsável por gerenciar as informações relacionadas aos restaurantes, pratos e localizações dos restaurantes. Os usuários podem adicionar novos restaurantes, pratos e detalhes de localização por meio deste serviço.

### Microsserviço de Marketplace

O Microsserviço de Marketplace permite que os usuários visualizem os pratos oferecidos pelos restaurantes e montem seus pedidos. No futuro, os usuários poderão escolher pratos, personalizar seus pedidos e fazer pedidos por meio deste serviço.

### Microsserviço de Pedido

O Microsserviço de Pedido é uma parte em desenvolvimento do projeto e será usado para que os usuários acompanhem o status e a entrega de seus pedidos. Este serviço fornecerá informações em tempo real sobre o andamento dos pedidos dos clientes.


## Próximos Passos

Para o futuro, planejamos as seguintes melhorias e adições ao projeto:

- **Comunicação Aperfeiçoada**: Atualmente, a comunicação entre o serviço de cadastro e o Marketplace está limitada a novos cadastros. Planejamos estender a comunicação para incluir atualizações em cadastros existentes.

- **Finalização do Serviço de Marketplace**: Estamos trabalhando na finalização do serviço de Marketplace para permitir aos usuários escolher pratos, personalizar pedidos e fazer pedidos.

- **Implementação de Autorização e Autenticação**: A segurança é uma prioridade, e pretendemos implementar recursos de autorização e autenticação para proteger os dados e recursos do sistema.

## Instalação e Uso

Para executar o projeto MsFood, siga estas instruções simples:

1. Clone o repositório:
2. Inicie os serviços de cadastro e de marketplace em paralelo.
3. Execute o Docker Compose para orquestrar outros componentes do sistema
   
Todas as informações de login e configurações necessárias estão definidas no arquivo docker-compose.yml. Certifique-se de que os serviços estejam em execução e acessíveis após a inicialização do Docker Compose.

