# 📤 Data Upload Tool

## A desktop-based Data Upload Tool developed using C# (.NET Framework), Windows Forms, ADO.NET, and SQL Server. The application allows users to import Excel data, validate records, identify duplicate entries, and upload valid data into company-specific database tables.

## 📌 Features

- 📂 Browse and Import Excel Files
- 📊 Read Excel Data
- 📤 Upload Data into SQL Server
- ✅ Data Validation
- 🔍 Duplicate ACNo Checking
- 📱 Mobile Number Validation
- ⚠️ Invalid Data Detection
- 📝 Error Log Management
- 📋 Master Table Management
- 🏢 Company-wise Data Upload
- 📈 Upload Progress Tracking
- 🔄 Stored Procedure Based Data Processing

## 🛠️ Technologies Used

- C#
- Windows Forms
- .NET Framework
- ADO.NET
- SQL Server
- Excel
- Visual Studio

## 💾 Database

**Database:** `DataUploadDB`

The application uses SQL Server for storing uploaded data, validating records, maintaining error logs, and processing company-wise data.

## 📂 Project Modules

- Excel File Upload
- Data Validation
- Master Data Management
- Duplicate Record Checking
- Mobile Number Validation
- Error Log
- Company-wise Data Processing
- Data Upload Progress

## 🚀 How to Run

1. Clone the repository.
2. Open `DATA_UPLOAD_PROJECT.sln` in Visual Studio.
3. Restore or create the required SQL Server database.
4. Update the SQL Server connection string in `App.config`.
5. Create the required tables and stored procedures.
6. Build the solution.
7. Run the application.
8. Select an Excel file and upload the data.

## 🗄️ Database Processing

The application uses SQL Server stored procedures for data processing, including:

- Master table management
- Excel data insertion
- Data validation
- Company-wise data submission
- Error logging

## 👩‍💻 Author

**Payal Saroj**

GitHub: https://github.com/payalsaroj553-boop

⭐ If you like this project, don't forget to give it a Star.
