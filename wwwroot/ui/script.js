// Define the API URL
const apiUrl = "http://localhost:5058/api/employee";

// Function to fetch all employees and display in the UI
async function getEmployees() {
    try {
        const response = await fetch(apiUrl);
        const employees = await response.json();
        console.log('Fetched Employees:', employees);  // Log the response to check the structure

        const employeeList = document.getElementById("employeeList");
        employeeList.innerHTML = ""; // Clear existing list

        if (employees.length > 0) {
            employees.forEach(employee => {
                displayEmployee(employee);
            });
        } else {
            employeeList.innerHTML = "<li>No employees found</li>";
        }
    } catch (error) {
        console.error("Error fetching employees:", error);
    }
}

// Function to display an employee in the list
function displayEmployee(employee) {
    const employeeList = document.getElementById("employeeList");
    const row = document.createElement("tr");

    row.innerHTML = `
        <td>${employee.id}</td>
        <td>${employee.name}</td>
        <td>${employee.position}</td>
        <td>${employee.salary.toFixed(2)}</td>
        <td>
            <button class="delete-btn" onclick="deleteEmployeeById(${employee.id})">Delete</button>
        </td>
    `;

    employeeList.appendChild(row);
}

// Function to add an employee
async function addEmployee(event) {
    event.preventDefault(); // Prevent page reload

    const name = document.getElementById("empName").value;
    const position = document.getElementById("empPosition").value;
    const salary = document.getElementById("empSalary").value;

    const newEmployee = {
        name: name,
        position: position,
        salary: parseFloat(salary)
    };

    console.log('Adding employee:', newEmployee);  // Log the new employee data

    try {
        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newEmployee)
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.statusText}`);
        }

        const addedEmployee = await response.json(); // Get the newly created employee
        displayEmployee(addedEmployee); // Add directly to the list

        document.getElementById("addEmployeeForm").reset(); // Clear form fields
    } catch (error) {
        console.error("Failed to add employee:", error);
    }
}

// Function to delete an employee
async function deleteEmployeeById(empId) {
    if (!confirm(`Are you sure you want to delete Employee ID ${empId}?`)) return;

    try {
        const response = await fetch(`${apiUrl}/${empId}`, { method: 'DELETE' });

        if (response.ok) {
            console.log(`✅ Successfully deleted Employee ID: ${empId}`);
            getEmployees(); // Refresh table
        } else {
            const errorMessage = await response.text();
            console.error(`❌ Failed to delete: ${errorMessage}`);
            alert(`Error deleting employee: ${errorMessage}`);
        }
    } catch (error) {
        console.error("❌ Failed to delete employee:", error);
    }
}


// Attach event listener to form
document.getElementById("addEmployeeForm").addEventListener("submit", addEmployee);

// Load employee list when the page loads
window.onload = getEmployees;
