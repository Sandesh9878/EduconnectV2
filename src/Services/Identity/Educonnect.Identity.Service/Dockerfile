#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Identity/Educonnect.Identity.Service/Educonnect.Identity.Service.csproj", "Services/Identity/Educonnect.Identity.Service/"]
COPY ["Core/Educonnect.Core/Educonnect.Core.csproj", "Core/Educonnect.Core/"]
RUN dotnet restore "Services/Identity/Educonnect.Identity.Service/Educonnect.Identity.Service.csproj"
COPY . .
WORKDIR "/src/Services/Identity/Educonnect.Identity.Service"
RUN dotnet build "Educonnect.Identity.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Educonnect.Identity.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Educonnect.Identity.Service.dll"]
