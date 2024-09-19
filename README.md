# CSharp_CourseControl_Project

## Overview
The **CSharp_CourseControl_Project** is a course and student management application developed in C# with the primary goal of improving programming skills in an academic setting. The application is simple and offers features such as student and course registration, enrollment, deletion, and listing, all through an interactive command-line menu. The project is continuously evolving, with new functionalities being implemented and refined as development progresses.

## Features
- **Student Registration**: Allows the insertion of new students with unique ID validation.
- **Course Registration**: Enables the creation of new courses, including course code, name, description with a character limit, and price.
- **Student Enrollment**: Allows students to enroll in existing courses and also provides the option to withdraw students from courses.
- **Student and Course Deletion**: Facilitates the removal of students or courses from the system.
- **Report Generation**: Produces reports listing students, courses, and enrollments.

## Project Structure
- **Program.cs**: The main file that manages the lists of students and courses and handles the program’s execution.
- **UserInteractions.cs**: Manages user interaction and navigates through the menus, controlling the main functionalities.
- **ValidationHelper.cs**: A helper class containing methods for generic validations, such as unique ID checks and character limit validation.
- **Student.cs**: The student model, containing properties and methods for registering and managing students.
- **Course.cs**: The course model, containing properties and methods for registering and managing courses, as well as enrolling and unenrolling students.

## Technologies Used
- **C# 8.0**: The primary programming language.
- **.NET 8.0**: The framework used for development.
- **Visual Studio Code**: The chosen development environment.

## How to Run
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/CSharp_CourseControl_Project.git
   ```
2. **Build and Run**:
   - Open the project in Visual Studio Code.
   - Build the project:
     ```bash
     dotnet build
     ```
   - Run the project:
     ```bash
     dotnet run
     ```

3. **Navigate the Menus**:
   - Follow the instructions in the terminal to register students, courses, and use the other features.

## Testing and Verification
- **Navigation Testing**: All menus and submenus have been tested to ensure correct redirection.
- **Validations**: Unique IDs and character limits are verified to ensure data integrity.
- **Registration and Enrollment Testing**: Functionalities for registering and enrolling students have been tested, including student withdrawal from courses.

## Future Improvements
- **Data Persistence**: Integration with a database to store students and courses.
- **Detailed Reports**: Expanding the reporting functionality.
- **Graphical Interface**: Implementing a more user-friendly graphical interface.

## Contributions
Contributions are welcome! Feel free to open issues or submit pull requests.

## License
This project is licensed under the terms of the MIT license.
