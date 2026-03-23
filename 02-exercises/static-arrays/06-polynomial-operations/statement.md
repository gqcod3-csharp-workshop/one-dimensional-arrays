# Exercise 06: Polynomial Operations

## Problem Statement

<p align="justify">
Design a program that represents polynomials using one-dimensional arrays where each index represents the coefficient of that power. Implement operations to add two polynomials and display the result in standard mathematical notation.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Represents polynomials as arrays where index i contains the coefficient of x^i
2. Accepts two polynomials of potentially different degrees
3. Adds the two polynomials by summing corresponding coefficients
4. Handles polynomials of different lengths properly
5. Displays polynomials in standard mathematical notation (e.g., 3x² + 2x - 5)
6. Removes or handles zero coefficients appropriately in output

## Input Specifications

- **Input 1**: `poly1` (array of double) - Coefficients of first polynomial
- **Input 2**: `poly2` (array of double) - Coefficients of second polynomial

### Constraints
- Array indices represent powers (index 0 = constant term, index 1 = x term, etc.)
- Coefficients can be positive, negative, or zero
- Polynomials can have different degrees
- Maximum degree: 10 (arrays of length 0-10)

## Output Specifications

- **Output**: 
  - Display of both input polynomials in mathematical notation
  - Display of resulting sum polynomial
  - Proper handling of signs (+/-)
  - Omission of terms with zero coefficients
  - Proper formatting (e.g., "x²" not "x^2")

## Example Test Cases

### Test Case 1: Same Degree Polynomials
**Input:**
```
poly1 = [3, 2, 5]      // Represents: 3 + 2x + 5x²
poly2 = [1, -3, 2]     // Represents: 1 - 3x + 2x²
```

**Output:**
```
Polynomial 1: 5x² + 2x + 3
Polynomial 2: 2x² - 3x + 1

Sum Result: 7x² - x + 4
```

**Explanation:**
- Constant terms: 3 + 1 = 4
- x terms: 2 + (-3) = -1
- x² terms: 5 + 2 = 7
- Result: [4, -1, 7] → 7x² - x + 4

### Test Case 2: Different Degree Polynomials
**Input:**
```
poly1 = [2, 0, 3, 1]        // Represents: 2 + 3x² + x³
poly2 = [-5, 4, 1]          // Represents: -5 + 4x + x²
```

**Output:**
```
Polynomial 1: x³ + 3x² + 2
Polynomial 2: x² + 4x - 5

Sum Result: x³ + 4x² + 4x - 3
```

**Explanation:**
- poly2 is shorter, so x³ term comes only from poly1
- Constant: 2 + (-5) = -3
- x: 0 + 4 = 4
- x²: 3 + 1 = 4
- x³: 1 + 0 = 1

### Test Case 3: Zero Coefficient Handling
**Input:**
```
poly1 = [5, 3, -2, 4]       // Represents: 5 + 3x - 2x² + 4x³
poly2 = [-5, -3, 2, 0]      // Represents: -5 - 3x + 2x²
```

**Output:**
```
Polynomial 1: 4x³ - 2x² + 3x + 5
Polynomial 2: 2x² - 3x - 5

Sum Result: 4x³
```

**Explanation:**
- All lower degree terms cancel out to zero
- Only x³ term remains: 4
- Zero coefficients are not displayed

### Test Case 4: Single Term Polynomials
**Input:**
```
poly1 = [0, 0, 0, 7]        // Represents: 7x³
poly2 = [0, 0, 3]           // Represents: 3x²
```

**Output:**
```
Polynomial 1: 7x³
Polynomial 2: 3x²

Sum Result: 7x³ + 3x²
```

**Explanation:**
- Sparse polynomials with mostly zero coefficients
- Only non-zero terms are displayed

## Key Concepts

<p align="justify">
This exercise reinforces understanding of:
</p>

- **Array Representation**: Using index position to represent mathematical concepts
- **Array Traversal**: Iterating through arrays of different lengths
- **Mathematical Operations**: Polynomial addition
- **String Formatting**: Creating mathematical notation from arrays
- **Edge Cases**: Handling zero coefficients, different array sizes
- **Algorithm Design**: Combining arrays of different lengths

## Approach & Hints

### Step 1: Polynomial Addition Algorithm

<p align="justify">
Create a result array with size equal to the maximum of both polynomial lengths. Iterate through and add corresponding coefficients, treating missing coefficients as zero.
</p>

```csharp
double[] AddPolynomials(double[] poly1, double[] poly2)
{
    // Result array size is maximum of both lengths
    int maxLength = Math.Max(poly1.Length, poly2.Length);
    double[] result = new double[maxLength];
    
    // Add coefficients from both polynomials
    for (int i = 0; i < maxLength; i++)
    {
        double coef1 = (i < poly1.Length) ? poly1[i] : 0;
        double coef2 = (i < poly2.Length) ? poly2[i] : 0;
        result[i] = coef1 + coef2;
    }
    
    return result;
}
```

### Step 2: Display Polynomial in Mathematical Notation

<p align="justify">
Build the string representation by iterating from highest to lowest degree. Skip zero coefficients and handle signs, coefficient values, and variable notation appropriately.
</p>

```csharp
string PolynomialToString(double[] poly)
{
    List<string> terms = new List<string>();
    
    // Start from highest degree (end of array)
    for (int i = poly.Length - 1; i >= 0; i--)
    {
        double coef = poly[i];
        
        // Skip zero coefficients
        if (coef == 0) continue;
        
        string term = "";
        
        // Handle sign
        if (coef > 0 && terms.Count > 0)
            term += "+ ";
        else if (coef < 0)
            term += "- ";
        
        // Handle coefficient
        double absCoef = Math.Abs(coef);
        if (i == 0 || absCoef != 1)
            term += absCoef;
        
        // Handle variable and power
        if (i > 0)
        {
            term += "x";
            if (i > 1)
                term += GetSuperscript(i);
        }
        
        terms.Add(term);
    }
    
    return terms.Count > 0 ? string.Join(" ", terms) : "0";
}
```

### Step 3: Superscript Powers (Unicode)

<p align="justify">
Convert numeric powers to Unicode superscript characters for proper mathematical display. This handles powers beyond the basic x² notation.
</p>

```csharp
string GetSuperscript(int power)
{
    string[] superscripts = {"⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹"};
    string result = "";
    foreach (char digit in power.ToString())
    {
        result += superscripts[digit - '0'];
    }
    return result;
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise06.PolynomialOperations
{
    public class Polynomial
    {
        private double[] coefficients;
        
        public Polynomial(double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        
        public Polynomial Add(Polynomial other) { /* implementation */ }
        public override string ToString() { /* implementation */ }
        private string GetSuperscript(int power) { /* implementation */ }
    }
    
    class Program
    {
        static void Main()
        {
            // Get user input for two polynomials
            // Create Polynomial instances
            // Add and display results
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - Addition: O(max(n, m)) where n and m are lengths of input polynomials
  - Display: O(n) where n is the length of the polynomial
  - Overall: O(max(n, m))
- **Space Complexity**: O(max(n, m)) - for the result array and string building

---

*Good luck with your implementation!*
