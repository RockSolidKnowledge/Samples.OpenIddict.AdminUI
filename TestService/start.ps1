#!/usr/bin/env pwsh
param(
    [Parameter(Mandatory=$true)]
    [string]$SourceFilePath
)

Copy-Item -Path $SourceFilePath/docker-compose.yml .

# To repeatedly re-run tests locally, after code changes for example, we need to remove any relicks of prior runs (like published folder contents and database objects)
echo "Removing existing containers ..."
docker rm $(docker ps -a -q)

docker-compose up --build --exit-code-from ui-tests

#New-Item -ItemType Directory -Force -Path ./Errors

docker-compose logs --no-color admin-ui > ./ui-logs.txt
docker-compose logs --no-color ui-tests > ./uitests-logs.txt

echo "Freeing up disk space"
docker image rm $(docker images -f "dangling=true" -q)
