# MCP Showcase in C#

This repository demonstrates a basic implementation of a Model Context Protocol (MCP) server in C#.

## Features
- Add Todo items
- Retrieve Todo items

## Getting Started
1. Clone the repository.
2. Build and run the project using .NET 8 or higher.

## Prerequisites
- .NET 8 or higher installed on your system.
- A Windows operating system (tested on Windows).

## Usage

### Running the MCP Server
1. Open a terminal in the project directory.
2. Build the project using the following command:
   ```
   dotnet build
   ```
3. Run the project:
   ```
   dotnet run
   ```

### Using the Tools

#### Add a Todo Item
You can add a new Todo item using the `AddTodoItem` tool. Example:
```csharp
TodoTools.AddTodoItem(todoService, "Buy groceries");
```

#### Retrieve Todo Items
Retrieve all Todo items using the `GetTodoItems` tool. Example:
```csharp
var items = TodoTools.GetTodoItems(todoService);
```

## Project Structure
- `Program.cs`: Contains the main entry point and service configuration.
- `TodoService`: Implements the `ITodoService` interface for managing Todo items.
- `TodoTools`: Provides tools for adding and retrieving Todo items.

## Additional Information
This project uses the Model Context Protocol (MCP) to define and expose tools for interacting with the Todo service.