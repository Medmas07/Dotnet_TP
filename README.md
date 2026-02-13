
# 🎬 WebApplication1 – ASP.NET Core MVC Project

Projet académique réalisé en **ASP.NET Core MVC (.NET 8)** avec :

* Entity Framework Core
* SQLite
* Architecture Service Layer
* LINQ avancé
* Upload d’images
* Interceptor (Audit Log)
* ASP.NET Core Identity

---

# 📌 Fonctionnalités Implémentées

## ✅ TP1 – MVC Basics

* Routing (Convention & Attribute)
* Controllers & Views
* ViewModels
* Layout personnalisé

---

## ✅ TP2 – EF Core & CRUD

* Code First
* SQLite Database
* CRUD complet Movie & Genre
* Relations 1-N (Genre → Movies)
* Migrations

---

## ✅ TP3 – Data Manipulation

* Seed Data via JSON (`Movies.json`)
* Upload image avec `IFormFile`
* ViewModel pour Create
* Validation ModelState
* Interceptor EF Core (AuditLog)
* Stock & DateAjoutMovie

---

## ✅ TP4 – Architecture & LINQ

* Architecture Service Layer
* Interface `IMovieService`
* Injection de dépendance
* Requêtes LINQ :

    * Where
    * OrderBy / ThenBy
    * Count
    * Join
    * Take
* DTO pour jointure Movie + Genre

---

## ✅ TP5 – ASP.NET Core Identity

* Authentication (Register / Login)
* Extension de IdentityUser (City)
* Liste des utilisateurs
* Autorisation `[Authorize]`
* Panier par utilisateur
* Tables Identity générées par EF

---

# 🏗️ Architecture du Projet

```
Models/
Services/
    ServiceContracts/
Controllers/
ViewModels/
Views/
wwwroot/images/
Movies.json
```

---

# 🗄️ Base de données

* SQLite (`app.db`)
* Code First
* Migrations EF Core

Pour recréer la base :

```bash
dotnet ef migrations add Initial
dotnet ef database update
```

---

# 🚀 Lancer le projet

```bash
dotnet build
dotnet run
```

Puis ouvrir :

```
https://localhost:xxxx
```

---

# 🔐 Authentification

* Register
* Login
* Gestion des utilisateurs
* Extension ApplicationUser (City)

---

# 📊 Requêtes LINQ Implémentées

* Films Action avec stock > 0
* Films ordonnés par date puis titre
* Nombre total de films
* Jointure Movie + Genre
* Top 3 genres populaires
* Clients abonnés avec remise > 10%

---

# 🛠️ Technologies Utilisées

* ASP.NET Core 8
* Entity Framework Core
* SQLite
* Bootstrap 5
* Identity

---

# 🎓 Auteur

Projet académique – TP ASP.NET Core
Année universitaire 2024/2025


