#!/usr/bin/env bash

dotnet publish "/app/Rsk.Samples.OpenIddict.AdminUiIntegration.csproj" -o /app /p:UseAppHost=false
if [ $? -eq 0 ]
  then
	echo "Completed publishing OpenIddict"
	exit 0
else
  echo "Error: Failed to publish OpenIddict"
fi
exit 1

