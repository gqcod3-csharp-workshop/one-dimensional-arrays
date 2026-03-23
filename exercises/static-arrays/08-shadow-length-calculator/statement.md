# Exercise 08: Shadow Length Calculator

## Problem Statement

<p align="justify">
Design a program that calculates the length of shadows cast by objects of various heights at different sun angles. The program uses trigonometric functions, stores multiple measurements in arrays, and implements proper error handling for invalid angles.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Stores object heights in a one-dimensional array
2. Accepts sun angle (angle of elevation) in degrees
3. Calculates shadow length using trigonometric formulas
4. Implements error handling for invalid angles (0° and 90°)
5. Processes multiple objects and stores results
6. Displays results in a formatted table

## Input Specifications

- **Input 1**: `heights` (array of double) - Heights of objects in meters
- **Input 2**: `sunAngle` (double) - Sun's angle of elevation in degrees

### Constraints
- Object heights: positive numbers (> 0)
- Sun angle: 0° < angle < 90° (exclusive)
- Invalid angles must throw appropriate exceptions
- Heights and results in meters (m), angles in degrees (°)

## Output Specifications

- **Output**: Formatted table containing:
  - Object height (meters)
  - Sun angle (degrees)
  - Calculated shadow length (meters)
  - All values rounded to 2 decimal places

## Example Test Cases

### Test Case 1: Multiple Objects at 45°
**Input:**
```
heights = [2.0, 5.5, 10.0, 15.0, 3.2]
sunAngle = 45.0
```

**Output:**
```
=== Shadow Length Calculation ===

Sun Angle: 45.00°

Object Height (m) | Shadow Length (m)
----------------------------------------
      2.00        |      2.00
      5.50        |      5.50
     10.00        |     10.00
     15.00        |     15.00
      3.20        |      3.20
```

**Explanation:**
- At 45°, tan(45°) = 1
- Shadow length = height / tan(45°) = height / 1 = height
- All shadows equal the object heights

### Test Case 2: Low Sun Angle (Long Shadows)
**Input:**
```
heights = [1.5, 3.0, 6.0]
sunAngle = 30.0
```

**Output:**
```
=== Shadow Length Calculation ===

Sun Angle: 30.00°

Object Height (m) | Shadow Length (m)
----------------------------------------
      1.50        |      2.60
      3.00        |      5.20
      6.00        |     10.39
```

**Explanation:**
- tan(30°) ≈ 0.577
- Shadow length = height / tan(30°)
- Lower sun angle creates longer shadows
- Example: 1.5 / 0.577 ≈ 2.60 meters

### Test Case 3: High Sun Angle (Short Shadows)
**Input:**
```
heights = [5.0, 8.0, 12.0]
sunAngle = 60.0
```

**Output:**
```
=== Shadow Length Calculation ===

Sun Angle: 60.00°

Object Height (m) | Shadow Length (m)
----------------------------------------
      5.00        |      2.89
      8.00        |      4.62
     12.00        |      6.93
```

**Explanation:**
- tan(60°) ≈ 1.732
- Shadow length = height / tan(60°)
- Higher sun angle creates shorter shadows
- Example: 5.0 / 1.732 ≈ 2.89 meters

### Test Case 4: Error Handling - Invalid Angle (90°)
**Input:**
```
heights = [3.0, 4.0]
sunAngle = 90.0
```

**Output:**
```
ERROR: Invalid sun angle!
Sun angle must be between 0° and 90° (exclusive).
At 90°, the sun is directly overhead and shadow length is zero.
```

**Explanation:**
- tan(90°) is undefined (approaches infinity)
- Would cause division by infinity
- Must throw ArgumentException

### Test Case 5: Error Handling - Invalid Angle (0°)
**Input:**
```
heights = [2.0]
sunAngle = 0.0
```

**Output:**
```
ERROR: Invalid sun angle!
Sun angle must be between 0° and 90° (exclusive).
At 0°, the sun is at the horizon and shadow length is infinite.
```

**Explanation:**
- tan(0°) = 0
- Would cause division by zero
- Must throw ArgumentException

## Key Concepts

<p align="justify">
This exercise reinforces understanding of:
</p>

- **Trigonometry**: Tangent function and angle relationships
- **Degree/Radian Conversion**: Math library uses radians
- **Array Processing**: Iterating and storing calculated results
- **Error Handling**: Try-catch blocks and exceptions
- **Input Validation**: Checking angle constraints
- **Mathematical Modeling**: Real-world physics application
- **Formatted Output**: Table display with alignment

## Approach & Hints

### Step 1: Trigonometric Formula

<p align="justify">
The relationship between object height, shadow length, and sun angle is based on right triangle trigonometry. Understanding this formula is essential for the calculation.
</p>

```
tan(θ) = height / shadowLength

Therefore:
shadowLength = height / tan(θ)
```

Where θ is the sun's angle of elevation.

### Step 2: Degree to Radian Conversion

<p align="justify">
C#'s Math.Tan() function expects angles in radians, not degrees. You must convert the input angle before using trigonometric functions.
</p>

```csharp
double DegreesToRadians(double degrees)
{
    return degrees * (Math.PI / 180.0);
}
```

### Step 3: Shadow Calculation with Validation

<p align="justify">
Implement the shadow length calculation with proper angle validation. Invalid angles (0° and 90°) must throw appropriate exceptions to prevent mathematical errors.
</p>

```csharp
double CalculateShadowLength(double height, double sunAngleDegrees)
{
    // Validate angle
    if (sunAngleDegrees <= 0 || sunAngleDegrees >= 90)
    {
        throw new ArgumentException(
            "Sun angle must be between 0° and 90° (exclusive).");
    }
    
    // Convert to radians
    double angleRadians = DegreesToRadians(sunAngleDegrees);
    
    // Calculate shadow length
    double tanAngle = Math.Tan(angleRadians);
    double shadowLength = height / tanAngle;
    
    return shadowLength;
}
```

### Step 4: Processing Multiple Objects

<p align="justify">
Create a method to process all objects at once, storing results in a parallel array that can be displayed together.
</p>

```csharp
double[] CalculateAllShadows(double[] heights, double sunAngle)
{
    double[] shadows = new double[heights.Length];
    
    for (int i = 0; i < heights.Length; i++)
    {
        shadows[i] = CalculateShadowLength(heights[i], sunAngle);
    }
    
    return shadows;
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise08.ShadowLengthCalculator
{
    public class ShadowCalculator
    {
        private double[] heights;
        private double sunAngle;
        
        public ShadowCalculator(double[] heights, double sunAngle)
        {
            this.heights = heights;
            this.sunAngle = sunAngle;
        }
        
        private double DegreesToRadians(double degrees) { /* implementation */ }
        public double CalculateShadowLength(double height) { /* implementation */ }
        public double[] CalculateAllShadows() { /* implementation */ }
        public void DisplayResults() { /* implementation */ }
    }
    
    class Program
    {
        static void Main()
        {
            try
            {
                // Get user input for heights and sun angle
                // Create ShadowCalculator instance
                // Display results
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - O(n) where n is the number of objects
  - Single pass through heights array
  - Each calculation is O(1)
- **Space Complexity**: O(n) - for storing shadow results array

---

*Good luck with your implementation!*
