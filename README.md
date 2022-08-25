# StoneChallenge

API de Loja de Aplicativos.

Para este projeto foi utlizado .NET Core 5, MongoDbAtlas, RabbitMQ e KissLogger

    AppStore: Responsável por efetuar o cadastro de usuário, Cadastro de cartões (opcional), Lista de App's passíveis de compra e Solicitação de Compra. 
    ConsumerBroker: Responsável pelo processamento das solicitações de compra efetuadas , alterando o status do mesmo para pago (1).

    -> Para o acompanhamento de logs, a partir do Microsoft.Extensions.Logging, utilizamos o KissLog.

    -> Para armazenamento em banco de dados, utilizamos do MongoDbAtlas.

    -> Para armazenamento e processamento de fila, utilizamos do RabbitMQ.

    A documentação foi criada utilizando o Swagger.

Para efetuar um teste nesta API, siga os passos a seguir:

    1) Criação de um novo usuário.

    2) Se desejado, há a possibilidade de cadastrar um cartão (necessário ter um usuário cadastrado em sistema)

    3) Consulta de aplicativos disponíveis para compra;

    4) Solicitação de compra, utilizando o cpf cadastrado, os dados do cartão (seja cadastrado ou avulso) e o Codigo do Aplicativo desejado (CodeApp).

    5) A atualização do status da transação para Pago (1) é feito pelo ConsumerBroker, alterando o status da compra para pago. É possível consultar o status            novamente desta compra a partir do ID disponibilizado na solicitação da compra.



Obrigado pela oportunidade de participar deste desafio!
