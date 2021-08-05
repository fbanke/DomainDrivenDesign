FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /src
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS test
WORKDIR /src
COPY . .

RUN dotnet restore
RUN dotnet build --configuration Release --no-restore
RUN dotnet test --no-restore --verbosity normal

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .

RUN dotnet build Api/Api.csproj -c Release -o app

FROM build AS publish
RUN dotnet publish Api/Api.csproj -c Release -o /src/app

FROM base AS final
WORKDIR /src
COPY --from=publish /src/app .

ENTRYPOINT ["dotnet", "Api.dll"]
