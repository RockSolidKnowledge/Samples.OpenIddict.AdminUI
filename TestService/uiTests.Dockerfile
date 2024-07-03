# FROM mcr.microsoft.com/playwright/dotnet:v1.39.0-jammy AS build-n-publish
FROM mcr.microsoft.com/playwright/dotnet:v1.44.0-jammy AS build-n-publish

WORKDIR /src

COPY ["TestService.csproj", "."]
RUN dotnet restore "./TestService.csproj"
COPY . .

RUN dotnet publish "TestService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build-n-publish as final
WORKDIR /app
COPY --from=build-n-publish /app/publish .
# COPY ./TestService.csproj .

WORKDIR /src

COPY ./TestStart.sh .
COPY ./wait-for-it.sh .

RUN chmod +x TestStart.sh
RUN chmod +x wait-for-it.sh

ENTRYPOINT ./TestStart.sh