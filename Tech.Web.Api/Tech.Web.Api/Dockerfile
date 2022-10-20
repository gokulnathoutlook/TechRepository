#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Tech.Web.Api/Tech.Web.Api.csproj", "Tech.Web.Api/"]
RUN dotnet restore "Tech.Web.Api/Tech.Web.Api.csproj"
COPY . .
WORKDIR "/src/Tech.Web.Api"
RUN dotnet build "Tech.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tech.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tech.Web.Api.dll"]