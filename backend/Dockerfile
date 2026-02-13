FROM mcr.microsoft.com/dotnet/sdk:10.0-preview
WORKDIR /src

COPY ["backend.csproj", "./"]
RUN dotnet restore "backend.csproj"

COPY . .

EXPOSE 8080