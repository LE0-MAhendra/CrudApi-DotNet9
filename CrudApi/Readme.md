
````markdown
# 📦 Entity Framework Core Cheat Sheet (.NET)

A quick reference guide to commonly used methods and database migration commands in **Entity Framework Core** (EF Core) for .NET developers.

---

## 📚 Table of Contents

- [🔍 Querying Data](#-querying-data)
- [📝 Inserting Data](#-inserting-data)
- [✏️ Updating Data](#️-updating-data)
- [❌ Deleting Data](#-deleting-data)
- [📡 Async Methods](#-async-methods)
- [🛠️ Migrations & Database Commands](#️-migrations--database-commands)

---

## 🔍 Querying Data

| Method                   | Description                                 |
|--------------------------|---------------------------------------------|
| `ToList()`               | Convert query to a `List<T>`                |
| `ToListAsync()`          | Async version of `ToList()`                 |
| `FirstOrDefault()`       | First match or `null`                       |
| `FirstOrDefaultAsync()`  | Async version                               |
| `SingleOrDefault()`      | Exactly one match or `null`, else error     |
| `Find()` / `FindAsync()` | Find by primary key                         |
| `Where()`                | Filter records                              |
| `Any()` / `AnyAsync()`   | Returns `true` if any record exists         |
| `Count()` / `CountAsync()`| Count records                              |
| `OrderBy()` / `ThenBy()` | Sort results                                |
| `Include()`              | Eager load navigation properties            |
| `Select()`               | Projection (select specific fields)         |
| `Distinct()`             | Remove duplicates                           |

---

## 📝 Inserting Data

```csharp
var user = new User { Name = "Alice" };
context.Users.Add(user);
context.SaveChanges();
````

Async:

```csharp
await context.Users.AddAsync(user);
await context.SaveChangesAsync();
```

---

## ✏️ Updating Data

```csharp
var user = context.Users.Find(1);
user.Name = "Updated Name";
context.SaveChanges();
```

Async:

```csharp
var user = await context.Users.FindAsync(1);
user.Name = "Updated Name";
await context.SaveChangesAsync();
```

---

## ❌ Deleting Data

```csharp
var user = context.Users.Find(1);
context.Users.Remove(user);
context.SaveChanges();
```

Async:

```csharp
var user = await context.Users.FindAsync(1);
context.Users.Remove(user);
await context.SaveChangesAsync();
```

---

## 📡 Async Methods

Use async methods in web apps for better scalability.

| Synchronous        | Asynchronous            |
| ------------------ | ----------------------- |
| `ToList()`         | `ToListAsync()`         |
| `Find()`           | `FindAsync()`           |
| `SaveChanges()`    | `SaveChangesAsync()`    |
| `Any()`            | `AnyAsync()`            |
| `Count()`          | `CountAsync()`          |
| `FirstOrDefault()` | `FirstOrDefaultAsync()` |

Make sure to include:

```csharp
using Microsoft.EntityFrameworkCore;
```

---

## 🛠️ Migrations & Database Commands

> Run these in the **Package Manager Console** or CLI

### Package Manager Console

```powershell
Add-Migration InitialCreate
Update-Database
Remove-Migration
```

### .NET CLI

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations remove
```

### Install Tools (if needed)

```bash
dotnet tool install --global dotnet-ef
```

---

## 🧩 Notes

* Use `Include()` for eager loading navigation properties.
* Use `AsNoTracking()` for read-only queries (better performance).
* Async methods help in non-blocking I/O scenarios like web APIs.

---

## 🧪 Example: Full Query with Include

```csharp
var orders = await context.Orders
    .Include(o => o.Customer)
    .Where(o => o.Total > 100)
    .OrderBy(o => o.OrderDate)
    .ToListAsync();
```

