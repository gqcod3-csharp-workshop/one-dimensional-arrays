# Exercise 02: Export Data Analyzer

## Problem Statement

<p align="justify">
Design a program that imports and analyzes export data from a CSV file using List<T> to store product records. Implement LINQ queries to calculate country totals, identify leading products, filter by region, and compute statistical aggregations.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Creates a `ProductoExportacion` class with properties: Country, Region, Product, Year, Amount, Weight
2. Reads data from a CSV file and stores it in a `List<ProductoExportacion>`
3. Calculates total export amount grouped by country
4. Identifies the product with highest revenue in 2024
5. Counts products exported annually in North America region
6. Computes average weight for Central America region

## Input Specifications

- **Input 1**: CSV file path containing export data
- **Input 2**: CSV file with columns: Pais, Region, Producto, Año, Monto, Peso

### Constraints
- CSV file must have header row (skip when reading)
- List grows dynamically based on file size (no fixed capacity)
- All monetary values use `decimal` type for precision
- Year values are integers (YYYY format)
- Weight values are in metric tons (double type)

## Output Specifications

- **Output**: Comprehensive analysis report containing:
  - Total export amounts by country (sorted descending)
  - Leading product by revenue for 2024
  - Annual product count for North America
  - Average weight for Central America products

## Example Test Cases

### Test Case 1: Complete Regional Analysis
**Input:**
```
CSV File: ProductosExportacion.csv
Pais,Region,Producto,Año,Monto,Peso
México,Norteamérica,Electrónicos,2024,150000,45.5
Estados Unidos,Norteamérica,Textiles,2024,200000,120.0
Canadá,Norteamérica,Alimentos,2023,180000,300.0
Guatemala,Centroamérica,Café,2024,80000,50.0
Costa Rica,Centroamérica,Frutas,2024,95000,75.0
México,Norteamérica,Automotriz,2024,300000,500.0
Panamá,Centroamérica,Banano,2023,60000,100.0
```

**Output:**
```
=== Export Data Analysis ===

Loaded Records: 7

==================================================
1. Total Export Amount by Country:
==================================================
   México               $450,000.00
   Estados Unidos       $200,000.00
   Canadá               $180,000.00
   Costa Rica           $95,000.00
   Guatemala            $80,000.00
   Panamá               $60,000.00

==================================================
2. Leading Product in 2024 (by Revenue):
==================================================
   Product: Automotriz
   Total Amount: $300,000.00

==================================================
3. Annual Product Count in North America:
==================================================
   2024: 3 product(s)
   2023: 1 product(s)

==================================================
4. Average Weight in Central America:
==================================================
   Average: 75.00 metric tons
   Total products: 3
```

**Explanation:**
- México appears twice (150,000 + 300,000 = 450,000 total)
- Automotriz has highest single product revenue in 2024
- North America had 3 exports in 2024, 1 in 2023
- Central America average: (50 + 75 + 100) / 3 = 75 MT

### Test Case 2: Product Revenue Aggregation
**Input:**
```
CSV File:
Pais,Region,Producto,Año,Monto,Peso
México,Norteamérica,Café,2024,50000,30.0
Colombia,Sudamérica,Café,2024,80000,45.0
Guatemala,Centroamérica,Café,2024,40000,25.0
Brasil,Sudamérica,Café,2024,120000,60.0
Costa Rica,Centroamérica,Textiles,2024,30000,20.0
```

**Output:**
```
=== Export Data Analysis ===

Loaded Records: 5

==================================================
1. Total Export Amount by Country:
==================================================
   Brasil               $120,000.00
   Colombia             $80,000.00
   México               $50,000.00
   Guatemala            $40,000.00
   Costa Rica           $30,000.00

==================================================
2. Leading Product in 2024 (by Revenue):
==================================================
   Product: Café
   Total Amount: $290,000.00

==================================================
3. Annual Product Count in North America:
==================================================
   2024: 1 product(s)

==================================================
4. Average Weight in Central America:
==================================================
   Average: 22.50 metric tons
   Total products: 2
```

**Explanation:**
- Café aggregated across all countries: 50k + 80k + 40k + 120k = 290k
- Only México in North America with 1 product
- Central America average: (25 + 20) / 2 = 22.50 MT

### Test Case 3: No Data for Specific Query
**Input:**
```
CSV File:
Pais,Region,Producto,Año,Monto,Peso
Argentina,Sudamérica,Vino,2023,100000,150.0
Chile,Sudamérica,Cobre,2023,250000,500.0
```

**Output:**
```
=== Export Data Analysis ===

Loaded Records: 2

==================================================
1. Total Export Amount by Country:
==================================================
   Chile                $250,000.00
   Argentina            $100,000.00

==================================================
2. Leading Product in 2024 (by Revenue):
==================================================
   No data available for 2024

==================================================
3. Annual Product Count in North America:
==================================================
   (No products found in North America)

==================================================
4. Average Weight in Central America:
==================================================
   No data available for Central America
```

**Explanation:**
- No products from 2024 (all are 2023)
- No North America or Central America data
- System handles empty result sets gracefully

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Dynamic Collections**: Using List<T> for unknown data size from files
- **File I/O**: Reading CSV files with StreamReader
- **LINQ Queries**: GroupBy, Where, Select, Sum, Average, Count, OrderBy
- **Data Aggregation**: Grouping and summing by different criteria
- **Object Mapping**: Converting CSV rows to objects
- **Error Handling**: Managing file access and parsing errors

## Approach & Hints

### Step 1: Create the Data Model Class

<p align="justify">
Define a class to represent each export record with appropriate data types.
</p>

