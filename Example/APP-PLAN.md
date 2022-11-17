# Create an example World sition of App using. 

Create an application for a Bank
Create an application for a room in a hotel
Create an application to rent cars
Create an application to find jobs by city


## Bank
FE: Angular
BE: Dotnet Core
DBs: Db2

## Hotel
FE: Not Decided
BE: Dotnet Core
DBs: MongoDb












## Only Trash 


docker run -itd --name mydb2 --privileged=true -p 50000:50000 -e LICENSE=accept -e DB2INST1_PASSWORD=MySuperPass -e DBNAME=testdb -v /home/edward/Development/DBs/:/database ibmcom/db2


docker run --name some-mongo -v /home/edward/Development/DBs/MongoDb/:/etc/mongo -d mongo --config /etc/mongo/mongod.conf





# Use root/example as user/password credentials
version: '3.1'

services:

  mongo:
    image: mongo
    restart: always
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: example

    volumes:    
      - ./RockatuestiloCoreBack/wwwroot/uploads/:/var/www/rockatuestilo/uploads/

  mongo-express:
    image: mongo-express
    restart: always
    ports:
      - 8081:8081
    environment:
      ME_CONFIG_MONGODB_ADMINUSERNAME: root
      ME_CONFIG_MONGODB_ADMINPASSWORD: example
      ME_CONFIG_MONGODB_URL: mongodb://root:example@mongo:27017/