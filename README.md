# Initialize the project
dotnet restore 

# Build the docker image
docker build -t mywebapi .

# Run the docker container
docker run -d -p 8080:80 --name mywebapi-container mywebapi

# Run project
dotnet watch

# Swagger
http://localhost:5026/swagger