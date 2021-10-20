FROM mcr.microsoft.com/dotnet/sdk:3.1 AS dotnet-build
LABEL maintainer "Edson V. Queiroz <edsonvq@outlook.com>"

WORKDIR /src
COPY . /src
RUN dotnet restore "/SysContasPessoal/SysContasPessoal.csproj"
RUN dotnet build "/SysContasPessoal/SysContasPessoal.csproj" -c Release -o /app/build

FROM dotnet-build AS dotnet-publish
RUN dotnet publish "/SysContasPessoal/SysContasPessoal.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 5050
RUN mkdir /app/wwwroot
COPY --from=dotnet-publish /app/publish .
ENTRYPOINT ["dotnet", "SysContasPessoal.dll"]
