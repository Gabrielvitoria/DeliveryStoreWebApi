#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443
EXPOSE 44356

ENV ASPNETCORE_URLS=http://*:44356
ENV ASPNETCORE_ENVIRONMENT="Development"

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
COPY . ./src
WORKDIR /src
COPY ["DeliveryStoreWebApi/DeliveryStoreWebApi.csproj", "DeliveryStoreWebApi/"]
COPY ["DeliveryStoreServices/DeliveryStoreServices.csproj", "DeliveryStoreWebApi/DeliveryStoreServices"]
COPY ["DeliveryStoreInfra/DeliveryStoreInfra.csproj", "DeliveryStoreWebApi/DeliveryStoreInfra"]
COPY ["DeliveryStoreDomain/DeliveryStoreDomain.csproj", "DeliveryStoreWebApi/DeliveryStoreDomain"]
COPY ["DeliveryStoreCommon/DeliveryStoreCommon.csproj", "DeliveryStoreWebApi/DeliveryStoreCommon"]
COPY ["DeliveryStore.Tests/DeliveryStore.Tests.csproj", "DeliveryStoreWebApi/DeliveryStore.Tests"]


RUN dotnet restore "DeliveryStoreWebApi/DeliveryStoreWebApi.csproj"
COPY . .
WORKDIR "/src/DeliveryStoreWebApi"
RUN dotnet build "DeliveryStoreWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliveryStoreWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliveryStoreWebApi.dll"]