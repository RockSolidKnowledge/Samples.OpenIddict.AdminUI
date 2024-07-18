#!/usr/bin/env bash

if [[ $# -ne 2 ]]
  then
	echo "Invalid arguments count for StartOppenIddict.sh"
	exit 1
fi

db=$1
port=$2

./wait-for-it.sh $db:$port -t 180 -- && printf "\n\nUpdating the database ...\n\n" && ./DbMigrations.sh && printf "\n\nPublishing OpenIddict ...\n\n" && ./Publish.sh && dotnet Rsk.Samples.OpenIddict.AdminUiIntegration.dll



 