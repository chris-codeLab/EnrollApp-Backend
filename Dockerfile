FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-image

WORKDIR /home/app

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

RUN dotnet restore

COPY . .


RUN dotnet publish ./EnrollApp-Backend.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /publish

COPY --from=build-image /publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

ENTRYPOINT ["dotnet", "EnrollApp-Backend.dll"]