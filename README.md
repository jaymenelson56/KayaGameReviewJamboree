# Kaya Game Review Jamboree

A dog-themed game review platform where users can write game reviews, react with dog-face emotion images, and comment on each other's reviews.

## Features

- Create, edit, and delete game reviews
- Tag reviews with one of 9 dog-face emotion reactions
- Comment on reviews from other users
- User profiles (first name, last name, address)
- Cookie-based authentication with Admin role support

## Tech Stack

| Layer | Technology |
|-------|------------|
| Backend | .NET 8 / ASP.NET Core |
| ORM | Entity Framework Core 8 |
| Database | PostgreSQL |
| Auth | ASP.NET Identity (cookie-based) |
| Frontend | React 18 + Vite 5 |
| UI | Reactstrap / Bootstrap 5 |
| Testing | Cypress 14 |

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js + npm](https://nodejs.org/) (v18+ recommended)
- [PostgreSQL](https://www.postgresql.org/download/) running locally (or a remote instance)

## Running Locally

### Backend

1. Clone the repo and navigate to the project root.

2. Create `appsettings.Development.json` in the root (this file is gitignored):
   ```json
   {
     "KayaGameReviewJamboreeDbConnectionString": "Host=localhost;Port=5432;Username=YOUR_USER;Password=YOUR_PASSWORD;Database=KayaGameReviewJamboree",
     "AdminPassword": "YOUR_ADMIN_PASSWORD"
   }
   ```

3. Apply Entity Framework migrations to set up the database schema:
   ```bash
   dotnet ef database update
   ```

4. Start the API server:
   ```bash
   dotnet run
   ```
   The API runs at `https://localhost:5001`. Swagger UI is available at `https://localhost:5001/swagger` in development mode.

### Frontend

In a separate terminal:

```bash
cd client
npm install
npm run dev
```

The app opens at `http://localhost:5173`. API calls are proxied automatically to `https://localhost:5001/api`.

## Running Tests

Both the backend and frontend must be running before executing tests.

```bash
cd client
npx cypress open   # interactive GUI
npx cypress run    # headless
```

## Seeded Test Accounts

The database is seeded with the following test users:

| Username | Email | Role |
|----------|-------|------|
| JaymeChaka | jayme@chaka.comx | Admin |
| KayaGaba | kaya@gaba.comx | Admin |
| FoxGaba | fox@gaba.comx | Admin |
| BongoGaba | bongo@gaba.comx | — |
| JerryGaba | jerry@gaba.comx | — |
