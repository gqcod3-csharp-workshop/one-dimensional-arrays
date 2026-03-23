# Exercise 01: Product Inventory Manager

## Problem Statement

<p align="justify">
Design a class `Inventario` that manages a dynamic list of `Producto` objects using List<T>. Each product has an ID, name, and stock quantity. Implement methods to add products, search by ID, and maintain sorted order automatically.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Creates a `Producto` class with properties: ID, Name, and Stock
2. Implements an `Inventario` class that manages a `List<Producto>`
3. Provides a method to add new products dynamically
4. Automatically maintains sorted order by ID when displaying
5. Implements a search method to find products by their ID
6. Displays all products in sorted order

## Input Specifications

- **Input 1**: Product details (ID, Name, Stock) to be added to inventory
- **Input 2**: `searchID` (integer) - Product ID to search for

### Constraints
- Product ID must be unique and positive
- List grows dynamically as products are added (no fixed capacity)
- Products displayed in sorted order by ID
- Stock quantity must be non-negative

## Output Specifications

- **Output**: Multiple operations:
  - Confirmation of product addition
  - Display of all products (sorted by ID)
  - Search results showing product details or "not found" message

## Example Test Cases

### Test Case 1: Adding and Searching Products
**Input:**
```
Add: Product(105, "Laptop", 15)
Add: Product(102, "Mouse", 50)
Add: Product(108, "Keyboard", 30)
Add: Product(101, "Monitor", 20)
Search: 102
```

**Output:**
```
Products Added Successfully

Current Inventory (sorted by ID):
ID: 101, Name: Monitor, Stock: 20
ID: 102, Name: Mouse, Stock: 50
ID: 105, Name: Laptop, Stock: 15
ID: 108, Name: Keyboard, Stock: 30

Search Result for ID 102:
Product Found - ID: 102, Name: Mouse, Stock: 50
```

**Explanation:**
- Products added in random order
- Array automatically sorted by ID after each insertion
- Search successfully finds product with ID 102

### Test Case 2: Product Not Found
**Input:**
```
Add: Product(201, "Tablet", 25)
Add: Product(203, "Speaker", 40)
Add: Product(205, "Webcam", 18)
Search: 204
```

**Output:**
```
Products Added Successfully

Current Inventory (sorted by ID):
ID: 201, Name: Tablet, Stock: 25
ID: 203, Name: Speaker, Stock: 40
ID: 205, Name: Webcam, Stock: 18

Search Result for ID 204:
Product Not Found
```

**Explanation:**
- ID 204 doesn't exist in inventory
- Array remains sorted

### Test Case 3: Binary Search Efficiency Test
**Input:**
```
Add: Product(10, "Item A", 100)
Add: Product(20, "Item B", 200)
Add: Product(30, "Item C", 300)
Add: Product(40, "Item D", 400)
Add: Product(50, "Item E", 500)
Search: 30
```

**Output:**
```
Products Added Successfully

Current Inventory (sorted by ID):
ID: 10, Name: Item A, Stock: 100
ID: 20, Name: Item B, Stock: 200
ID: 30, Name: Item C, Stock: 300
ID: 40, Name: Item D, Stock: 400
ID: 50, Name: Item E, Stock: 500

Search Result for ID 30:
Product Found - ID: 30, Name: Item C, Stock: 300
(Found using Binary Search in sorted array)
```

**Explanation:**
- Sorted array enables efficient binary search
- Search complexity: O(log n)

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Object-Oriented Programming**: Creating and managing custom objects
- **Dynamic Lists**: Using List<T> for flexible collection management
- **LINQ for Searching**: Using LINQ methods for efficient queries
- **Automatic Sorting**: Sorting lists when needed for display
- **Encapsulation**: Managing internal list state

## Approach & Hints

### Step 1: Create the Producto Class

<p align="justify">
Define a simple class to represent product data with appropriate properties.
</p>

```csharp
public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int Stock { get; set; }
    
    public Producto(int id, string nombre, int stock)
    {
        ID = id;
        Nombre = nombre;
        Stock = stock;
    }
    
    public override string ToString()
    {
        return $"ID: {ID}, Name: {Nombre}, Stock: {Stock}";
    }
}
```

### Step 2: Add Products to List

<p align="justify">
Simply add products to the List<T> using the Add() method. List automatically manages capacity.
</p>

```csharp
public void AgregarProducto(Producto nuevoProducto)
{
    // Check for duplicate ID
    if (productos.Any(p => p.ID == nuevoProducto.ID))
    {
        Console.WriteLine("Error: Product ID already exists");
        return;
    }
    
    // Add to list - no manual capacity management needed!
    productos.Add(nuevoProducto);
}
```

### Step 3: Search Using LINQ

<p align="justify">
Use LINQ's FirstOrDefault method for clean, readable searching.
</p>

```csharp
public Producto BuscarPorID(int id)
{
    return productos.FirstOrDefault(p => p.ID == id);
}
```

### Step 4: Display Sorted

<p align="justify">
Use LINQ's OrderBy to sort when displaying, keeping the original list order flexible.
</p>

```csharp
public void MostrarInventario()
{
    var productosOrdenados = productos.OrderBy(p => p.ID);
    
    foreach (var producto in productosOrdenados)
    {
        Console.WriteLine(producto);
    }
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System.Collections.Generic;
using System.Linq;

namespace Exercise01.ProductInventoryManager
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        
        public Producto(int id, string nombre, int stock)
        {
            ID = id;
            Nombre = nombre;
            Stock = stock;
        }
        
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Nombre}, Stock: {Stock}";
        }
    }
    
    public class Inventario
    {
        private List<Producto> productos;
        
        public Inventario()
        {
            productos = new List<Producto>();
        }
        
        public void AgregarProducto(Producto producto)
        {
            // Check for duplicates and add
        }
        
        public Producto BuscarPorID(int id)
        {
            // Use LINQ FirstOrDefault
        }
        
        public void MostrarInventario()
        {
            // Display sorted by ID using OrderBy
        }
        
        public int ObtenerCantidad()
        {
            return productos.Count;
        }
    }
    
    class Program
    {
        static void Main()
        {
            Inventario inv = new Inventario();
            inv.AgregarProducto(new Producto(105, "Laptop", 15));
            inv.AgregarProducto(new Producto(102, "Mouse", 50));
            inv.MostrarInventario();
            
            Producto found = inv.BuscarPorID(102);
            if (found != null)
                Console.WriteLine($"Found: {found}");
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - Insertion: O(1) - List.Add is amortized constant time
  - Search: O(n) - Linear search with LINQ (or O(log n) with binary search if sorted)
  - Display Sorted: O(n log n) - LINQ OrderBy uses quicksort
- **Space Complexity**: O(n) - Dynamic list grows as needed

---

*Good luck with your implementation!*
