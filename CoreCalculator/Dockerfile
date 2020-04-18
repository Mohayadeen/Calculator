FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./CalculatorApi/CalculatorApi.csproj ./
RUN dotnet restore
COPY ./CoreCalculator/CoreCalculator.csproj ./
RUN dotnet restore ./CoreCalculator.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./CoreCalculator.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/CoreCalculator/out .
ENTRYPOINT ["dotnet", "CoreCalculator.dll"]