# 🎓 CSharp Course Control Project

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet) ![C#](https://img.shields.io/badge/C%23-Modern-green) ![Status](https://img.shields.io/badge/Status-Completed-brightgreen)

## 📌 Overview

The **CSharp Course Control Project** is a simple **course and student management system** developed in C# as part of learning the language and programming concepts. It operates via an **interactive menu in the terminal**, allowing operations such as registration, enrollment, listing, and deletion of students and courses.

## 🚀 Features

✔ **Student Registration** (with unique ID validation)  
✔ **Course Registration** (name, code, description limit, and price)  
✔ **Student Enrollment & Removal**  
✔ **Course & Student Deletion**  
✔ **Enrollment Reports Generation**  

---

## 📁 Project Structure

```
📦 CSharp_CourseControl_Project
 ┣ 📜 Program.cs                // Manages program execution
 ┣ 📜 UserInteractions.cs        // Handles menus and user interactions
 ┣ 📜 ValidationHelper.cs        // Helper methods for validation
 ┣ 📜 Student.cs                 // Student model
 ┗ 📜 Course.cs                  // Course model
```

---

## 🛠 Technologies Used

- **Language**: [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- **Framework**: [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **IDE**: [Visual Studio Code](https://code.visualstudio.com/)

---

## ▶ How to Run

1️⃣ **Clone the Repository**  
```bash
git clone https://github.com/wilksonccp/CSharp_CourseControl_Project.git
cd CSharp_CourseControl_Project
```

2️⃣ **Build and Run**  
```bash
dotnet build
dotnet run
```

3️⃣ **Use the System**  
- Follow the terminal instructions to navigate through the interactive menus.

---

## ✅ Manual Testing

| Test                        | Input                     | Expected Output           | Status |
|-----------------------------|---------------------------|---------------------------|--------|
| Create Student              | John, ID: 123             | Successful Registration ✅ | ✅      |
| Create Course               | C# Advanced, ID: 001      | Course Created ✅         | ✅      |
| Enroll Student in Course    | John (ID: 123) -> C# Adv. | Enrollment Successful ✅  | ✅      |
| Delete Nonexistent Course   | ID: 999                   | Error: Course Not Found ❌ | ✅      |

---

## 🔮 Future Improvements

✅ **Data Persistence** - Database integration  
✅ **Graphical Interface** - Improved user experience  
✅ **Detailed Reports** - More comprehensive insights  

---

## 🏆 Contributing

Contributions are welcome! Feel free to open an **issue** or submit a **pull request**. Feedback is greatly appreciated.  

📌 **License:** [MIT License](LICENSE)  
