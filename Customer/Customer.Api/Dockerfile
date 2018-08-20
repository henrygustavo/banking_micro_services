FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["Customer/Customer.Api/Customer.Api.csproj", "Customer/Customer.Api/"]
COPY ["Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "Customer/Customer.Infrastructure/"]
COPY ["Customer/Customer.Domain/Customer.Domain.csproj", "Customer/Customer.Domain/"]
COPY ["Customer/Customer.Application/Customer.Application.csproj", "Customer/Customer.Application/"]
RUN dotnet restore "Customer/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Customer/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]