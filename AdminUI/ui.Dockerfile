# This image comes with the .NET runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-n-publish

WORKDIR /src

#COPY ["./AdminUI.csproj", "."]
# Currently only depends on one package from an Rsk feed package. We will NOT restore this feed 
#RUN dotnet restore "./AdminUI.csproj"
COPY . .

RUN dotnet publish "./AdminUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build-n-publish as final
WORKDIR /app
COPY --from=build-n-publish /app/publish .
# COPY ./AdminUI.csproj .

WORKDIR /src

COPY ./StartAdminUI.sh .
COPY ./wait-for-it.sh .

RUN chmod +x StartAdminUI.sh
RUN chmod +x wait-for-it.sh

# ENTRYPOINT ["./StartAdminUI.sh" "oi-int" "5003"] 
