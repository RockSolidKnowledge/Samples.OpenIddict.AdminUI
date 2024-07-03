#!/usr/bin/env bash
if [[ $# -ne 2 ]]
  then
	echo "Invalid arguments count for StartAdminUI.sh"
	exit 1
fi

oi=$1
port=$2

./wait-for-it.sh $oi:$port -t 300

#DbProvider=$DBPROVIDER
#echo "DbProvider is : " $DbProvider
if [[ ! -z $DbProvider && $DbProvider != " " ]] 
then
	#ConnectionStrings__DefaultConnection=$DATABASE_CONNECTION
	#echo "Connection string is : " $OpenIddictConnectionString

	if [[ ! -z $OpenIddictConnectionString && $OpenIddictConnectionString != " " ]] 
	then
		#./wait-for-it.sh $oi:$port -t 300 -- && 
		printf "\n\nStarting AdminUI ...\n\n" && dotnet AdminUI.dll
		exit 0
	else
		echo "ERROR: Connection string not specified!"
	fi
else
	echo "ERROR: Database provider not specified!"
fi
exit 1



 