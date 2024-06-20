### ChadsList
Everyone has something laying around their house that they would like to get rid of. That's what this application aims to solve, allowing users to register and instantly list items for sale, look at other users listings and purchasing the things they want

### Technologies Used
- ReactJS
- ReactStrap
- EF Core 8.0
- PostgreSQL 16
- JavaScript
- HTNL5
- CSS
- Vite
### Installation & Setup:
Clone this repository, and ensure you have the following installed on your machine:
- node
- npm
- .Net 8.0
- PostgreSQL 16
Then run the following command:
```
dotnet tool install --global dotnet-ef --framework net8.0
```
Navigate to the cloned  directory and run the following:
```
dotnet user-secrets init
```
dotnet user-secrets set 'ServerSideCapstoneDbConnectionString' 'Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=Capstone'
```
```
dotnet user-secrets set AdminPassword password
```
```
dotnet restore
```
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```
Then navigate to the client directory and run the following:
```
npm install
```
# Run Database
Run the following command in the project directory:
```
dotnet watch run --launch-profile https
```
# Run Website
Navigate to the client directory and run the following:
```
npm run dev
```
