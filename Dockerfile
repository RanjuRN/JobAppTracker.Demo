FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /App

# Kestrel default ports in container; we'll publish 8080 outside
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -o out

# Build runtime image
FROM build AS final
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "JobAppTracker.Demo.dll"]