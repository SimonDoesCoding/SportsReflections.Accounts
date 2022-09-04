

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /src
COPY ["nuget.config", ""]
COPY . .
RUN dotnet restore
RUN dotnet publish -o /src/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /
COPY --from=build /src/published-app /
ENTRYPOINT [ "dotnet", "/src/SportReflections.Accounts.Api.dll" ]