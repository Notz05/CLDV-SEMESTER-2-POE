### **ST10272691**
### **ABC Retail Management - Part 3 POE (CLDV6212)**

## **Project Overview**

This project, part of the CLDV6212 module, involves creating an Azure SQL database solution for ABC Retail.

## **Technologies Used**

- **Azure SQL Database:** For storing customer, product, and order data.
- **Azure SQL Database Replication:** To replicate the database in another Azure region for better reliability and fault tolerance.
- **Microsoft Visual Studio:** For developing, managing code, and deploying the application.
- **SQL Server Management Studio (SSMS):** For managing and querying the Azure SQL Database directly.
- **Azure Portal:** For managing Azure resources and monitoring the database.

## **Project Structure**

The project includes the following main components:

1. **Database Schema:** The Azure SQL database contains tables for customers, products, and orders.
2. **SQL Queries:** Scripts to create the database schema, insert initial data, and manage operations.
3. **Database Replication:** The database is replicated to another Azure region for fault tolerance and better performance.
4. **Web Application:** Interacts with the Azure SQL database to manage products and customers.
5. **GitHub Repository:** Contains all source code, SQL scripts, and project documentation.

## **Deployment Instructions**

### **1. Set Up Azure SQL Database**

Steps to set up the Azure SQL Database:

1. **Create an Azure SQL Database** in the Azure Portal.
2. **Define the database schema**:
    - Create the necessary tables:
    ```sql
    -- Create Customers Table
    CREATE TABLE Customers (
        CustomerID INT PRIMARY KEY IDENTITY(1,1),
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Phone NVARCHAR(15),
        Address NVARCHAR(200),
        City NVARCHAR(50),
        State NVARCHAR(50),
        PostalCode NVARCHAR(10),
        Country NVARCHAR(50)
    );

    -- Create Products Table
    CREATE TABLE Products (
        ProductID INT PRIMARY KEY IDENTITY(1,1),
        ProductName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(500),
        Price DECIMAL(10, 2) NOT NULL,
        Stock INT NOT NULL,
        Category NVARCHAR(50),
        DateAdded DATETIME DEFAULT GETDATE()
    );

    -- Create Orders Table
    CREATE TABLE Orders (
        OrderID INT PRIMARY KEY IDENTITY(1,1),
        CustomerID INT NOT NULL,
        OrderDate DATETIME DEFAULT GETDATE(),
        TotalAmount DECIMAL(10, 2) NOT NULL,
        Status NVARCHAR(50) DEFAULT 'Pending',
        FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
    );

    -- Create OrderItems Table
    CREATE TABLE OrderItems (
        OrderItemID INT PRIMARY KEY IDENTITY(1,1),
        OrderID INT NOT NULL,
        ProductID INT NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(10, 2) NOT NULL,
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
        FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
    );
    ```

### **2. Set Up Azure SQL Database Replication**

Steps to set up replication in another region:

1. **Navigate to the Azure SQL Database instance** in the Azure Portal.
2. **Set up geo-replication**:
    - Choose a target region for replication.
    - Follow the steps in the Azure Portal to enable geo-replication.

### **3. Connect Web Application to Azure SQL Database**

Configure your web application to connect to the Azure SQL database:

1. Update the **connection string** in your application’s configuration files to point to your Azure SQL Database.
2. Test the connection by running the application locally or deploying it to Azure.

### **4. Deploy the Web Application**

Use **Visual Studio** to deploy the web application to Azure App Service. This ensures the application can interact with the database in Azure.

## **Motivation for Database Replication**

Replicating the database to another region is important for:

1. **Disaster Recovery:** Ensuring data safety and availability in case of a regional failure.
2. **Improved Performance:** Reducing latency by serving requests from the closest region to the user.
3. **High Availability:** Increasing database availability, ensuring the application remains operational even if one region faces issues.

## **How to Run Locally**

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/abc-retail-management.git
    ```
2. Open the solution in **Visual Studio**.
3. Ensure the **connection string** in `appsettings.json` is correctly set to your Azure SQL Database.
4. Press **F5** to run the application locally.
