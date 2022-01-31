#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Photo.Presentation.WebPublicAPI/Photo.Presentation.WebPublicAPI.csproj", "Photo.Presentation.WebPublicAPI/"]
COPY ["Photo.Infrastructure.Boostrap/Photo.Infrastructure.Boostrap.csproj", "Photo.Infrastructure.Boostrap/"]
COPY ["Photo.Infrastructure.AWS/Photo.Infrastructure.AWS.csproj", "Photo.Infrastructure.AWS/"]
COPY ["Photo.Domain/Photo.Domain.csproj", "Photo.Domain/"]
COPY ["Photo.BussinessLogic/Photo.BusinessLogic.csproj", "Photo.BussinessLogic/"]
COPY ["Photo.Infrastructure.EFPersistency/Photo.Infrastructure.EFPersistency.csproj", "Photo.Infrastructure.EFPersistency/"]
RUN dotnet restore "Photo.Presentation.WebPublicAPI/Photo.Presentation.WebPublicAPI.csproj"
COPY . .
WORKDIR "/src/Photo.Presentation.WebPublicAPI"
RUN dotnet build "Photo.Presentation.WebPublicAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Photo.Presentation.WebPublicAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Photo.Presentation.WebPublicAPI.dll"]