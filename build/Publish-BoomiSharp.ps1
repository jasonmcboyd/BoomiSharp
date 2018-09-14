dotnet pack "$PSScriptRoot\..\src\BoomiSharp\BoomiSharp.csproj" --configuration Release --output "$PSScriptRoot\..\publish"
dotnet pack "$PSScriptRoot\..\src\BoomiSharp.Dtos\BoomiSharp.Dtos.csproj" --configuration Release --output "$PSScriptRoot\..\publish"
dotnet pack "$PSScriptRoot\..\src\BoomiSharp.Query\BoomiSharp.Query.csproj" --configuration Release --output "$PSScriptRoot\..\publish"
