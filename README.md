 Disaster Alleviation - ASP.NET Core MVC 
This is a minimal sample ASP.NET Core MVC application prepared for your assignment. It includes:
- User registration & login (ASP.NET Identity)
- Incident reporting form
- Donation submission form
- Volunteer signup/listing
- Images from your provided screenshots in `wwwroot/images/`
- A light grey background across the site as requested.

 How to run locally

1. Make sure you have the .NET 7 SDK installed.
2. Open a terminal in the project folder (where `DisasterAlleviation.csproj` is).
3. Run `dotnet restore` (installs packages).
4. Run `dotnet ef database update` to create the SQLite database (Install EF tools if needed: `dotnet tool install --global dotnet-ef`). Alternatively the app will create the DB on first run.
5. Run `dotnet run` and open https://localhost:5001 or the URL shown in console.

Notes for submission
- Source code is included in this archive.
- A sample `azure-pipelines.yml` is included as example configuration for Azure Pipelines.
- Please add your Azure Repos remote and push to enable instructor access.
