#!/usr/bin/env bash
  
echo "Waiting for AdminUI"
./wait-for-it.sh ui-int:5000 -t 120

if [ $? -eq 0 ]
then 
  echo "Validating user license ..."
  dotnet test --logger "xunit;LogFilePath=/logs/license-test.xml" --filter DisplayName=TestService.TestCollections.Onboarding.License.ShouldVerifyUserLicenseHasNotExpired
  if [ $? -eq 0 ]
  then 
	echo "Validated user valid."
	echo "Running tests ..."
	#dotnet test --logger "xunit;LogFilePath=/logs/bootstrapping-test.xml" --filter DisplayName=TestService.TestCollections.Onboarding.Bootstrap.DuringOnboarding_TheUserCanBootstrapAUserAndLoginAsTheNewUser
    dotnet test --logger "xunit;LogFilePath=/logs/app-tests.xml" --filter DisplayName!=TestService.TestCollections.Onboarding.License.ShouldVerifyUserLicenseHasNotExpired
    if [ $? -eq 0 ]
    then
	  exit 0
	fi
  else
    echo "AdminUI license expired"
  fi
fi
exit 1