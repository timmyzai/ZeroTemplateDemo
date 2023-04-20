#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PepperMintDemo.Web.Public/PepperMintDemo.Web.Public.csproj", "src/PepperMintDemo.Web.Public/"]
COPY ["src/PepperMintDemo.Web.Core/PepperMintDemo.Web.Core.csproj", "src/PepperMintDemo.Web.Core/"]
COPY ["src/PepperMintDemo.Application/PepperMintDemo.Application.csproj", "src/PepperMintDemo.Application/"]
COPY ["src/PepperMintDemo.Application.Shared/PepperMintDemo.Application.Shared.csproj", "src/PepperMintDemo.Application.Shared/"]
COPY ["src/PepperMintDemo.Core.Shared/PepperMintDemo.Core.Shared.csproj", "src/PepperMintDemo.Core.Shared/"]
COPY ["src/PepperMintDemo.Core/PepperMintDemo.Core.csproj", "src/PepperMintDemo.Core/"]
COPY ["src/PepperMintDemo.EntityFrameworkCore/PepperMintDemo.EntityFrameworkCore.csproj", "src/PepperMintDemo.EntityFrameworkCore/"]
COPY ["src/PepperMintDemo.GraphQL/PepperMintDemo.GraphQL.csproj", "src/PepperMintDemo.GraphQL/"]
RUN dotnet restore "src/PepperMintDemo.Web.Public/PepperMintDemo.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/PepperMintDemo.Web.Public"
RUN dotnet build "PepperMintDemo.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PepperMintDemo.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PepperMintDemo.Web.Public.dll"]
