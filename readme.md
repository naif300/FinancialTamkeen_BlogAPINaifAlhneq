
# FinancialTamkeen_BlogAPI
 This code is part of the project "FinancialTamkeen_BlogAPI".
It performs a specific task related to the project.


## Requairment
    -dotnet 6

------------
## Usage:
    -Dependency setup
```
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.2 
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.2
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.2

dotnet tool install --global dotnet-ef

dotnet add package AutoMapper --version 13.0.1
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
```
    -run test to use `swagger`
```
dotnet watch run
```
# endpoints:

    - api/Blog/all
        return all products

    - api/Blog/{id}
        return a single Blog by id

    - api/Blog/create
        it create Blog with following keys:
            - "id": int    
            - "title": string,
            - "content": string,
       

    - api/Blog/{id}/update
        it update a single Blog with following keys:
            - "title": string,
            - "content": string,
         






