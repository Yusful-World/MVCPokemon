# Pok�mon Application

A simple Pok�mon management web application built with ASP.NET Core MVC. 

## Features a Pokemon Gallery that allows;
- Adding a New Pok�mon with an image.  
- Editing and Deleting Pok�mon Details including image updates.  
- Dynamic Image Handling service with image validation, upload and deletion.  

## Technologies Used  
- ASP.NET Core MVC  
- Entity Framework Core (EF Core) 
- SQL Server (Database) 
- Bootstrap for UI styling  
- JavaScript Fetch API for AJAX-based deletion  
- Toastr Notification for success/error notifications  

---

## Getting Started  

### Clone the Repository  
```sh
git clone <https://github.com/Yusful-World/MVCPokemon>
cd <your-project-folder>
dotnet ef database update
dotnet run 
<http://localhost:5000>