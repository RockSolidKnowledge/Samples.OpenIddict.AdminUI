SUFFIX=$1

echo Generating Identity Scripts with Suffix: $SUFFIX
dotnet ef migrations script --context IdentityDbContext --output ./Migration_Scripts/Identity_$SUFFIX.sql

echo Generating Application Scripts with Suffix: $SUFFIX
dotnet ef migrations script --context ApplicationDbContext --output ./Migration_Scripts/Application_$SUFFIX.sql
