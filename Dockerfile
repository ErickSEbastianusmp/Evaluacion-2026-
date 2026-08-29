# Usar SDK e Imagen Runtime de .NET 10.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["TecnoGasHogar/TecnoGasHogar.csproj", "TecnoGasHogar/"]
RUN dotnet restore "TecnoGasHogar/TecnoGasHogar.csproj"
COPY . .
WORKDIR "/src/TecnoGasHogar"
RUN dotnet build "TecnoGasHogar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TecnoGasHogar.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TecnoGasHogar.dll"]