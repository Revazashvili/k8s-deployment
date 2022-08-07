FROM mcr.microsoft.com/dotnet/sdk:6.0 as dev

RUN mkdir /api/
WORKDIR /api

COPY ./src/api.csproj /api/api.csproj
RUN dotnet restore

COPY ./src /api
RUN mkdir /out

RUN dotnet publish --no-restore -o /out/ -c Release

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as prod

RUN mkdir /app/
WORKDIR /app/

COPY --from=dev /out/ /app/
RUN chmod +x /app/

CMD dotnet api.dll