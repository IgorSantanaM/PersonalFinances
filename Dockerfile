# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PersonalFinances.Presentation.WebApi/PersonalFinances.Presentation.WebApi.csproj", "src/PersonalFinances.Presentation.WebApi/"]
COPY ["src/PersonalFinances.Services/PersonalFinances.Services.csproj", "src/PersonalFinances.Services/"]
COPY ["src/PersonalFinances.Domain/PersonalFinances.Domain.csproj", "src/PersonalFinances.Domain/"]
COPY ["src/PersonalFinances.Domain.Core/PersonalFinances.Domain.Core.csproj", "src/PersonalFinances.Domain.Core/"]
COPY ["src/PersonalFinances.Infra.Data/PersonalFinances.Infra.Data.csproj", "src/PersonalFinances.Infra.Data/"]
COPY ["src/PersonalFinances.Infra.CrossCutting.IoC/PersonalFinances.Infra.CrossCutting.IoC.csproj", "src/PersonalFinances.Infra.CrossCutting.IoC/"]
RUN dotnet restore "./src/PersonalFinances.Presentation.WebApi/PersonalFinances.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PersonalFinances.Presentation.WebApi"
RUN dotnet build "./PersonalFinances.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PersonalFinances.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalFinances.Presentation.WebApi.dll"]