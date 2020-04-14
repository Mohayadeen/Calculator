FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY . .
WORKDIR "/src/CoreCalculator"
RUN dotnet build "CoreCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreCalculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreCalculator.dll"]