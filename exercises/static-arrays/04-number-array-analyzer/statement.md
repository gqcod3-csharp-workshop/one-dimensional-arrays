# Exercise 04: Number Array Analyzer

## Problem Statement

<p align="justify">
Develop a program that stores 20 random integers in a one-dimensional array and performs comprehensive analysis including separation of even/odd numbers, custom sorting implementation, and classification by sign (positive, negative, zero).
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Generates and stores 20 random integers in an array (range: -100 to 100)
2. Displays all numbers in the array
3. Separates and displays even and odd numbers independently
4. Sorts the array from smallest to largest without using built-in sorting functions
5. Counts and displays how many numbers are positive, negative, and zero
6. Implements independent methods for each process

## Input Specifications

- **Input**: `numbers` (array of 20 integers) - Randomly generated values

### Constraints
- Array size: 20 elements
- Value range: -100 to 100 (inclusive)
- Must implement custom sorting algorithm (no Array.Sort or LINQ OrderBy)

## Output Specifications

- **Output**: Multiple reports containing:
  - All original numbers
  - Separated even numbers
  - Separated odd numbers
  - Sorted array (ascending order)
  - Count of positive, negative, and zero values

## Example Test Cases

### Test Case 1: Mixed Values
**Input:**
```
numbers = [15, -8, 42, 0, -23, 17, 88, -5, 0, 31, 
           -67, 12, 55, -90, 3, 44, -12, 76, 0, -3]
```

**Output:**
```
Original Numbers: 15, -8, 42, 0, -23, 17, 88, -5, 0, 31, -67, 12, 55, -90, 3, 44, -12, 76, 0, -3

Even Numbers: -8, 42, 0, 88, 0, -67, 12, -90, 44, -12, 76, 0
Odd Numbers: 15, -23, 17, -5, 31, 55, 3, -3

Sorted Array: -90, -67, -23, -12, -8, -5, -3, 0, 0, 0, 3, 12, 15, 17, 31, 42, 44, 55, 76, 88

Positive Numbers: 10
Negative Numbers: 7
Zeros: 3
```

**Explanation:**
- 12 even numbers (divisible by 2)
- 8 odd numbers
- After sorting: ascending order maintained
- Classification: 10 positive, 7 negative, 3 zeros

### Test Case 2: All Positive
**Input:**
```
numbers = [5, 12, 8, 23, 45, 67, 89, 34, 56, 78,
           91, 15, 27, 39, 41, 53, 65, 77, 81, 93]
```

**Output:**
```
Original Numbers: 5, 12, 8, 23, 45, 67, 89, 34, 56, 78, 91, 15, 27, 39, 41, 53, 65, 77, 81, 93

Even Numbers: 12, 8, 34, 56, 78
Odd Numbers: 5, 23, 45, 67, 89, 91, 15, 27, 39, 41, 53, 65, 77, 81, 93

Sorted Array: 5, 8, 12, 15, 23, 27, 34, 39, 41, 45, 53, 56, 65, 67, 77, 78, 81, 89, 91, 93

Positive Numbers: 20
Negative Numbers: 0
Zeros: 0
```

**Explanation:**
- All values are positive
- 5 even, 15 odd
- No negative numbers or zeros

### Test Case 3: Edge Case with Many Zeros
**Input:**
```
numbers = [0, 0, -5, 10, 0, -15, 20, 0, -25, 30,
           0, -35, 40, 0, -45, 50, 0, -55, 60, 0]
```

**Output:**
```
Original Numbers: 0, 0, -5, 10, 0, -15, 20, 0, -25, 30, 0, -35, 40, 0, -45, 50, 0, -55, 60, 0

Even Numbers: 0, 0, 10, 0, 20, 0, 30, 0, 40, 0, 50, 0, 60, 0
Odd Numbers: -5, -15, -25, -35, -45, -55

Sorted Array: -55, -45, -35, -25, -15, -5, 0, 0, 0, 0, 0, 0, 0, 0, 10, 20, 30, 40, 50, 60

Positive Numbers: 6
Negative Numbers: 6
Zeros: 8
```

**Explanation:**
- 8 zeros count as even numbers
- Equal positive and negative non-zero values

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Array Generation**: Creating random integer datasets
- **Filtering and Separation**: Classifying elements by parity (even/odd)
- **Custom Sorting Algorithms**: Implementing bubble sort or selection sort
- **Conditional Counting**: Categorizing numbers by sign
- **Method Decomposition**: Breaking complex tasks into manageable functions

## Approach & Hints

### Step 1: Separate Even and Odd Numbers

<p align="justify">
Use the modulo operator to determine parity and store results in separate collections.
</p>

**Algorithm:**
- Iterate through the array
- If `number % 2 == 0`, it's even
- Otherwise, it's odd
- Store in respective lists or arrays

### Step 2: Implement Custom Sorting (Bubble Sort)

<p align="justify">
Implement a sorting algorithm without using built-in methods. Bubble sort is simple and effective for small arrays.
</p>

```csharp
public void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                // Swap
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}
```

### Step 3: Count by Sign

<p align="justify">
Iterate once and increment counters based on value comparison with zero.
</p>

```csharp
int positives = 0, negatives = 0, zeros = 0;
foreach (int num in numbers)
{
    if (num > 0) positives++;
    else if (num < 0) negatives++;
    else zeros++;
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
namespace Exercise04.NumberArrayAnalyzer
{
    public class ArrayAnalyzer
    {
        private int[] numbers;
        
        public ArrayAnalyzer(int size)
        {
            numbers = new int[size];
        }
        
        public void GenerateRandomNumbers(int min, int max)
        {
            // Generate random integers
        }
        
        public void DisplayNumbers()
        {
            // Show all numbers
        }
        
        public int[] GetEvenNumbers()
        {
            // Return array of even numbers
        }
        
        public int[] GetOddNumbers()
        {
            // Return array of odd numbers
        }
        
        public void SortArray()
        {
            // Custom sorting implementation (bubble sort or selection sort)
        }
        
        public (int positive, int negative, int zero) CountBySign()
        {
            // Return tuple with counts
        }
        
        public void DisplayFullReport()
        {
            // Show comprehensive analysis
        }
    }
    
    class Program
    {
        static void Main()
        {
            ArrayAnalyzer analyzer = new ArrayAnalyzer(20);
            analyzer.GenerateRandomNumbers(-100, 100);
            analyzer.DisplayFullReport();
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: O(n²) - Due to bubble sort. Other operations are O(n).
- **Space Complexity**: O(n) - Additional space for even/odd number storage.

---

*Good luck with your implementation!*
