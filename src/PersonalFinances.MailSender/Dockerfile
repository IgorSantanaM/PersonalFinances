FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/PersonalFinances.MailSender/PersonalFinances.MailSender.csproj", "src/PersonalFinances.MailSender/"]
COPY ["src/PersonalFinances.Application/PersonalFinances.Application.csproj", "src/PersonalFinances.Application/"]
COPY ["src/PersonalFinances.Infra.CrossCutting.IoC/PersonalFinances.Infra.CrossCutting.IoC.csproj", "src/PersonalFinances.Infra.CrossCutting.IoC/"]

RUN dotnet restore "src/PersonalFinances.MailSender/PersonalFinances.MailSender.csproj"

COPY . .

WORKDIR "/src/src/PersonalFinances.MailSender"
RUN dotnet build "PersonalFinances.MailSender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalFinances.MailSender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PersonalFinances.MailSender.dll"]
