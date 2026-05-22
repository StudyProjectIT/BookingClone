# Migrations

Після рефакторингу архітектури (Domain винесено в окремий проєкт) старі міграції видалено.
Згенеруйте чисту початкову міграцію командою:

```bash
dotnet ef migrations add InitialCreate \
  --project backend/Infrastructure \
  --startup-project backend/API \
  --output-dir Migrations
```

Потім застосуйте її:

```bash
dotnet ef database update --project backend/Infrastructure --startup-project backend/API
```

> Команда не виконана автоматично, оскільки в build-середовищі відсутній
> `Microsoft.AspNetCore.App` runtime (присутній лише .NET Core runtime).
> Локально, з повним SDK + ASP.NET Core Runtime, команда відпрацює коректно.
