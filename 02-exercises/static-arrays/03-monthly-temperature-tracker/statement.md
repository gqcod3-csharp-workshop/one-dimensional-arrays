# Exercise 03: Monthly Temperature Tracker

## Problem Statement

<p align="justify">
Design an application that registers daily temperatures for a 31-day month in a one-dimensional array. The system must generate random temperature data, perform statistical analysis, search for specific temperatures, and display their positions in the array.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Generates and stores 31 random daily temperatures in an array
2. Calculates and displays the average temperature for the month
3. Counts and displays how many days had temperatures above the average
4. Searches for a specific temperature entered by the user
5. Displays all positions where the searched temperature is found
6. Implements a `TemperaturaMes` class with search and analysis methods

## Input Specifications

- **Input 1**: Random temperature generation for 31 days (between -10°C and 45°C)
- **Input 2**: `searchTemp` (double) - Specific temperature to search for in the array

### Constraints
- Array size is fixed at 31 elements (one month)
- Temperature range: -10.0°C to 45.0°C
- Search temperature must be within valid range

## Output Specifications

- **Output**: A comprehensive report containing:
  - All 31 daily temperatures
  - Monthly average temperature
  - Count of days above average
  - Search results with positions (if found) or "not found" message

## Example Test Cases

### Test Case 1: Basic Analysis
**Input:**
```
temperatures = [22.5, 25.3, 23.1, 26.8, 24.2, 27.5, 28.3, 29.1, 26.5, 25.8,
                24.6, 23.9, 22.7, 21.5, 20.8, 22.3, 24.1, 25.6, 27.2, 28.5,
                30.1, 29.3, 28.7, 27.4, 26.1, 25.5, 24.8, 23.6, 22.9, 21.7, 20.5]
searchTemp = 25.5
```

**Output:**
```
Average Temperature: 25.13°C
Days Above Average: 16
Search Result: Temperature 25.5°C found at position 25
```

**Explanation:**
- Sum of all temperatures = 779.0
- Average = 779.0 / 31 = 25.13°C
- 16 days have temperatures > 25.13°C
- Temperature 25.5 appears at index 25

### Test Case 2: Temperature Not Found
**Input:**
```
temperatures = [15.2, 18.5, 20.1, 22.3, 24.5, 26.7, 28.9, 30.2, 31.5, 32.1,
                30.8, 29.5, 28.2, 27.1, 26.3, 25.8, 24.9, 23.7, 22.6, 21.4,
                20.3, 19.2, 18.5, 17.8, 16.9, 15.7, 14.8, 13.9, 12.5, 11.8, 10.9]
searchTemp = 35.0
```

**Output:**
```
Average Temperature: 22.65°C
Days Above Average: 14
Search Result: Temperature 35.0°C not found
```

**Explanation:**
- Average = 702.1 / 31 = 22.65°C
- 14 days exceed the average
- 35.0°C doesn't exist in the array

### Test Case 3: Multiple Occurrences
**Input:**
```
temperatures = [20.0, 22.5, 20.0, 24.1, 20.0, 26.3, 28.5, 30.1, 29.7, 28.3,
                27.5, 26.8, 25.5, 24.2, 23.1, 22.5, 21.8, 20.9, 19.7, 18.5,
                17.2, 16.8, 15.9, 14.5, 13.8, 12.9, 11.5, 10.8, 9.5, 8.2, 7.5]
searchTemp = 20.0
```

**Output:**
```
Average Temperature: 20.18°C
Days Above Average: 13
Search Result: Temperature 20.0°C found at positions: 0, 2, 4
```

**Explanation:**
- Temperature 20.0 appears three times
- Found at indices 0, 2, and 4

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Array Population**: Generating and storing random data
- **Statistical Analysis**: Computing averages and comparisons
- **Linear Search**: Finding specific values in an array
- **Index Tracking**: Recording all positions where a value appears
- **Object-Oriented Design**: Encapsulating logic in a dedicated class

## Approach & Hints

### Step 1: Create the TemperaturaMes Class

<p align="justify">
Design a class that manages temperature data with methods for generation, analysis, and searching.
</p>

**Class Structure:**
- Field: `double[] temperatures` for 31 daily temperatures
- Method: `GenerateRandomTemperatures()` - fills array with random values
- Method: `CalculateAverage()` - computes mean temperature
- Method: `CountAboveAverage()` - counts days exceeding average
- Method: `SearchTemperature(double temp)` - finds all occurrences
- Method: `DisplayReport()` - shows comprehensive analysis

### Step 2: Random Temperature Generation

<p align="justify">
Use the Random class to generate realistic temperature values within a valid range.
</p>

```csharp
Random random = new Random();
for (int i = 0; i < temperatures.Length; i++)
{
    temperatures[i] = random.NextDouble() * 55 - 10; // Range: -10 to 45
}
```

### Step 3: Search Implementation

<p align="justify">
Implement a linear search that stores all matching indices and returns them as a list or array.
</p>

```csharp
public int[] SearchTemperature(double targetTemp)
{
    List<int> positions = new List<int>();
    for (int i = 0; i < temperatures.Length; i++)
    {
        if (Math.Abs(temperatures[i] - targetTemp) < 0.01) // Compare with tolerance
        {
            positions.Add(i);
        }
    }
    return positions.ToArray();
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
namespace Exercise03.MonthlyTemperatureTracker
{
    public class TemperaturaMes
    {
        private double[] temperatures;
        private const int DaysInMonth = 31;
        
        public TemperaturaMes()
        {
            temperatures = new double[DaysInMonth];
        }
        
        public void GenerateRandomTemperatures()
        {
            // Generate random temperatures between -10 and 45
        }
        
        public void DisplayTemperatures()
        {
            // Show all temperatures
        }
        
        public double CalculateAverage()
        {
            // Return average temperature
        }
        
        public int CountAboveAverage()
        {
            // Count days above average
        }
        
        public int[] SearchTemperature(double targetTemp)
        {
            // Return array of positions where temp is found
        }
        
        public void DisplayReport()
        {
            // Show comprehensive analysis
        }
    }
    
    class Program
    {
        static void Main()
        {
            TemperaturaMes month = new TemperaturaMes();
            month.GenerateRandomTemperatures();
            month.DisplayReport();
            
            // Search functionality
            Console.Write("Enter temperature to search: ");
            double searchTemp = double.Parse(Console.ReadLine());
            int[] positions = month.SearchTemperature(searchTemp);
            // Display results
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: O(n) - Where n is 31 (days in month). Search and analysis operations iterate once.
- **Space Complexity**: O(n) - Storage for 31 temperatures plus dynamic list for search results.

---

*Good luck with your implementation!*
