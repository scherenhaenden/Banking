# Banking App Example
## Bank

### Techs

- Backend is written with Dotnet
- Frontend is written in Angular.
- Database will use BD2


For now is only the Frontend drafted.
Go to the bank folder and run the following commands:

To test the running application:

```bash

npm install
ng serve

```

or 
    
    ```bash

    cd Example/Bank/Applications/ForClients/BankingClientApp/ && ng serve
    ```




  rabbitmq:
    # Add image
    image: rabbitmq:3.8.2-management
    # Add ports
    ports:
      - 5672:5672
      - 15672:15672
    # Add environment variables
    environment:
      - RABBITMQ_DEFAULT_USER=admin
      - RABBITMQ_DEFAULT_PASS=admin
    # Add volumes
    volumes:
      - rabbitmq_data:/var/lib/rabbitmq
    # Add restart policy
    restart: always



      kafka:
    # Add image
    image: wurstmeister/kafka:2.12-2.2.1
    # Add ports
    ports:
      - "9092:9092"
    # Add environment variables
    environment:
      KAFKA_ADVERTISED_HOST_NAME: localhost
      KAFKA_CREATE_TOPICS: "test:1:1"
      KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
    # Add depends on
    depends_on:
      - zookeeper
  
  
  
  
  
  
  service:
    # Add image
    image: "image"
    # Add container name
    container_name: "container"
    # Add restart policy
    restart: "always"
    # Add environment variables
    environment:
      - "ENV_VAR=env_var"
    # Add volumes
    volumes:
      - "volume"
    # Add ports
    ports:
      - "port"
    # Add networks
    networks:
      - "network"