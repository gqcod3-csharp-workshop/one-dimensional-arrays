# One-Dimensional Arrays in C#

## Table of Contents
- [Overview](#overview)
- [Static Arrays](#static-arrays)
- [Dynamic Arrays](#dynamic-arrays)
- [Comparison](#comparison)
- [Best Practices](#best-practices)

---

## Overview

A **one-dimensional array** is a fundamental linear data structure that stores a collection of elements of the same type in contiguous memory locations. Arrays provide an efficient way to manage and process data in C#.

In C#, arrays are objects derived from the `System.Array` class, which provides built-in properties and methods for manipulating data at scale. Arrays can be classified into two main categories:

- **Static Arrays**: Fixed-size arrays where the size is determined at initialization and cannot be changed.
- **Dynamic Arrays**: Resizable collections implemented through `List<T>` that can grow or shrink during runtime.

<center>
  <img src="https://media.geeksforgeeks.org/wp-content/uploads/20240501134148/One_D_Array-768.webp" alt="One-Dimensional Array representation showing elements and their corresponding indices" width="600" />
</center>

### Common Characteristics

Both static and dynamic arrays share these fundamental properties:

- **Zero-Based Indexing**: The index of the first element is always `0`.
- **Type Safety**: Both are strongly typed, ensuring that only elements of the specified type can be stored.
- **Reference Type**: Both are reference types stored on the heap.
- **Fast Access**: Element retrieval by index is performed in $O(1)$ time complexity.

---

## Static Arrays

Static arrays (or standard arrays) have a **fixed size** that is determined at initialization and cannot be modified during runtime. They are ideal for scenarios where the collection size is known beforehand and performance is critical.

### Key Characteristics

- **Fixed Size**: Size is immutable after initialization.
- **Performance**: Optimized for speed with minimal memory overhead.
- **Memory Layout**: Elements stored in contiguous memory for cache-friendly access.
- **API**: Basic operations via `Length` property and indexer syntax.

### Declaration and Initialization

```csharp
// Initialization with a fixed size (default values assigned)
int[] numbers = new int[5];

// Initialization with explicit values
int[] scores = new int[] { 90, 85, 77, 88, 92 };

// Shorthand initialization
string[] fruits = { "Apple", "Banana", "Cherry" };
```

### Element Access and Manipulation

```csharp
// Accessing elements
int firstScore = scores[0]; 
int lastScore = scores[scores.Length - 1];

// Modifying elements
scores[1] = 95;

// Getting array size
int totalElements = scores.Length;
```

### Implementation Example

```csharp
using System;

namespace StaticArrayDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] categories = { "Electronics", "Clothing", "Books", "Toys" };
            
            Console.WriteLine("Product Categories:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            Console.WriteLine($"\nFirst category: {categories[0]}");
            Console.WriteLine($"Total categories: {categories.Length}");
        }
    }
}
```

---

## Dynamic Arrays

Dynamic arrays are implemented using the `System.Collections.Generic.List<T>` class. They provide **automatic resizing** capabilities, making them suitable for collections where the size is unknown or changes frequently during runtime.

### Key Characteristics

- **Resizable**: Automatically grows or shrinks as elements are added or removed.
- **Automatic Memory Management**: Handles internal array reallocation transparently.
- **Rich API**: Extensive methods for manipulation including `Add()`, `Remove()`, `Insert()`, `Sort()`, `Find()`, and many more.
- **LINQ Compatible**: Seamlessly integrates with Language Integrated Query for advanced operations.

### Declaration and Initialization

```csharp
using System.Collections.Generic;

// Empty list
List<int> numbers = new List<int>();

// With initial capacity (performance optimization)
List<string> names = new List<string>(100);

// Collection initializer
List<double> prices = new List<double> { 19.99, 29.99, 39.99 };
```

### Element Access and Manipulation

```csharp
// Adding elements
numbers.Add(10);
numbers.Add(20);

// Accessing and modifying
int firstNumber = numbers[0];
numbers[1] = 25;

// Removing elements
numbers.Remove(10);        // By value
numbers.RemoveAt(0);       // By index

// Getting list size
int count = numbers.Count;

// Inserting at specific position
numbers.Insert(1, 15);

// Checking if element exists
bool exists = numbers.Contains(20);
```

### Implementation Example

```csharp
using System;
using System.Collections.Generic;

namespace DynamicArrayDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> tasks = new List<string>
            {
                "Complete project documentation",
                "Review code changes"
            };

            tasks.Add("Deploy to production");
            tasks.Add("Run integration tests");

            Console.WriteLine("Task List:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

            tasks.RemoveAt(0);
            Console.WriteLine($"\nRemaining tasks: {tasks.Count}");
        }
    }
}
```

---

## Comparison

| Feature                | Static Array (`T[]`)       | Dynamic Array (`List<T>`)      |
|------------------------|---------------------------|--------------------------------|
| **Size**               | Fixed at initialization   | Dynamically resizable          |
| **Performance**        | Faster (lower overhead)   | Slightly slower (manages capacity) |
| **Memory Efficiency**  | More efficient            | Additional overhead for resizing |
| **API Richness**       | Basic (`Length`, indexer) | Extensive (`Add`, `Remove`, `Sort`, etc.) |
| **Use Case**           | Known, constant size      | Variable or unknown size       |
| **Initialization**     | `new T[size]` or `{ ... }`| `new List<T>()` or `new List<T> { ... }` |

---

## Best Practices

### When to Use Static Arrays

1. **Known Size**: When the number of elements is predetermined and constant.
2. **Performance-Critical Code**: In tight loops or high-frequency operations where minimal overhead is essential.
3. **Memory Constraints**: When memory efficiency is a priority.

### When to Use Dynamic Arrays

1. **Unknown Size**: When the collection size varies or is not known at compile-time.
2. **Frequent Modifications**: When elements are regularly added, removed, or inserted.
3. **Rich Operations**: When you need built-in sorting, searching, or filtering capabilities.

### Performance Optimization

1. **Pre-allocate Capacity**: When using `List<T>` with a known approximate size, specify initial capacity to minimize reallocations.
    ```csharp
    var largeList = new List<int>(1000);
    ```

2. **Choose Appropriately**: Use static arrays for fixed data sets and dynamic arrays for variable collections.

3. **Avoid Boxing**: Use generic collections (`List<T>`) instead of non-generic ones (`ArrayList`) to prevent boxing overhead.

4. **Leverage LINQ**: Use LINQ for expressive data operations, but be mindful of performance in high-frequency scenarios.

---

*Documentation updated on Saturday Mar 21, 2026.*
