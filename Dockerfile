FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /work

COPY src/*/*.csproj ./
RUN for projectFile in $(ls *.csproj); \
  do \
    mkdir -p ${projectFile%.*}/ && mv $projectFile ${projectFile%.*}/; \
  done

RUN dotnet restore /work/Findest.Api/Findest.Api.csproj

COPY src .

# --------------

FROM build AS publish
WORKDIR /work/Findest.Api

RUN dotnet publish -c Release -o /app --no-restore

# ---------------

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app .

# Expose the port
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "Findest.Api.dll"]
