# Use the .NET SDK base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file to the container
COPY WebApi.csproj ./

# Restore the dependencies
RUN dotnet restore WebApi.csproj

# Copy the rest of the source code
COPY . .

# Build the project
RUN dotnet build WebApi.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish WebApi.csproj -c Release -o /app/publish

# Use the ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the application port
EXPOSE 8080

ENV ASPNETCORE_ENVIRONMENT=Development
ENV db_connection_string="Server=tcp:ced-sqlinterns-t-01.database.windows.net,1433;Database=CED.AksInterns;User Id=AksUser;Password=YR-%Sbw7#S0;"

# Set the entry point for the application
ENTRYPOINT ["dotnet", "WebApi.dll"]
