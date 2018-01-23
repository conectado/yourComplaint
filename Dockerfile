FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
#Build database
RUN dotnet ef database update
#Build project
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/yourComplaint.db .
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "yourComplaint.dll"]
