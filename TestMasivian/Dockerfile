FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
MAINTAINER Nestor Orlando Rojas "nestorrojas07@gmail.com"

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

WORKDIR /build
COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c $BUILDCONFIG -o out


FROM mcr.microsoft.com/dotnet/core/sdk:3.1

MAINTAINER Nestor Orlando Rojas "nestorrojas07@gmail.com"

ENV REDISHOST=172.17.0.3
ENV REDISPORT=6379

EXPOSE 5000

WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "TestMasivian.dll"] 

