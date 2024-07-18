#!/usr/bin/env bash

echo "Db Provider is : " $ConnectionStrings__DbProvider
echo "Connection string is : " $ConnectionStrings__DefaultConnection

if [[ ! -z $ConnectionStrings__DefaultConnection && $ConnectionStrings__DefaultConnection != " " ]] 
then   
	echo "Running migrations ..." 
    echo "Adding migrations ..." 
	dotnet-ef migrations add Initial --project /app/Rsk.Samples.OpenIddict.AdminUiIntegration.csproj --context ApplicationDbContext
    
	echo "Updating the database ..."
	dotnet-ef database update --project /app/Rsk.Samples.OpenIddict.AdminUiIntegration.csproj --context ApplicationDbContext
	
	echo "Completed running migrations ..." 
	exit 0
else
	echo "ERROR: Database connection string is null or blank"
fi
exit 1

