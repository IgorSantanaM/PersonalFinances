FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PersonalFinances.Presentation.WebApi/PersonalFinances.Presentation.WebApi.csproj", "src/PersonalFinances.Presentation.WebApi/"]
COPY ["src/PersonalFinances.Application/PersonalFinances.Application.csproj", "src/PersonalFinances.Application/"]
COPY ["src/PersonalFinances.Domain/PersonalFinances.Domain.csproj", "src/PersonalFinances.Domain/"]
COPY ["src/PersonalFinances.Domain.Core/PersonalFinances.Domain.Core.csproj", "src/PersonalFinances.Domain.Core/"]
COPY ["src/PersonalFinances.Infra.Data/PersonalFinances.Infra.Data.csproj", "src/PersonalFinances.Infra.Data/"]
COPY ["src/PersonalFinances.Services/PersonalFinances.Services.csproj", "src/PersonalFinances.Services/"]
COPY ["src/PersonalFinances.Infra.CrossCutting.IoC/PersonalFinances.Infra.CrossCutting.IoC.csproj", "src/PersonalFinances.Infra.CrossCutting.IoC/"]
RUN dotnet restore "./src/PersonalFinances.Presentation.WebApi/PersonalFinances.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PersonalFinances.Presentation.WebApi"
RUN dotnet build "./PersonalFinances.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PersonalFinances.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalFinances.Presentation.WebApi.dll"]