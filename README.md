readme_content = """# 🍔 UberFood - V2 (.NET 9.0)

Cette version 2 du projet **UberFood** intègre désormais :  
- Une **API REST en ASP.NET Core** pour exposer les données et fonctionnalités.  
- Une **interface web ASP.NET MVC** permettant d’interagir avec l’application depuis un navigateur.  
- L’ancienne **application console** (héritée de la V1) pour illustrer l’évolution et la compatibilité.  

L’application utilise **Entity Framework Core** pour la gestion des données avec **SQL Server**, en respectant une architecture simple et robuste.  

---

## ⚙️ Prérequis
Avant de lancer le projet, assurez-vous d’avoir installé :  
- [SDK .NET 9.0](https://dotnet.microsoft.com/download)  
- SQL Server (local ou distant)  
- Les paquets NuGet suivants :  
  - Microsoft.EntityFrameworkCore  
  - Microsoft.EntityFrameworkCore.Design  
  - Microsoft.EntityFrameworkCore.SqlServer  

---

## 📦 Migrations
Pour mettre à jour la base de données, exécutez :  
```bash
dotnet ef database update --project .\\UberFood.Core\\
