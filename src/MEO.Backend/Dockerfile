FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MEO.API/MEO.API.csproj", "src/MEO.API/"]
RUN dotnet restore "src/MEO.API/MEO.API.csproj"
COPY . .
WORKDIR "/src/src/MEO.API"
RUN dotnet build "MEO.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MEO.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MEO.API.dll"]