FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY PixelService.API/*.csproj ./PixelService.API/
COPY PixelService.Application/*.csproj ./PixelService.Application/
COPY PixelService.Domain/*.csproj ./PixelService.Domain/
COPY PixelService.Infrastructure/*.csproj ./PixelService.Infrastructure/
RUN dotnet restore

COPY . .
WORKDIR /app/PixelService.API
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "PixelService.API.dll"]