```csharp
public class ProductoExportacion
{
    public string Pais { get; set; }
    public string Region { get; set; }
    public string Producto { get; set; }
    public int Año { get; set; }
    public decimal Monto { get; set; }
    public double Peso { get; set; }
    
    public ProductoExportacion(string pais, string region, string producto, 
                               int año, decimal monto, double peso)
    {
        Pais = pais;
        Region = region;
        Producto = producto;
        Año = año;
        Monto = monto;
        Peso = peso;
    }
}
```

### Step 2: Read CSV File into List

<p align="justify">
Use StreamReader to parse CSV and populate a dynamic List. Handle the header row and parse each field to the correct type.
</p>

```csharp
static List<ProductoExportacion> CargarDatosDesdeCSV(string filePath)
{
    List<ProductoExportacion> productos = new List<ProductoExportacion>();
    
    using (StreamReader sr = new StreamReader(filePath))
    {
        string line = sr.ReadLine(); // Skip header
        
        while ((line = sr.ReadLine()) != null)
        {
            string[] values = line.Split(',');
            
            productos.Add(new ProductoExportacion(
                values[0].Trim(),                    // Pais
                values[1].Trim(),                    // Region
                values[2].Trim(),                    // Producto
                int.Parse(values[3].Trim()),         // Año
                decimal.Parse(values[4].Trim()),     // Monto
                double.Parse(values[5].Trim())       // Peso
            ));
        }
    }
    
    return productos;
}
```

### Step 3: Total by Country (LINQ GroupBy)

<p align="justify">
Use LINQ to group products by country, sum the amounts, and sort in descending order.
</p>

```csharp
static void MostrarTotalPorPais(List<ProductoExportacion> productos)
{
    var totalesPorPais = productos
        .GroupBy(p => p.Pais)
        .Select(g => new
        {
            Pais = g.Key,
            Total = g.Sum(p => p.Monto)
        })
        .OrderByDescending(x => x.Total);
    
    foreach (var item in totalesPorPais)
    {
        Console.WriteLine($"   {item.Pais,-20} ${item.Total:N2}");
    }
}
```

### Step 4: Leading Product in 2024

<p align="justify">
Filter by year 2024, group by product, sum revenues, and get the top one.
</p>

```csharp
static void MostrarProductoLider2024(List<ProductoExportacion> productos)
{
    var productoLider = productos
        .Where(p => p.Año == 2024)
        .GroupBy(p => p.Producto)
        .Select(g => new
        {
            Producto = g.Key,
            Total = g.Sum(p => p.Monto)
        })
        .OrderByDescending(x => x.Total)
        .FirstOrDefault();
    
    if (productoLider != null)
    {
        Console.WriteLine($"   Product: {productoLider.Producto}");
        Console.WriteLine($"   Total Amount: ${productoLider.Total:N2}");
    }
}
```

### Step 5: Annual Count in North America

<p align="justify">
Filter by region, group by year, and count products in each year.
</p>

```csharp
static void MostrarConteoNorteamerica(List<ProductoExportacion> productos)
{
    var conteoPorAño = productos
        .Where(p => p.Region == "Norteamérica")
        .GroupBy(p => p.Año)
        .Select(g => new
        {
            Año = g.Key,
            Cantidad = g.Count()
        })
        .OrderBy(x => x.Año);
    
    foreach (var item in conteoPorAño)
    {
        Console.WriteLine($"   {item.Año}: {item.Cantidad} product(s)");
    }
}
```

### Step 6: Average Weight in Central America

<p align="justify">
Filter by Central America region and calculate the average weight using LINQ.
</p>

```csharp
static void MostrarPromedioCentroamerica(List<ProductoExportacion> productos)
{
    var productosCentro = productos
        .Where(p => p.Region == "Centroamérica")
        .ToList();
    
    if (productosCentro.Count > 0)
    {
        double promedio = productosCentro.Average(p => p.Peso);
        Console.WriteLine($"   Average: {promedio:F2} metric tons");
        Console.WriteLine($"   Total products: {productosCentro.Count}");
    }
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise02.ExportDataAnalyzer
{
    public class ProductoExportacion
    {
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Producto { get; set; }
        public int Año { get; set; }
        public decimal Monto { get; set; }
        public double Peso { get; set; }
        
        public ProductoExportacion(string pais, string region, string producto,
                                   int año, decimal monto, double peso)
        {
            Pais = pais;
            Region = region;
            Producto = producto;
            Año = año;
            Monto = monto;
            Peso = peso;
        }
    }
    
    class Program
    {
        static void Main()
        {
            // Load data from CSV or use sample data
            List<ProductoExportacion> productos = GenerarDatosMuestra();
            
            // Perform analysis
            MostrarTotalPorPais(productos);
            MostrarProductoLider2024(productos);
            MostrarConteoNorteamerica(productos);
            MostrarPromedioCentroamerica(productos);
        }
        
        static List<ProductoExportacion> CargarDatosDesdeCSV(string filePath)
        {
            // Read CSV file
        }
        
        static void MostrarTotalPorPais(List<ProductoExportacion> productos)
        {
            // Group by country and sum
        }
        
        static void MostrarProductoLider2024(List<ProductoExportacion> productos)
        {
            // Filter 2024, group by product, find max
        }
        
        static void MostrarConteoNorteamerica(List<ProductoExportacion> productos)
        {
            // Filter region, group by year, count
        }
        
        static void MostrarPromedioCentroamerica(List<ProductoExportacion> productos)
        {
            // Filter region, calculate average
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - File Reading: O(n) - Single pass through CSV
  - GroupBy Operations: O(n) - Each LINQ query scans the list
  - Sorting: O(m log m) - Where m is number of groups
  - Overall: O(n log n) - Dominated by sorting operations
- **Space Complexity**: O(n) - Storing all records in List plus grouped results

---

*Good luck with your implementation!*
