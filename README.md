# taskflowv1
TaskFlow using angular as fronend
Here is a simple but practical full-stack problem statement that touches on all the key areas you mentioned. It's designed to be a complete, self-contained project for practice.

### Project Name: **TaskFlow - A Personal Task Manager**

**Problem Statement:**

Users need a simple, intuitive web application to manage their daily to-do lists. Current solutions are often cluttered with features. There is a need for a clean, fast, and responsive application that allows users to quickly add, view, update, and delete their tasks, helping them stay organized and productive.

---

### Technical Scope & Requirements

This project will allow you to practice the following skills:

#### **1. Backend (.NET Core Web API & SQL)**
*   **Entity Framework Core:** Code-First Database Design.
*   **CRUD Operations:** Create, Read, Update, Delete endpoints for a `Task` entity.
*   **Database:** SQL Server (or SQLite for simpler setup).
*   **Model/Entity:**
    *   `Id` (int, Primary Key)
    *   `Title` (string, required)
    *   `Description` (string, optional)
    *   `IsCompleted` (bool, default: false)
    *   `DueDate` (DateTime?, optional)
    *   `Priority` (enum: Low, Medium, High - optional)
*   **API Endpoints:**
    *   `GET /api/tasks` - Get all tasks. Add optional query parameters for filtering (e.g., `?isCompleted=false`).
    *   `GET /api/tasks/{id}` - Get a specific task by ID.
    *   `POST /api/tasks` - Create a new task.
    *   `PUT /api/tasks/{id}` - Update an existing task.
    *   `DELETE /api/tasks/{id}` - Delete a task.
*   **Data Transfer Objects (DTOs):** Use separate DTOs for requests and responses to decouple the API layer from the entity model.
*   **Dependency Injection:** Inject the DbContext and any services into the Controller.

#### **2. Database (SQL)**
*   Design a single `Tasks` table based on the entity model above.
*   Practice writing migrations using EF Core.

#### **3. Frontend (Angular *or* React - Choose one to practice)**
*   **Component Structure:**
    *   `TaskListComponent`: Displays a list of all tasks.
    *   `TaskItemComponent`: Displays a single task (a card or a row in a list).
    *   `AddTaskComponent`: A form for adding a new task.
    *   `EditTaskComponent`: A form/modals for editing an existing task (can reuse the Add form).
*   **Services:** Create an Angular Service/React Hook or Context to handle all HTTP calls to the backend API (using `HttpClient` in Angular or `fetch`/`axios` in React).
*   **State Management:** Manage the application's state (the list of tasks). In React, you can use the `useState` and `useEffect` hooks. In Angular, you can use a Service with RxJS `BehaviorSubject` or `Signal` for a more advanced practice.
*   **User Interface:**
    *   A clean, modern UI.
    *   Checkboxes to mark tasks as complete/incomplete (should update via API).
    *   Buttons for Edit and Delete with confirmation for delete.
    *   Visual indicators for priority (e.g., color-coded labels) and overdue tasks.
*   **Routing (Bonus):** Implement routing for different views (e.g., `/all-tasks`, `/completed-tasks`).

#### **4. Bonus Features (To stretch your skills further)**
*   **Backend:**
    *   Add sorting to the `GET /api/tasks` endpoint (e.g., sort by `DueDate` or `Priority`).
    *   Add server-side validation using Data Annotations or FluentValidation.
    *   Implement Global Error Handling and return standardized API responses.
    *   Add logging (e.g., using Serilog or ILogger).
*   **Frontend:**
    *   Add a search/filter bar to filter tasks by title.
    *   Implement a "bulk delete" for completed tasks.
    *   Add a confirmation dialog before deleting a task.
    *   Make the UI responsive for mobile devices.
*   **Full-Stack:**
    *   **CORS:** Configure Cross-Origin Resource Sharing (CORS) on your .NET API to allow requests from your frontend development server (e.g., `localhost:4200` for Angular, `localhost:3000` for React).

---

### Why this is a good practice project:

*   **End-to-End:** It covers the entire development lifecycle from database design to UI.
*   **Fundamental CRUD:** It reinforces the most common pattern in web development.
*   **Modern Practices:** It encourages the use of DTOs, Dependency Injection, Component-Based Architecture, and State Management.
*   **Scalable Complexity:** You can start with the basic CRUD and gradually add the bonus features one by one, making it as simple or as challenging as you want.

This should provide a solid foundation for you to practice and demonstrate your full-stack .NET capabilities. Good luck

**Project Structure**
TaskFlow/
├── Backend/ (ASP.NET Core Web API)
│   ├── Controllers/
│   ├── Data/
│   ├── DTOs/
│   ├── Models/
│   ├── Migrations/
│   └── Program.cs
├── Frontend/ (Angular)
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/
│   │   │   ├── services/
│   │   │   ├── models/
│   │   │   └── app.module.ts
│   │   └── styles.css
└── README.md

**Setup Instructions**
**Backend Setup:**
1)Create a new ASP.NET Core Web API project
2)Add the Entity Framework Core packages:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

3)Add the CORS middleware as shown in the Program.cs
4)Run the migrations:
dotnet ef migrations add InitialCreate
dotnet ef database update

5)Run the API project

**Frontend Setup:**
1)Create a new Angular project:
ng new taskflow-frontend
cd taskflow-frontend

2)Replace the generated files with the provided code
3)Install Angular Material (optional for enhanced UI):
ng add @angular/material
4)Update the API URL in task.service.ts if needed

5)Run the Angular app:
ng serve

This implementation provides a complete full-stack solution with all the CRUD operations, filtering, and a clean UI. The backend uses SQLite for simplicity, but you can easily switch to SQL Server by updating the connection string and adding the appropriate NuGet packages.
