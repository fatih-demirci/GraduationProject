#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/projects/universityAssistant/Services/UniversityService/Presentation/UniversityService.Api/UniversityService.Api.csproj", "src/projects/universityAssistant/Services/UniversityService/Presentation/UniversityService.Api/"]
COPY ["src/corePackages/Core.CrossCuttingConcerns/Core.CrossCuttingConcerns.csproj", "src/corePackages/Core.CrossCuttingConcerns/"]
COPY ["src/projects/universityAssistant/Services/UniversityService/Infrastructure/UniversityService.Persistence/UniversityService.Persistence.csproj", "src/projects/universityAssistant/Services/UniversityService/Infrastructure/UniversityService.Persistence/"]
COPY ["src/projects/universityAssistant/Services/UniversityService/Core/UniversityService.Domain/UniversityService.Domain.csproj", "src/projects/universityAssistant/Services/UniversityService/Core/UniversityService.Domain/"]
COPY ["src/corePackages/Core.Persistence/Core.Persistence.csproj", "src/corePackages/Core.Persistence/"]
RUN dotnet restore "src/projects/universityAssistant/Services/UniversityService/Presentation/UniversityService.Api/UniversityService.Api.csproj"
COPY . .
WORKDIR "/src/src/projects/universityAssistant/Services/UniversityService/Presentation/UniversityService.Api"
RUN dotnet build "UniversityService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniversityService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY src/projects/universityAssistant/Services/UniversityService/Infrastructure/UniversityService.Persistence/Setup .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniversityService.Api.dll"]