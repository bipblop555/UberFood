# 🍔 UberFood - Application Console (.NET 9.0)

Cette application console est développée en **C# (.NET 9.0)** et utilise **Entity Framework Core** pour la gestion des données.  
Le projet illustre une architecture simple et robuste permettant d’interagir avec une base de données SQL Server.

---

## ⚙️ Prérequis

Avant de lancer le projet, assurez-vous d’avoir installé :

- **.NET 9.0 SDK**  
- **SQL Server** (local ou distant)  
- Les paquets NuGet suivants :  
  - [`Microsoft.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)  
  - [`Microsoft.EntityFrameworkCore.Design`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/)  
  - [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)  

- **Migrations** 
```bash
    - dotnet ef database update --project .\UberFood.Core\

Installation via la CLI :  

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

