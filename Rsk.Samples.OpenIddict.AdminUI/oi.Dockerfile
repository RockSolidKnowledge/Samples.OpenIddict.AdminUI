# To be build image from scratch (project [Rsk.Samples.OpenIddict.AdminUiIntegration] in solution)

# We need to update the database when the database service is up and running. 
# The dotnet-ef needs the source code (not the binaries) to update the database, so we will copy the source
# and delay building and publishing till the database has been updated

# This image comes with the .NET runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0

#ARG DBPROVIDER
#ENV DbProvider=$DBPROVIDER

#ARG DATABASE_CONNECTION
#ENV ConnectionStrings__ConnectionString=$DATABASE_CONNECTION
RUN echo "Db provider during build is:" $ConnectionStrings__DbProvider
RUN echo "Default connection string during build is:" $ConnectionStrings__DefaultConnection

EXPOSE 80

EXPOSE 443 

USER root

WORKDIR /app

# This also copies source to which we will add the ef migration, but only after the db service is ready. 
COPY . .

ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef --version 8.0.5

RUN chmod +x StartOpenIddict.sh
RUN chmod +x wait-for-it.sh
RUN chmod +x DbMigrations.sh
RUN chmod +x Publish.sh

# Still to establish how this user comes into play in AdminUI. The compose uses "root" user.
# USER identityexpress
