# Smart Farming App — Backend

This repository contains the **backend** for the Smart Farming App. It manages the server-side logic, database interactions, and integrates with Firebase for admin functionalities.

A smart farming application designed to manage agricultural parcels with features such as:
- **Crop Tracking**: Monitor crops and record growth stages.
- **Task Logging**: Keep track of daily farming tasks.
- **Observations & Reminders**: Note down field observations and set reminders.
- **Photo Organization (Before/After)**: Compare images taken at different times.
- **Shared Profiles for Collaborative Work**: Multiple users can access and contribute.
- **PDF Export for Subsidies**: Export parcel data in PDF format for documentation.
- **Flexible Inputs**: Accommodate unpredictable farming needs.

---

## Prerequisites

1. **MSSQL Server** (running instance) or ensure you have **PostgreSQL** if you prefer Postgres.
2. **.NET SDK 8.0**
3. **Docker** installed and configured on your machine.

---

## Installation

1. **Start PostgreSQL in Docker** (example command for a local Postgres database):
    ```bash
    docker run -e POSTGRES_USER=docker \
               -e POSTGRES_PASSWORD=docker \
               -e POSTGRES_DB=docker \
               -p 5432:5432 \
               library/postgres
    ```
2. **Check/Update the connection string** in your `appsettings.json` file:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=docker;Username=docker;Password=docker"
    }
    ```
    Make sure the details match your local or containerized PostgreSQL instance.

---

## Database Migrations

After confirming the connection string:

1. Open a terminal in the project root directory.
2. Run the following command to apply any existing migrations and create/update the database:
    ```bash
    dotnet ef database update
    ```
   (If needed, you can create a new migration by using `dotnet ef migrations add <MigrationName>`.)

---

## Firebase Admin Setup

1. Go to the **Firebase console** for your project.
2. Under **Project Settings** -> **Service accounts**, generate a private key for the admin SDK.
3. Download the JSON file and **rename it** to `firebaseServiceAcc.json`.
4. Place this file in the **root directory** of the project. 

> **Important**: The file must be named exactly `firebaseServiceAcc.json` and placed correctly; otherwise, the Firebase admin functionalities (e.g., authentication, notifications) will not work.

---

## Running the Application

1. Ensure your database is running (in Docker or your local server).
2. Ensure `firebaseServiceAcc.json` is in the root folder.
3. Run the application:
    ```bash
    dotnet run
    ```
4. The application should now be listening on the configured ports (default: `https://localhost:7209`).

---

## Swagger

You can explore and test the API endpoints using Swagger UI:
- **Swagger URL**: [https://localhost:7209/swagger/index.html](https://localhost:7209/swagger/index.html)
