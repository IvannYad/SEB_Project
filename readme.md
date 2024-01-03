### Setup
  **1. Change connection string**  
   * Go to **appsettings.Local.json** in **StreetCode.WebApi** project and write your local database connection string in following format:
    
     ```
      Server={local_server_name};Database=StreetcodeDb;User Id={username};Password={password};MultipleActiveResultSets=true;
     ```

  **2. Add database seeding**
   - Go to **Program.cs** in **StreetCode.WebApi** project and add following code:

     ```csharp
     await app.SeedDataAsync(); 
     ```
     
  **3. Create and seed local database**  
   * Run project and make sure that database was created and filled with data( note that not all tables will be populated with data)


