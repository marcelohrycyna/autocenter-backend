FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /autocenter

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /autocenter
COPY --from=build /autocenter/out .
ENTRYPOINT ["dotnet", "AUTOCENTER.API.dll"]