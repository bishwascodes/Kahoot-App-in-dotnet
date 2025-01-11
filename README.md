# Kahoot App in .NET

This project is a .NET implementation of a Kahoot-like application, developed as the final project for my **Object-Oriented Programming (OOP)** class. It showcases my understanding of core OOP principles, software design patterns, and practical programming skills. By building this project, I gained hands-on experience in creating scalable, modular, and maintainable software systems while working with .NET technologies.

---

## Learning Highlights

Through this project, I strengthened my understanding of:

### 1. **Object-Oriented Programming Principles**
- **Encapsulation**: Modularized code into reusable classes and kept implementation details private to ensure flexibility.
- **Inheritance**: Leveraged inheritance to create a structured hierarchy of classes, reducing redundancy.
- **Polymorphism**: Designed flexible and reusable methods that could be overridden to adapt to different quiz scenarios.
- **Abstraction**: Focused on essential functionality by creating abstract classes and interfaces.

### 2. **Design Patterns**
- **Singleton**: Implemented singleton patterns for managing shared resources like database connections.
- **Factory**: Used factory patterns for dynamically creating quiz question types.
- **Observer**: Developed a notification system to handle real-time updates for participants.

### 3. **Layered Architecture**
- **Separation of Concerns**: Divided the application into logical layers:
  - **Presentation Layer**: A web-based user interface built for intuitive interactions.
  - **Business Logic Layer**: Encapsulated the core functionalities such as quiz creation, score tracking, and hosting logic.
  - **Data Access Layer**: Handled database interactions and ensured data persistence.

### 4. **.NET Framework and Tools**
- **Entity Framework Core**: Used for managing database operations and handling relationships between quiz models.
- **ASP.NET Core**: Built a robust and responsive web application.
- **Dependency Injection**: Applied DI to manage service lifetimes and dependencies effectively.
- **LINQ**: Utilized LINQ for efficient querying and data manipulation.

### 5. **Version Control and Collaboration**
- **Git and GitHub**: Practiced version control by committing iterative changes and managing pull requests.
- **Agile Methodology**: Simulated iterative development cycles to plan, build, and refine features.

### 6. Test-Driven Development (TDD)

- **Unit Testing**: Followed a test-first approach to ensure individual components behaved as expected before implementation.
- **Integration Testing**: Developed integration tests to validate the interaction between modules, ensuring end-to-end functionality.
- **Mocking**: Utilized mocking frameworks to simulate dependencies for isolated testing.
- **Refactoring with Confidence**: Leveraged tests to refactor and optimize code without fear of introducing regressions.

### 7. **Problem-Solving and Debugging**
- Tackled challenges such as real-time synchronization, user input validation, and state management using strategic debugging techniques and rigorous testing.

---

## Project Features

### Quiz Management
- Create custom quizzes with different question types (e.g., multiple-choice, true/false).
- Define time limits and points for each question.

### Hosting and Participation
- Host quizzes in real time and generate unique game codes.
- Enable participants to join quizzes using the game code and submit answers.

### Real-Time Feedback
- Display scores and leaderboards after each question.
- Provide immediate feedback to participants.

### Persistent Data Storage
- Save quizzes, user data, and results for analysis and future access.

---
## Project Structure
- kahoot-app.ConsoleUI: Console interface for hosting and participating in quizzes.
- kahoot-app.Logic: Business logic and core functionalities.
- kahoot-app.Persistence: Data access layer for storing quizzes and user data.
- kahoot-app.Tests: Unit tests ensuring application reliability.
- kahoot-app.WebUI: Web interface for a user-friendly experience.
---
## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

---
## License

This project is licensed under the MIT License. See the LICENSE file for details.

---
## Acknowledgements

This project is inspired by Kahoot!, a game-based learning platform.
---
## Technical Setup

### Prerequisites
- .NET SDK 6.0 or higher
- Visual Studio 2022 or any compatible IDE

### Steps to Run the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/bishwascodes/Kahoot-App-in-dotnet.git
   ```
2. Navigate to the project directory:
   ```bash
   cd Kahoot-App-in-dotnet
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the solution:
   ```bash
   dotnet build
   ```
5. Run the application:
   ```bash
   dotnet run --project kahoot-app.WebUI
   ```
6. Access the app in your browser at `https://localhost:5001`.

---

## Future Improvements

This project has been a valuable learning experience. Here are some potential enhancements I am considering:
- **Mobile App Integration**: Develop a cross-platform mobile app using .NET MAUI.
- **Advanced Analytics**: Add detailed performance analytics for hosts and participants.
- **AI-Powered Question Suggestions**: Leverage AI models to suggest quiz questions based on historical data.

---

## About Me
I am passionate about building innovative software solutions and continuously honing my skills as a software engineer. This project demonstrates my ability to apply theoretical concepts to real-world applications, and I am excited to bring this mindset to future challenges.

For more projects and updates, visit my [GitHub profile](https://github.com/bishwascodes).

