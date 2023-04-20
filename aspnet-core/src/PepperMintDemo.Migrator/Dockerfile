#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PepperMintDemo.Migrator/PepperMintDemo.Migrator.csproj", "src/PepperMintDemo.Migrator/"]
COPY ["src/PepperMintDemo.EntityFrameworkCore/PepperMintDemo.EntityFrameworkCore.csproj", "src/PepperMintDemo.EntityFrameworkCore/"]
COPY ["src/PepperMintDemo.Core/PepperMintDemo.Core.csproj", "src/PepperMintDemo.Core/"]
COPY ["src/PepperMintDemo.Core.Shared/PepperMintDemo.Core.Shared.csproj", "src/PepperMintDemo.Core.Shared/"]
RUN dotnet restore "src/PepperMintDemo.Migrator/PepperMintDemo.Migrator.csproj"
COPY . .
WORKDIR "/src/src/PepperMintDemo.Migrator"
RUN dotnet build "PepperMintDemo.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PepperMintDemo.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PepperMintDemo.Migrator.dll", "-s"]
