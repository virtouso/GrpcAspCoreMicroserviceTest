FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestCustomAuth/TestCustomAuth.csproj", "TestCustomAuth/"]
RUN dotnet restore "TestCustomAuth/TestCustomAuth.csproj"
COPY . .
WORKDIR "/src/TestCustomAuth"
RUN dotnet build "TestCustomAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestCustomAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestCustomAuth.dll"]
