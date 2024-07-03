# To be build image from scratch (project [Rsk.Samples.OpenIddict.AdminUiIntegration] in solution)

# We need to update the database when the database service is up and running. 
# The dotnet-ef needs the source code (not the binaries) to update the database, so we will copy the source
# and delay building and publishing till the database has been updated

# This image comes with the .NET runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG DATABASE_CONNECTION
ENV ConnectionStrings__DefaultConnection=$DATABASE_CONNECTION

EXPOSE 80

EXPOSE 443 

USER root

WORKDIR /app

COPY ./Rsk.Samples.OpenIddict.AdminUI .
COPY ./wait-for-it .
RUN dotnet restore "./Rsk.Samples.OpenIddict.AdminUiIntegration.csproj"

ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef --version 8.0.4

RUN chmod +x StartOpen.sh
RUN chmod +x wait-for-it.sh
RUN chmod +x DbUpdate.sh
RUN chmod +x Publish.sh

# Still to establish how this user comes into play in AdminUI. The compose uses "root" user.
# USER identityexpress
