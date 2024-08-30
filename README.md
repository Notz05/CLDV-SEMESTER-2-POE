# ABCRetailWebApp

**ABCRetailWebApp** is a web application designed for managing products, customer profiles, orders, and contracts in a retail environment. This application leverages Microsoft Azure services for cloud storage and data management.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Product Management**: Upload product images and manage product details.
- **Customer Profiles**: Add and manage customer profiles with personal information.
- **Order Processing**: Process customer orders with unique order IDs.
- **Contract Management**: Upload contracts and logs for tracking.

## Technologies Used

- **Frontend**:
  - HTML
  - CSS
  - JavaScript
  
- **Backend**:
  - ASP.NET Core
  - C#
  
- **Azure Services**:
  - Azure Blob Storage
  - Azure Table Storage
  - Azure Queue Storage
  - Azure File Storage

## Setup

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Account](https://azure.microsoft.com/en-us/free/)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the Repository**:

  https://github.com/Notz05/CLDV-SEMESTER-2-POE.git 

2. **Set Up Azure Services**:
   - Create Azure resources for Blob Storage, Table Storage, Queue Storage, and File Storage.
   - Update `appsettings.json` with your Azure connection strings.

3. **Restore NuGet Packages**:

  
   dotnet restore
   

4. **Build the Application**:

  
   dotnet build
  

5. **Run the Application**:

   dotnet run
  

   The application will be available at `https://localhost:5001` by default.

## Usage

- **Upload Product Image**: Navigate to the home page and use the "Upload Product Image" form to upload images.
- **Add Customer Profile**: Use the "Add Customer Profile" form to enter customer details.
- **Process Order**: Enter an order ID in the "Process Order" form to process an order.
- **Upload Contract or Log**: Use the "Upload Contract or Log" form to upload files.

## Contributing

Contributions are welcome! If you have suggestions or improvements, please follow these steps:

1. **Fork the Repository**.
2. **Create a New Branch**:
   
   git checkout -b feature/YourFeature
  
3. **Make Your Changes**.
4. **Commit Your Changes**:
   
   git commit -am 'Add new feature'
  
5. **Push to the Branch**:
   
   git push origin feature/YourFeature
  
6. **Create a Pull Request**.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

**Reference**
Mrzyglod, K. (2022). Azure for Developers 2nd Edition. In K. Mrzyglod, Azure for Developers (p. 944). Birmingham: Pakt Publishing Ltd.


