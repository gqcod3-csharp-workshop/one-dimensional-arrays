# Exercise 01: Sum of Prime Numbers Ending in 7

## Problem Statement

<p align="justify">
Given an initial range and a final range, calculate the sum of all prime numbers ending in 7. If applicable, include the number 7.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Accepts two integer inputs: a starting value and an ending value
2. Identifies all prime numbers within that range
3. Filters those prime numbers that end with the digit 7
4. Returns the sum of those filtered numbers

## Input Specifications

- **Input 1**: `start` (integer) - The beginning of the range (inclusive)
- **Input 2**: `end` (integer) - The end of the range (inclusive)

### Constraints
- `start` ≥ 1
- `end` ≥ `start`
- Both values are positive integers

## Output Specifications

- **Output**: A single integer representing the sum of all prime numbers ending in 7 within the specified range

## Example Test Cases

### Test Case 1: Edge Case with Single Prime
**Input:**
```
start = 1
end = 10
```

**Output:**
```
7
```

**Explanation:**
- Prime numbers in range [1, 10]: 2, 3, 5, 7
- Primes ending in 7: 7
- Sum: 7

### Test Case 2: Small Range
**Input:**
```
start = 1
end = 50
```

**Output:**
```
108
```

**Explanation:**
- Prime numbers in range [1, 50]: 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47
- Primes ending in 7: 7, 17, 37, 47
- Sum: 7 + 17 + 37 + 47 = 108

### Test Case 3: Medium Range
**Input:**
```
start = 10
end = 100
```

**Output:**
```
248
```

**Explanation:**
- Prime numbers in range [10, 100] ending in 7: 17, 37, 47, 67, 97
- Sum: 17 + 37 + 47 + 67 + 97 = 248

### Test Case 4: Range with Single Result
**Input:**
```
start = 100
end = 120
```

**Output:**
```
107
```

**Explanation:**
- Prime numbers in range [100, 120] ending in 7: 107
- Note: 117 = 9 × 13 (not prime)
- Sum: 107

### Test Case 5: Range with No Results
**Input:**
```
start = 50
end = 60
```

**Output:**
```
0
```

**Explanation:**
- Prime numbers in range [50, 60]: 53, 59
- None of them end in 7
- Sum: 0

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Prime Number Detection**: Understanding and implementing algorithms to check if a number is prime
- **Range Iteration**: Looping through a specified range of values
- **Digit Extraction**: Checking the last digit of a number
- **Accumulation**: Summing values that meet specific criteria
- **Conditional Logic**: Filtering numbers based on multiple conditions

## Approach & Hints

### Step 1: Check for Prime Numbers

<p align="justify">
A prime number is a natural number greater than 1 that has no positive divisors other than 1 and itself.
</p>

**Algorithm:**
- If number ≤ 1, it's not prime
- If number = 2, it's prime
- If number is even, it's not prime
- Check divisibility from 3 to √n (only odd numbers)

### Step 2: Check Last Digit

<p align="justify">
To check if a number ends in 7:
</p>

```csharp
if (number % 10 == 7)
{
    // Number ends in 7
}
```

### Step 3: Iterate and Sum

<p align="justify">
Loop through the range, apply both conditions, and accumulate the sum.
</p>

## Implementation Guidelines

### Recommended Structure

```csharp
using System;

class Program
{
    static void Main()
    {
        // 1. Read input
        // 2. Initialize sum variable
        // 3. Iterate through range
        // 4. For each number, check if it's prime AND ends in 7
        // 5. Add valid numbers to sum
        // 6. Output the result
    }
    
    // Helper method to check if a number is prime
    static bool IsPrime(int number)
    {
        // Implementation
    }
}
```

### Complexity Analysis

- **Time Complexity**: O(n × √m) where n is the range size and m is the largest number to check
- **Space Complexity**: O(1) - only constant extra space needed

---

*Good luck with your implementation!*
