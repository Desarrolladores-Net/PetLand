FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .
RUN dotnet publish
CMD dotnet .1-UI/Api/bin/Debug/net7.0/publish/Api.dll