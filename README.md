# WBAPI-AuthApi

Comandos para ejecutar la migración

dotnet ef migrations add addInitialDB --project Infrastructure --startup-project WBAPI-Reservation
dotnet ef migrations add addAuthSchema --project Infrastructure --startup-project AuthApi
dotnet ef database update --project Infrastructure --startup-project WebApi

Comandos para implementar en docker
docker build . -f WebApi/Dockerfile -t vehiculosapi
docker run -p 8060:8080 vehiculosapi

docker build . -f BookingApi/Dockerfile -t bookingapi
docker run -p 8070:8080 bookingapi

docker build . -f WebApi/Dockerfile -t authapi
docker run -p 8050:8080 authapi

docker build . -f RentaFacilWorker/Dockerfile -t worker

docker build -t rentafacil .
docker run -d -p 8080:80 rentafacil

Usuarios:
pedroperez: Administrador
grabrielgomez: Asesor Medellin
rodolforuiz: Asesor Bogotá

Contraseña para todos los usuarios:
Prueba123*

Comandos para la ejecución de pruebas
Back:
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Front
ng test --code-coverage