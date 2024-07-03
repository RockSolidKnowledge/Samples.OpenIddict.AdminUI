#!/usr/bin/env bash

#ConnectionStrings__DefaultConnection=$DATABASE_CONNECTION
#DbProvider=$DbProvider

echo "Db Provider is : " $DbProvider
echo "Connection string is : " $ConnectionStrings__DefaultConnection

if [[ ! -z $ConnectionStrings__DefaultConnection && $ConnectionStrings__DefaultConnection != " " ]] 
then      
	echo "Updating the database ..."
	dotnet-ef database update --project /app/Rsk.Samples.OpenIddict.AdminUiIntegration.csproj --context ApplicationDbContext
	exit 0
else
	echo "ERROR: DATABASE_CONNECTION is null or blank"
fi
exit 1

