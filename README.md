# RabbitMqProducerConsumer
1>Install the docker.Make Sure it is up and running.
2>Run the below command to make Docker Image for  Rabbit MQ Up and running.
docker pull rabbitmq:3-management
docker run -d -p 15672:15672 -p 5672:5672 --name rabbit-test rabbitmq:3-management
3>Login to below url on Your local.User id and password will be guest 
http://localhost:15672/#/
4>Open the folder RabbitMqConsumer in Visual Code.Build it.
Go to RabbitMqConsumer\bin\Debug\net5.0  and run File Which is of Type .exe
5>Open the folder RabbitMqProducer in new Visual code.Build it.
RabbitMqProducer\bin\Debug\net5.0

You will see producer and consumer working fine.
If you want to see example of Direct Exchange,Topic Exchange etc
then you need to enable repective producer and consumer in both project.

Note:You can use below command to build the code.
dotnet build
To run the code
dotnet run