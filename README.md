# Hotel Booking API – Backend Service

This project is a RESTful API for a hotel booking system, built with ASP.NET Core following a clean 3-layer architecture.
It provides authentication, booking management, and email notification features for a complete hotel reservation workflow.

---

## Overview

The API is designed to support mobile and web applications by providing secure and scalable endpoints for managing hotels, rooms, and bookings.
It follows best practices in backend development, including separation of concerns, authentication, and structured data handling.

---

## Features

* User authentication and authorization (JWT-based)
* CRUD operations for hotels, rooms, and bookings
* Booking management and status tracking
* Email notifications for booking confirmation
* RESTful API design with clean endpoints
* Input validation and error handling

---

## Architecture

The project follows a **3-Layer Architecture**:

```id="3z8wop"
Presentation Layer (Controllers)
    ↓
Business Logic Layer (Services)
    ↓
Data Access Layer (Repositories / Database)
```

### Description

* **Presentation Layer**: Handles HTTP requests and responses (Controllers)
* **Business Layer**: Contains business logic and processing rules
* **Data Layer**: Manages database operations and data persistence

---

## Tech Stack

* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQL Server / MySQL
* JWT Authentication
* SMTP (Email Service)

---

## API Modules

* Authentication (Register, Login, JWT)
* Hotels Management
* Rooms Management
* Booking Management
* User Management

---

## Example Endpoints

```http id="cptqmb"
POST   /api/auth/login
POST   /api/auth/register

GET    /api/hotels
POST   /api/hotels
PUT    /api/hotels/{id}
DELETE /api/hotels/{id}

POST   /api/bookings
GET    /api/bookings/{userId}
```

---

## Getting Started

### Prerequisites

* .NET SDK 8
* SQL Server or MySQL
* SMTP email configuration

### Installation

```bash id="p9fcln"
git clone
cd hotel-booking-api
dotnet restore
dotnet run
```

---

## Configuration

Update `appsettings.json`:

```json id="j0n0xr"
{
  "ConnectionStrings": {
    "DefaultConnection": "your_database_connection"
  },
  "Jwt": {
    "Key": "your_secret_key"
  },
  "Email": {
    "Host": "smtp.example.com",
    "Email": "your_email",
    "Password": "your_password"
  }
}
```

---

## Future Improvements

* Payment integration (VNPay, Stripe)
* Role-based authorization (Admin/User)
* Booking cancellation and refund system
* API rate limiting and caching
* Docker deployment

---

## Author

Nguyen Van Giang

---

## License

This project is for educational and portfolio purposes.
