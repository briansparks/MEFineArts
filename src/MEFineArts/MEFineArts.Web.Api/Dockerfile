FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MEFineArts.Web.Api/MEFineArts.Web.Api.csproj", "MEFineArts.Web.Api/"]
COPY ["MEFineArts.Data.Persistence/MEFineArts.Data.Persistence.csproj", "MEFineArts.Data.Persistence/"]
RUN dotnet restore "MEFineArts.Web.Api/MEFineArts.Web.Api.csproj"
COPY . .
WORKDIR "/src/MEFineArts.Web.Api"
RUN dotnet build "MEFineArts.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MEFineArts.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MEFineArts.Web.Api.dll"]