FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY StorageService.Messaging/*.csproj ./StorageService.Messaging/
COPY StorageService.Application/*.csproj ./StorageService.Application/
COPY StorageService.Domain/*.csproj ./StorageService.Domain/
COPY StorageService.Infrastructure/*.csproj ./StorageService.Infrastructure/
RUN dotnet restore

COPY . .
WORKDIR /app/StorageService.Messaging
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "StorageService.Messaging.dll"]
