# Photo Studio Management System
**Team Members**  
* Shweta Chaudhary: Student ID: 8874947  
* Merlin George: Student ID: 8989980  
* Shilpa Gopi: Student ID: 8893284  
* Bala Subramaniyam Venugopal Raja: Student ID: 8892816

## Project Description
We have decided to build a desktop application to streamline and enhance the operations of a photo studio. The primary purpose of the Photo Studio Management System is to simplify and automate the administrative tasks involved in running a photo studio to improve productivity and the client experience in general. It will provide studio employees with a centralized solution for tracking appointments, managing client details, and handling invoices and other critical features into one platform, freeing them up to concentrate more on creative work and less on administrative duties. 

__MAIN PAGES__   
* Sign In/Sign Up Page: Secure user authentication and registration.  
* Customer Dashboard: Personalized dashboard for customers to view and manage their appointments and services.  
* Admin Dashboard: Administrative interface for managing studio operations, client details, and financial records.  

## Installation Guidelines
**PREREQUISITES**
 
__* Operating System:__ Windows 10 or higher  
__* Development Environment:__ Visual Studio 2019 or higher  
__* .NET Framework:__ .NET 5.0 or higher  
__* Database:__ SQL Server 2019

**Steps to Install** 
 
 **1. Clone the Repository:**
Open a terminal and run the following command:
```bash
git clone https://github.com/Mgeorge9980/PROG8051-24S-Sec1-Group1_Project.git
```
**2. Open the Project in Visual Studio:**  
Launch Visual Studio and open the cloned repository.

**3. Database Connection**  
From the Server Explorer, click Connect Database and enter the server name and check the trust server certificate checkbox and enter the database name and ensure the test connection is successful.

**4. Install NuGet Packages:**  
* Right-click on the solution in the Solution Explorer, and then Click on the Manage NuGet Packages option. In the NuGet Package Manager window, Select the Browse tab, Search for System.Data.SqlClient and Press enter
* Select the first option, System.Data.SqlClient by Microsoft and Click on the install button to install the package..

**5. Update Database Connection String:** 
From the Server Explorer, click Connect Database and enter the server name and check the trust server certificate checkbox and enter the database name and ensure the test connection is successful.

```bash
 // Sample Connection string to your database
 string connectionString = "Server=MERLIN\\SQLEXPRESS19;Database=StudioManagement;User Id=sa;Password=Conestoga1;Trusted_Connection=True;";
```
**6. Build the Solution:**
Click on "Build" in the top menu and select "Build Solution".

**7. Run the Application:**
Press F5 or click on the "Start" button to run the application.


## Troubleshooting
** 1. NuGet Package Issues:** Ensure all required NuGet packages are installed. You can manually install missing packages via the NuGet Package Manager.  
** 2. Database Connection Issues:** Verify the connection string and ensure that SQL Server is running.
