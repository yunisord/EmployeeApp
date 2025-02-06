# EmployeeApp

This is an Employee Management App that allows you to add, view, and delete employees.

## Requirements

Before you can run the application, ensure you have the following installed:

- [Git](https://git-scm.com/)
- [Node.js](https://nodejs.org/)
- [VS Code](https://code.visualstudio.com/) (optional but recommended)
- [.NET 7.0](https://dotnet.microsoft.com/) (for the backend)

## Step-by-Step Instructions

### 1. Clone the Repository
Clone the repository to your local machine using Git.

git clone https://github.com/yunisord/EmployeeApp.git

2. Navigate to the Project Directory
Move into the project directory.

cd EmployeeApp

3. Set Up Backend
The backend is built using .NET. You need to set it up and run it.

a) Install Dependencies
Make sure you have all the required dependencies installed.

dotnet restore

b) Run the Backend
Run the backend server.

dotnet run

The backend should now be running, typically on http://localhost:5058.

4. Set Up Frontend
The frontend of the application is built using plain HTML, CSS, and JavaScript.

a) Open the index.html File
Navigate to the folder where index.html is located and open it in your browser.

b) Access Employee Management UI
You can view and interact with the employee management interface at:

Employee Management UI: http://localhost:5058/ui/index.html
This will allow you to add, view, and manage employee data directly from the browser.

5. API Access
The backend API is accessible for programmatic access at:

Employee Data API: http://localhost:5058/api/employee
This API endpoint allows you to retrieve, add, update, and delete employee records programmatically. It's primarily intended for integration or use in other applications, but it’s also what the frontend uses to display and manage employee data.

6. Test the Application
Once both the frontend and backend are running:

Open the frontend at http://localhost:5058/ui/index.html to interact with the employee management system.
You can also check employee data directly via the backend API at http://localhost:5058/api/employee.

7. Additional Notes
API Requests: The app interacts with the backend API to perform actions like adding, updating, and deleting employees.
