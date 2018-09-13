dotnet pack ..\src\BoomiSharp\BoomiSharp.csproj --configuration Release --output "$PSScriptRoot\..\publish"
dotnet pack ..\src\BoomiSharp.Dtos\BoomiSharp.Dtos.csproj --configuration Release --output "$PSScriptRoot\..\publish"
dotnet pack ..\src\BoomiSharp.Query\BoomiSharp.Query.csproj --configuration Release --output "$PSScriptRoot\..\publish"
