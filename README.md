# ABChat — Cybersecurity Awareness Bot

A Windows Forms Cybersecurity Awareness Chatbot built in C# with MySQL 
database integration. ABChat educates users on cybersecurity topics through 
an interactive GUI featuring a chat interface, task assistant, mini quiz, 
NLP simulation, and activity logging.

---

## Features

-  **Chat** — Keyword-based cybersecurity advice with sentiment detection
-  **Task Assistant** — Add, complete, and delete tasks stored in MySQL
-  **Quiz Game** — 16 questions (MCQ + True/False) with score feedback
-  **NLP Simulation** — Natural language commands via chat input
-  **Activity Log** — Timestamped record of all bot actions
-  **Voice Greeting** — Text-to-speech welcome on startup

---

## Technologies Used

| Technology | Purpose |
|---|---|
| C# / .NET Framework 4.7.2 | Primary language |
| Windows Forms | GUI framework |
| MySQL 8.0 | Task and log storage |
| MySql.Data NuGet | MySQL connector |
| System.Speech | Voice greeting |

---

## Setup and Installation

**1. Clone the repository**
```bash

```

**2. Install MySql.Data NuGet package**
- Right-click project → Manage NuGet Packages → Browse → `MySql.Data` → Install

**3. Run this SQL in MySQL Workbench**
```sql
CREATE DATABASE IF NOT EXISTS abchat_db;
USE abchat_db;

CREATE TABLE IF NOT EXISTS tasks (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    title         VARCHAR(200) NOT NULL,
    description   TEXT,
    reminder_date DATE NULL,
    is_completed  TINYINT(1) DEFAULT 0,
    created_at    DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS activity_log (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    action    VARCHAR(500) NOT NULL,
    logged_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

**4. Update connection string in `DatabaseManager.cs`**
```csharp
private const string ConnStr =
    "Server=localhost;Database=abchat_db;Uid=root;Pwd=YourPasswordHere;";
```

**5. Build and run**
- Press `Ctrl+Shift+B` to build then `F5` to run

---

## NLP Chat Commands

| Type this | What happens |
|---|---|
| `add task Enable 2FA` | Creates a new task |
| `remind me to update password` | Sets a reminder task |
| `show my tasks` | Lists tasks in chat |
| `start quiz` | Starts the quiz game |
| `show activity log` | Shows recent actions |
| `topics` / `help` | Lists all chat topics |
| `bye` / `quit` | Ends the session |

---

## Project Structure
AchatBox2/

├── Program.cs            # Entry point

├── ChatForm.cs           # Main GUI and logic

├── ChatForm.Designer.cs  # Form control declarations

├── ResponseEngine.cs     # NLP, keywords, sentiment

├── QuizEngine.cs         # Quiz questions and scoring

├── DatabaseManager.cs    # MySQL database operations

├── VoiceGreeting.cs      # Text-to-speech greeting

├── ConsoleUI.cs          # Console helper (Part 1/2)

└── ChatBot.cs            # Console bot runner (Part 1/2)

---

## Author

**LISHIVHA ANGAHO VENUS**  
---
*ABChat — Making your security as easy as ABC*
