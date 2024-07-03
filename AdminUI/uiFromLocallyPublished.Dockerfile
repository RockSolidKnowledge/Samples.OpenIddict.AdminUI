# This image comes with the .NET runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0

# ARG DATABASE_CONNECTION
# ENV OpenIddictConnectionString=$DATABASE_CONNECTION

WORKDIR /app

COPY ./publish .

#WORKDIR /src

COPY ./StartAdminUI.sh .
COPY ./wait-for-it.sh .

RUN chmod +x StartAdminUI.sh
RUN chmod +x wait-for-it.sh

