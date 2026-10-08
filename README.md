# bdoProject

ASP.NET-ზე დაწერილი Backend API, აგებული **Vertical Slice** არქიტექტურით. API-ს მიმართავს და იყენებს MCP სერვერი. პროექტში გამოყენებულია როგორც **REST**, ისე **GraphQL**. მონაცემთა ბაზა არის **PostgreSQL**, რომლის სქემაც იმართება **Entity Framework Core**-ით.

## ტექნოლოგიები

- ASP.NET Core (Vertical Slice Architecture)
- REST + GraphQL
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- MCP სერვერი (მოიხმარს ამ API-ს)

## გაჰოსტილი ვერსია

> **პროექტი და მონაცემთა ბაზა წინასწარ შექმნილია და გაჰოსტილია, ამიტომ ლოკალურად გაშვება აუცილებელი არ არის. შეგიძლიათ არ იწვალოთ და პირდაპირ გამოიყენოთ ქვემოთ მოცემული მისამართები.**

| სერვისი | ლინკი |
|---|---|
| GraphQL | https://bdoproject-back.onrender.com/graphql |
| Swagger (REST) | https://bdoproject-back.onrender.com/swagger/index.html |

Python აპლიკაციაში შეგიძლიათ გამოიყენოთ base URL:

```
https://bdoproject-back.onrender.com
```

## ლოკალურად გაშვება (არასავალდებულო)

თუ გსურთ აპლიკაციის თავად დატესტვა, მიჰყევით ქვემოთ მოცემულ ნაბიჯებს.

### 1. მონაცემთა ბაზა

საჭიროა **PostgreSQL** ბაზა. უმარტივესი გზაა ბაზის უფასოდ შექმნა [Neon](https://neon.tech)-ზე და მისი connection string-ის აღება.

### 2. appsettings.json

`bdoProject.Api` პროექტის `appsettings.json`-ში მიუთითეთ:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "my-connection-string"
  },
  "Jwt": {
    "Issuer": "my-issuer",
    "Audience": "my-clients",
    "SigningKey": "SuperSecretKeyThatIsAtLeast32CharsLong!!",
    "AccessTokenMinutes": 400,
    "RefreshTokenDays": 7
  }
}
```

- `DefaultConnection`-ში ჩაწერეთ თქვენი PostgreSQL (მაგ. Neon) connection string.
- JWT პარამეტრები შეგიძლიათ ისე დატოვოთ, როგორც არის, და იმუშავებს, ან შეიყვანოთ საკუთარი მნიშვნელობები. **`SigningKey`-ის სიგრძე უნდა იყოს მინიმუმ 32 სიმბოლო, ამიტომ ნუ შეამოკლებთ.**

### 3. EF Core ინსტრუმენტის დაყენება

```bash
dotnet tool install --global dotnet-ef
```

### 4. აპლიკაციის გაშვება

აპლიკაცია ერთხელ მაინც გაუშვით.

### 5. მიგრაციები

გახსენით ტერმინალი `bdoProject.Api` საქაღალდეში და გაუშვით:

```bash
dotnet ef database update
```

ეს ბაზაში გაუშვებს არსებულ მიგრაციებს, ხოლო დავალებაში მოცემული მონაცემები ბაზაში ავტომატურად ჩაიწერება (seed).

### 6. შედეგი

აპლიკაციის გაშვების შემდეგ ხელმისაწვდომი იქნება Swagger (REST) და `/graphql` endpoint-ი.
