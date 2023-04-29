#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/projects/universityAssistant/Services/StorageService/StorageService.Api/StorageService.Api.csproj", "src/projects/universityAssistant/Services/StorageService/StorageService.Api/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Base/EventBus.Base.csproj", "src/BuildingBlocks/EventBus/EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.AzureServiceBus/EventBus.AzureServiceBus.csproj", "src/BuildingBlocks/EventBus/EventBus.AzureServiceBus/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBus.RabbitMQ/"]
COPY ["src/corePackages/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "src/corePackages/Core.CrossCuttingConcerns/"]
RUN dotnet restore "src/projects/universityAssistant/Services/StorageService/StorageService.Api/StorageService.Api.csproj"
COPY . .
WORKDIR "/src/src/projects/universityAssistant/Services/StorageService/StorageService.Api"
RUN dotnet build "StorageService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StorageService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY src/projects/universityAssistant/Services/StorageService/StorageService.Api/Infrastructure/Setup .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StorageService.Api.dll"]