FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["*.csproj", "./"]
RUN dotnet restore "ProjectName.csproj"
COPY . .
RUN dotnet build "ProjectName.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectName.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectName.dll"]