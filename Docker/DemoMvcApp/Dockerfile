## Multi Stage Build
# Stage 1 Build phase
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.402-bionic AS build
WORKDIR /src
COPY ["DemoMvcApp.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /bin
RUN dotnet publish -c Release -o /dist

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.7-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Production
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "DemoMvcApp.dll"]