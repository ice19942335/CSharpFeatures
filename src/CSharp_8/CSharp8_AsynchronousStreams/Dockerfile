FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CSharp_8/CSharp8_AsynchronousStreams/CSharp8_AsynchronousStreams.csproj", "src/CSharp_8/CSharp8_AsynchronousStreams/"]
RUN dotnet restore "src/CSharp_8/CSharp8_AsynchronousStreams/CSharp8_AsynchronousStreams.csproj"
COPY . .
WORKDIR "/src/src/CSharp_8/CSharp8_AsynchronousStreams"
RUN dotnet build "CSharp8_AsynchronousStreams.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CSharp8_AsynchronousStreams.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharp8_AsynchronousStreams.dll"]
