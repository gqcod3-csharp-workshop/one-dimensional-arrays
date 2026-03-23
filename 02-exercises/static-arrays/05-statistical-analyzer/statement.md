# Exercise 05: Statistical Analyzer

## Problem Statement

<p align="justify">
Design a program that performs comprehensive statistical analysis on a dataset of numeric values stored in a one-dimensional array. The program must calculate mean, median, mode, variance, and standard deviation using mathematical formulas.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Stores a fixed dataset of numeric values in an array
2. Calculates the arithmetic mean (average)
3. Finds the median (middle value when sorted)
4. Determines the mode (most frequent value)
5. Computes the variance and standard deviation
6. Displays all statistical measures with appropriate formatting

## Input Specifications

- **Input**: `data` (array of double values) - Pre-defined dataset for analysis

### Constraints
- Array size: minimum 10 elements
- Values can be positive, negative, or zero
- Values can have decimal places
- Mode may have multiple values (multimodal) or none if all values are unique

## Output Specifications

- **Output**: Statistical report containing:
  - Mean (average value)
  - Median (middle value)
  - Mode (most frequent value(s))
  - Variance
  - Standard deviation
  - All values formatted to 2 decimal places

## Example Test Cases

### Test Case 1: Normal Distribution
**Input:**
```
data = [12.5, 15.0, 12.5, 18.3, 20.0, 12.5, 25.7, 15.0, 18.3, 22.1]
```

**Output:**
```
=== Statistical Analysis Report ===

Dataset: 12.5, 15.0, 12.5, 18.3, 20.0, 12.5, 25.7, 15.0, 18.3, 22.1

Mean: 17.19
Median: 16.65
Mode: 12.5
Variance: 20.34
Standard Deviation: 4.51
```

**Explanation:**
- Mean: Sum of all values / count = 171.9 / 10 = 17.19
- Median: Average of 5th and 6th values when sorted (15.0 + 18.3) / 2 = 16.65
- Mode: 12.5 appears 3 times (most frequent)
- Variance: Average of squared differences from mean
- Std Dev: Square root of variance

### Test Case 2: All Unique Values (No Mode)
**Input:**
```
data = [5.0, 10.0, 15.0, 20.0, 25.0, 30.0, 35.0, 40.0, 45.0, 50.0]
```

**Output:**
```
=== Statistical Analysis Report ===

Dataset: 5.0, 10.0, 15.0, 20.0, 25.0, 30.0, 35.0, 40.0, 45.0, 50.0

Mean: 27.50
Median: 27.50
Mode: No mode (all values are unique)
Variance: 206.25
Standard Deviation: 14.36
```

**Explanation:**
- Perfectly uniform distribution
- Median is average of 25.0 and 30.0
- No mode because all values appear once
- High standard deviation indicates spread

### Test Case 3: Multiple Modes
**Input:**
```
data = [3.0, 5.0, 3.0, 7.0, 5.0, 9.0, 3.0, 5.0]
```

**Output:**
```
=== Statistical Analysis Report ===

Dataset: 3.0, 5.0, 3.0, 7.0, 5.0, 9.0, 3.0, 5.0

Mean: 5.00
Median: 5.00
Mode: 3.0, 5.0 (bimodal)
Variance: 4.00
Standard Deviation: 2.00
```

**Explanation:**
- Both 3.0 and 5.0 appear 3 times each
- Bimodal distribution
- Median is exact middle value

## Key Concepts

<p align="justify">
This exercise reinforces understanding of:
</p>

- **Statistical Measures**: Mean, median, mode, variance, standard deviation
- **Array Traversal**: Iterating to calculate sums and frequencies
- **Sorting Algorithms**: Needed for median calculation
- **Frequency Analysis**: Counting occurrences for mode
- **Mathematical Operations**: Square, square root, power functions
- **Data Structures**: Using dictionaries or arrays for frequency counting

## Approach & Hints

### Step 1: Calculate Mean

<p align="justify">
The mean (average) is calculated by summing all values and dividing by the count. This is the foundation for variance calculations.
</p>

```csharp
double CalculateMean(double[] data)
{
    double sum = 0;
    foreach (double value in data)
    {
        sum += value;
    }
    return sum / data.Length;
}
```

### Step 2: Calculate Median

<p align="justify">
The median requires sorting the array first. For even-length arrays, average the two middle values. For odd-length arrays, take the single middle value.
</p>

```csharp
double CalculateMedian(double[] data)
{
    double[] sorted = (double[])data.Clone();
    Array.Sort(sorted);
    
    int n = sorted.Length;
    if (n % 2 == 0)
    {
        return (sorted[n/2 - 1] + sorted[n/2]) / 2.0;
    }
    else
    {
        return sorted[n/2];
    }
}
```

### Step 3: Calculate Mode

<p align="justify">
Use a Dictionary to track frequency of each value. Find the maximum frequency, then collect all values that appear with that frequency to handle multimodal distributions.
</p>

```csharp
// Use Dictionary to count frequencies
Dictionary<double, int> frequency = new Dictionary<double, int>();
foreach (double value in data)
{
    if (frequency.ContainsKey(value))
        frequency[value]++;
    else
        frequency[value] = 1;
}

// Find maximum frequency
int maxFreq = frequency.Values.Max();
// Get all values with maximum frequency
List<double> modes = frequency.Where(x => x.Value == maxFreq)
                               .Select(x => x.Key).ToList();
```

### Step 4: Calculate Variance and Standard Deviation

<p align="justify">
Variance measures spread by averaging squared differences from the mean. Standard deviation is the square root of variance, providing a measure in the original units.
</p>

```csharp
double CalculateVariance(double[] data, double mean)
{
    double sumSquaredDiff = 0;
    foreach (double value in data)
    {
        double diff = value - mean;
        sumSquaredDiff += diff * diff;
    }
    return sumSquaredDiff / data.Length;
}

double CalculateStdDev(double variance)
{
    return Math.Sqrt(variance);
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise05.StatisticalAnalyzer
{
    public class StatisticalAnalyzer
    {
        private double[] data;
        
        public StatisticalAnalyzer(double[] data)
        {
            this.data = data;
        }
        
        public double CalculateMean() { /* implementation */ }
        public double CalculateMedian() { /* implementation */ }
        public (List<double>, int) CalculateMode() { /* implementation */ }
        public double CalculateVariance(double mean) { /* implementation */ }
        public double CalculateStandardDeviation(double variance) { /* implementation */ }
        public void DisplayReport() { /* implementation */ }
    }
    
    class Program
    {
        static void Main()
        {
            // Get user input for data values
            // Create StatisticalAnalyzer instance
            // Display analysis report
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - Mean Calculation: O(n) - single pass through array
  - Median Calculation: O(n log n) - dominated by sorting
  - Mode Calculation: O(n) - single pass to build frequency map
  - Overall: O(n log n) - dominated by median calculation
- **Space Complexity**: O(n) - for sorted array copy and frequency dictionary

---

*Good luck with your implementation!*
