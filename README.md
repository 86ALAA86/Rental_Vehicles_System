Here’s a clean, professional README you can drop directly into your repository. It matches your project structure and explains the system clearly for anyone who visits your GitHub page.

---

# Rental Vehicles System

A multi‑layered .NET application designed to manage vehicle rentals through a clean separation of concerns. The system is organized into three main layers: **Data Access**, **Business Logic**, and **Presentation**, following a standard enterprise architecture pattern.

---

### 📁 Project Structure

```
Rental_Vehicles_System/
│   Rental_Vehicles_System.sln
│
├── DataAccessLayer
│   Handles database operations, entity models, and data persistence.
│
├── BusinessLayer
│   Contains business rules, validation logic, and service classes.
│
└── PresentationLayer
    User interface layer responsible for interacting with the end user.
```

Each layer is isolated to ensure maintainability, scalability, and easier testing.

---

### 🎯 Features

- Vehicle registration and management  
- Customer information handling  
- Rental operations (create, update, return)  
- Layered architecture for clean separation of responsibilities  
- Reusable business logic and centralized data access  

---

### 🛠️ Technologies Used

- **C# / .NET Framework**
- **Windows Forms** or **WPF** (Using Guna UI 2)
- **SQL Server**
- **Entity Framework / ADO.NET**

---

### 🚀 How to Run the Project

1. Clone the repository:
   ```
   git clone https://github.com/86ALAA86/Rental_Vehicles_System.git
   ```

2. Open the solution file:
   ```
   Rental_Vehicles_System.sln
   ```

3. Restore dependencies (if needed).

4. Set the **PresentationLayer** as the startup project.

5. Build and run the application.

---

### 📦 Architecture Overview

- **DataAccessLayer**  
  Contains repositories, database context, and entity models. Responsible for all communication with the database.

- **BusinessLayer**  
  Implements business rules, validation, and application logic. Acts as a bridge between the UI and the data layer.

- **PresentationLayer**  
  Provides the user interface. Calls the business layer to perform operations and display results.

---

### 📌 Status

The project is **complete** and currently not under active development.

---

### 📄 License

This project is open-source. You may modify or use it as needed.

---

