#!/usr/bin/env bash
  
echo "Waiting for AdminUI"
./wait-for-it.sh ui-int:5000 -t 360

if [ $? -eq 0 ]
then 
  echo "Validating user license ..."
  dotnet test --logger "xunit;LogFilePath=/log/license-test.xml" --filter DisplayName=TestService.TestCollections.Onboarding.License.ShouldVerifyUserLicenseHasNotExpired
  if [ $? -eq 0 ]
  then 
	echo "Running tests ..."
	dotnet test --logger "xunit;LogFilePath=/log/app-tests.xml" --filter DisplayName!=TestService.TestCollections.Onboarding.License.ShouldVerifyUserLicenseHasNotExpired
    if [ $? -eq 0 ]
    then
	  exit 0
	fi
  else
    echo "AdminUI license expired"
  fi
fi
exit 1