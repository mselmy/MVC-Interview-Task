# MVC Interview Task

## Introduction
This task is designed to measure the technical skills required to develop a web application based on the MVC pattern. The goal is to create a web page to add students with their main information and subjects, making it easy for an admin to update or make changes to the subjects.

## Task Details

### Adding Student Page
The page will allow the addition of a student with the following fields:
- **Name**
- **Date of Birth**
- **Address**
- **Subjects**

The page will also include a Grid View containing all added students, with options to edit or delete them.

### Edit Page
When the user clicks "edit" on any student in the Grid View, the system should navigate to another page displaying the user's information. The user will have the ability to change any information or update the subjects by checking or unchecking the respective subjects.

## Project Setup

### Prerequisites
- .NET SDK
- Visual Studio or Visual Studio Code

### Getting Started

1. **Clone the repository**
   ```sh
   git clone <repository_url>
   cd <repository_name>
    ```
2. **Build and run the project**
    ```sh
    dotnet build
    dotnet run
    ```
### Project Structure
    - **Controllers**: Handles the HTTP requests and responses.
    - **Models**: Contains the data models and validation logic.
    - **Views**: Contains the Razor views for the UI.
    - **Services**: Contains business logic and service implementations.
**Usage**
- **Add a new student**: Click on the "Add Student" button and fill in the required fields.
- **Edit a student**: Click on the "Edit" button in the Grid View and update the student's information.
- **Delete a student**: Click on the "Delete" button in the Grid View to remove the student from the list.

### Technologies Used
- ASP.NET Core MVC
- JavaScript
- HTML/CSS
- Static Lists for Data Storage
