CURRENTDIRECTORY=$(pwd)

echo "Current directory is $CURRENTDIRECTORY"

BANKING_DATA_DIRECTORY=$CURRENTDIRECTORY/BankingData

echo "Banking data directory is $BANKING_DATA_DIRECTORY"

export DOCKER_DEFAULT_PLATFORM=linux/amd64 &&\
 docker run -it --name mydb2 -e DBNAME=testdb -e DB2INST1_PASSWORD=MySuperPass \
  -e LICENSE=accept -p 50000:50000 --privileged=true --platform linux/amd64 -v $BANKING_DATA_DIRECTORY:/database ibmcom/db2


#export DOCKER_DEFAULT_PLATFORM=linux/amd64 &&\
# docker run -it --name db2 -e DBNAME=testdb -e DB2INST1_PASSWORD=GD1OJfLGG64HV2dtwK \ 
#-e LICENSE=accept -p 50000:50000 --privileged=true --platform=linux/amd64 ibmcom/db2