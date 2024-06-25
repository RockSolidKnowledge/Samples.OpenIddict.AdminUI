#!/usr/bin/env bash
if [[ $# -ne 2 ]]
  then
	echo "Invalid arguments count for DbStart.sh"
	exit 1
fi

db=$1
port=$2

./wait-for-it.sh $db:$port -t 120 -- && printf "\n\nRunning ALL Migrations\n\nWarning -  These will run on every startup of the demo\nIf you want to modify migrations being run for Production use please see documentation at https://www.identityserver.com/documentation/adminui \n\n" && dotnet IdentityExpress.Manager.UI.dll -migrate all && printf "\n Migrations Complete - Starting API \n\n" && dotnet IdentityExpress.Manager.UI.dll
