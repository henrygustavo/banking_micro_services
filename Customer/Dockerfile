FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["Customer.Api/Customer.Api.csproj", "Customer.Api/"]
COPY ["Customer.Infrastructure/Customer.Infrastructure.csproj", "Customer.Infrastructure/"]
COPY ["Customer.Domain/Customer.Domain.csproj", "Customer.Domain/"]
COPY ["Customer.Application/Customer.Application.csproj", "Customer.Application/"]
RUN dotnet restore "Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]