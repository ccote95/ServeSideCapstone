### ChadsList
Everyone has something laying around their house that they would like to get rid of. That's what this application aims to solve, allowing users to register and instantly list items for sale, look at other users listings and purchasing the things they want
Setup:
1. In the top-level directory of the cloned project on your computer, run `dotnet user-secrets init`
1. Run `dotnet user-secrets set AdminPassword password` (you can choose a different password if you wish)
1. Run `dotnet user-secrets set TabloidDbConnectionString 'Host=localhost;Port=5432;Username=postgres;Password=password;Database=Tabloid'`
1. Run `dotnet restore`
1. Run `dotnet build`
1. Run `dotnet ef migrations add InitialCreate`
1. Run `dotnet ef database update`
1. Run `cd client`
1. Run `npm install`

## Test the Setup
1. Start debugging the API and run `npm run dev` in the `client` directory. 
1. You should see the login view when the UI opens. 
1. Attempt to login with `admina@strator.comx` and the password you set the value of `AdminPassword` to in the user-secrets
1. If the setup succeeded, you should see a welcome message, and a `User Profiles` menu option along with a logout button. 
