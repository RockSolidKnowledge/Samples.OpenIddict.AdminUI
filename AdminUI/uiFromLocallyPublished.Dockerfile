# NOTE : To test using OpenIddict AdminUI package from Rsk feed, we build and publish locally and just
# copy the publised folder contents to the container /app folder. This because we cannot build the project
# here bc of the private feed package. Any dotnet command that forces a restore here will require a
# Personal Access Token (PAT) to restore

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

