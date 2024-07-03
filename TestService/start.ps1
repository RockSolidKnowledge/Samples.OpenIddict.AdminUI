#!/usr/bin/env pwsh
param(
    [Parameter(Mandatory=$true)]
    [string]$SourceFilePath
)

Copy-Item -Path $SourceFilePath/docker-compose.yml .

docker-compose up --build --exit-code-from ui-tests

#New-Item -ItemType Directory -Force -Path ./Errors

docker-compose logs --no-color ui-int > ./ui-logs.txt
docker-compose logs --no-color ui-tests > ./uitests-logs.txt