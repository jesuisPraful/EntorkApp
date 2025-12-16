# EntorkApp – Microservices Architecture

> Enterprise-grade microservices application built with **ASP.NET Core**, **Ocelot API Gateway**, and **Entity Framework Core**, following the **Database-per-Service** and **Repository** patterns.

---

## 🏗️ Architecture Overview

EntorkApp is designed using a **microservices architecture** consisting of **4 independent services**, each owning its own database.  
An **API Gateway (Ocelot)** acts as a single entry point for routing client requests to the appropriate services.

<img width="758" height="623" alt="image" src="https://github.com/user-attachments/assets/2a0829c3-2f4c-4db2-94ac-d4fa1c7d1bd5" />

---

---

## 📦 Project Structure

### Core Services
- **APIGateway** – Central API Gateway using Ocelot
- **BillWebServices** – Billing and invoicing operations
- **CustomerWebServices** – Customer profile and management
- **MeterReadingWebServices** – Meter reading and consumption tracking
- **PaymentWebServices** – Payment processing and transactions

### Data Access Layer (DAL)

Each service has a dedicated DAL project using **Entity Framework Core** and the **Repository Pattern**:

- **BillDAL**
- **CustomerDAL**
- **MeterReadingDAL**
- **PaymentDAL**

**DAL Benefits**
- Clear separation of concerns
- Reusable and testable data access logic
- Centralized database operations
- Consistent repository-based architecture

---

## 🛠️ Technology Stack

- **Backend:** ASP.NET Core, C#
- **API Gateway:** Ocelot
- **ORM:** Entity Framework Core
- **Database:** SQL Server (Database-per-Service)
- **Architecture:** Microservices
- **Design Pattern:** Repository Pattern

---

## ✨ Features

- 80+ RESTful APIs
- Independent service deployment
- Separate database per service
- Centralized API Gateway
- Horizontal scalability
- Clean separation of business and data layers

---

## 🚀 Getting Started

### Prerequisites
- .NET 6.0+
- SQL Server 2019+
- Visual Studio 2022 / VS Code
- Git

### Installation

#### 1. Clone Repository
```bash
git clone https://github.com/<your-github-username>/EntorkApp.git
cd EntorkApp
```

2. **Update Connection Strings**
   
   Update the connection strings in `appsettings.json` for each service:
   - BillWebServices
   - CustomerWebServices
   - MeterReadingWebServices
   - PaymentWebServices
```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=BillDB;Trusted_Connection=True;"
     }
   }
```
3. **Run Database Migrations**
   
   For each DAL project, run:
```bash
   dotnet ef database update
```

4. **Configure Ocelot**
   
   Update `ocelot.json` in the APIGateway project with your service endpoints.

5. **Build the Solution**
```bash
   dotnet build
```
3. **Run Database Migrations**
   
   For each DAL project, run:
```bash
   dotnet ef database update
```

4. **Configure Ocelot**
   
   Update `ocelot.json` in the APIGateway project with your service endpoints.

5. **Build the Solution**
```bash
   dotnet build
```
6. **Run Services**
   
   Start each service individually (recommended to use different ports):
```bash
   # Terminal 1 - Bill Service
   cd BillWebServices
   dotnet run --urls="https://localhost:5001"

   # Terminal 2 - Customer Service
   cd CustomerWebServices
   dotnet run --urls="https://localhost:5002"

   # Terminal 3 - Meter Reading Service
   cd MeterReadingWebServices
   dotnet run --urls="https://localhost:5003"

   # Terminal 4 - Payment Service
   cd PaymentWebServices
   dotnet run --urls="https://localhost:5004"

   # Terminal 5 - API Gateway
   cd APIGateway
   dotnet run --urls="https://localhost:5000"
```

## 📡 API Documentation

All APIs are accessible through the API Gateway at `https://localhost:5000`

### Service Endpoints

- **Bill Service**: `/api/bills/*`
- **Customer Service**: `/api/customers/*`
- **Meter Reading Service**: `/api/meter-readings/*`
- **Payment Service**: `/api/payments/*`

For detailed API documentation, access Swagger UI at:
- API Gateway: `https://localhost:5000/swagger`
- Individual Services: `https://localhost:500X/swagger`

## 🗄️ Database Schema

Each service maintains its own database following the Database-per-Service pattern:

- **BillDB** - Stores billing and invoice information
- **CustomerDB** - Stores customer profiles and details
- **MeterReadingDB** - Stores meter reading records
- **PaymentDB** - Stores payment transactions and history

### Data Access Layer Pattern

Each DAL project follows this structure:
```
BillDAL/
├── Data/
│   └── ApplicationDbContext.cs      # EF Core DbContext
├── Entities/
│   ├── Bill.cs                      # Domain entities
│   ├── Invoice.cs
│   └── BillItem.cs
├── Repositories/
│   ├── Interfaces/
│   │   └── IBillRepository.cs       # Repository contracts
│   └── Implementations/
│       └── BillRepository.cs        # Repository implementations
└── Migrations/                      # EF Core migrations
```

**Key Components:**

1. **DbContext**: Configures database connection and entity mappings
2. **Entities**: POCO classes representing database tables
3. **Repositories**: Abstraction layer for data operations (CRUD)
4. **Migrations**: Version control for database schema changes

**Repository Pattern Benefits:**
- Decouples business logic from data access
- Provides testability through interface abstraction
- Centralizes data access logic
- Enables easier switching of data sources

## 🔧 Configuration

### API Gateway (Ocelot)

The API Gateway configuration is located in `APIGateway/ocelot.json`. This file defines:
- Downstream services routes
- Load balancing strategies
- Rate limiting
- Authentication schemes
- Service discovery

### Service Configuration

Each service has its own `appsettings.json` with:
- Database connection strings
- Logging configuration
- CORS policies
- Authentication settings

## 🧪 Testing
```bash
# Run all tests
dotnet test

# Run tests for specific project
dotnet test BillWebServices.Tests
```

## 📈 Monitoring & Logging

- Application logging is configured in `appsettings.json`
- Logs are written to console and file system
- Consider implementing structured logging with Serilog
- Recommended to integrate health checks for each service

## 🔐 Security Considerations

- Implement JWT authentication in API Gateway
- Use HTTPS for all communications
- Secure connection strings using Azure Key Vault or similar
- Implement rate limiting and throttling
- Add input validation and sanitization

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- Your Name - Initial work

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Ocelot community for the API Gateway library
- Entity Framework Core team.

