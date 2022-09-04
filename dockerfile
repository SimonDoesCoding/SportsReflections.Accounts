FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /
COPY --from=build /published-app /
ENTRYPOINT [ "dotnet", "/app/SportReflections.Accounts.Api.dll" ]