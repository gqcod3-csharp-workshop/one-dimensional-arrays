# Exercise 07: Array Rotator

## Problem Statement

<p align="justify">
Design a program that rotates elements of a one-dimensional array by a specified number of positions. Implement both left and right rotation efficiently using in-place algorithms with O(1) space complexity.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Stores elements in a one-dimensional array
2. Accepts rotation direction (left or right) and number of positions
3. Implements in-place rotation without creating new arrays
4. Handles edge cases (rotation count greater than array length)
5. Displays the array before and after rotation
6. Uses efficient algorithm with O(1) auxiliary space

## Input Specifications

- **Input 1**: `arr` (array of integers) - The array to be rotated
- **Input 2**: `positions` (integer) - Number of positions to rotate
- **Input 3**: `direction` (string) - "left" or "right"

### Constraints
- Array size: minimum 3 elements, maximum 100 elements
- Positions: 0 to array length (handles overflow with modulo)
- Direction: must be "left" or "right"
- Must implement in-place rotation (no additional array)

## Output Specifications

- **Output**: 
  - Original array before rotation
  - Direction and number of positions
  - Resulting array after rotation

## Example Test Cases

### Test Case 1: Left Rotation
**Input:**
```
arr = [1, 2, 3, 4, 5, 6, 7]
positions = 3
direction = "left"
```

**Output:**
```
Original Array: [1, 2, 3, 4, 5, 6, 7]
Rotation: 3 positions to the left

Rotated Array: [4, 5, 6, 7, 1, 2, 3]
```

**Explanation:**
- Elements shift left by 3 positions
- First 3 elements (1,2,3) move to the end
- Result: [4,5,6,7,1,2,3]

### Test Case 2: Right Rotation
**Input:**
```
arr = [10, 20, 30, 40, 50]
positions = 2
direction = "right"
```

**Output:**
```
Original Array: [10, 20, 30, 40, 50]
Rotation: 2 positions to the right

Rotated Array: [40, 50, 10, 20, 30]
```

**Explanation:**
- Elements shift right by 2 positions
- Last 2 elements (40,50) move to the beginning
- Result: [40,50,10,20,30]

### Test Case 3: Rotation Greater Than Array Length
**Input:**
```
arr = [1, 2, 3, 4, 5]
positions = 7
direction = "left"
```

**Output:**
```
Original Array: [1, 2, 3, 4, 5]
Rotation: 7 positions to the left (effective: 2 positions)

Rotated Array: [3, 4, 5, 1, 2]
```

**Explanation:**
- Rotating left by 7 positions = rotating by 7 % 5 = 2 positions
- Effective rotation is 2 positions left
- Result: [3,4,5,1,2]

### Test Case 4: Full Rotation (No Change)
**Input:**
```
arr = [5, 10, 15, 20]
positions = 4
direction = "right"
```

**Output:**
```
Original Array: [5, 10, 15, 20]
Rotation: 4 positions to the right (effective: 0 positions)

Rotated Array: [5, 10, 15, 20]
```

**Explanation:**
- Rotating by array length (4) results in original array
- 4 % 4 = 0, no effective rotation

## Key Concepts

<p align="justify">
This exercise reinforces understanding of:
</p>

- **Array Manipulation**: In-place element rearrangement
- **Reversal Algorithm**: Efficient rotation technique
- **Modulo Arithmetic**: Handling rotation overflow
- **Space Optimization**: O(1) auxiliary space
- **Algorithm Efficiency**: O(n) time complexity
- **Edge Cases**: Zero rotation, full rotation, overflow

## Approach & Hints

### Step 1: Understand the Reversal Algorithm

<p align="justify">
The optimal approach uses three array reversals to achieve rotation with O(1) space complexity. This technique is elegant and efficient.
</p>

**For Left Rotation by k positions:**
1. Reverse first k elements
2. Reverse remaining n-k elements  
3. Reverse entire array

**For Right Rotation by k positions:**
- Convert to left rotation: right(k) = left(n-k)
- Then apply left rotation algorithm

### Step 2: Implement Array Reversal Helper

<p align="justify">
Create a helper method to reverse elements in a specified range. This method will be used three times in the rotation algorithm.
</p>

```csharp
void Reverse(int[] arr, int start, int end)
{
    while (start < end)
    {
        // Swap elements
        int temp = arr[start];
        arr[start] = arr[end];
        arr[end] = temp;
        start++;
        end--;
    }
}
```

### Step 3: Implement Rotation with Modulo Handling

<p align="justify">
Handle edge cases using modulo arithmetic to prevent unnecessary rotations and process rotation counts larger than array length.
</p>

```csharp
void RotateLeft(int[] arr, int positions)
{
    int n = arr.Length;
    positions = positions % n; // Handle overflow
    
    if (positions == 0) return; // No rotation needed
    
    // Three reversals
    Reverse(arr, 0, positions - 1);      // Reverse first part
    Reverse(arr, positions, n - 1);      // Reverse second part
    Reverse(arr, 0, n - 1);              // Reverse entire array
}
```

### Step 4: Example Walkthrough

<p align="justify">
Understanding how the algorithm works with a concrete example helps verify correctness.
</p>

**Left Rotate [1,2,3,4,5] by 2:**

```
Original:           [1, 2, 3, 4, 5]

Step 1: Reverse first 2 elements
                    [2, 1, 3, 4, 5]

Step 2: Reverse remaining 3 elements  
                    [2, 1, 5, 4, 3]

Step 3: Reverse entire array
                    [3, 4, 5, 1, 2]

Final Result:       [3, 4, 5, 1, 2]
```

## Implementation Guidelines

### Recommended Structure

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise07.ArrayRotator
{
    public class ArrayRotator
    {
        private int[] array;
        
        public ArrayRotator(int[] array)
        {
            this.array = array;
        }
        
        public void RotateLeft(int positions) { /* implementation */ }
        public void RotateRight(int positions) { /* implementation */ }
        private void Reverse(int start, int end) { /* implementation */ }
        public void Display() { /* implementation */ }
    }
    
    class Program
    {
        static void Main()
        {
            // Get user input for array and rotation parameters
            // Create ArrayRotator instance
            // Perform rotation and display results
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: 
  - Reversal Algorithm: O(n) where n is array length
  - Each reversal is O(k) where k is subarray length
  - Overall: O(n) - optimal for this problem
- **Space Complexity**: O(1) - constant auxiliary space, true in-place rotation

---

*Good luck with your implementation!*
