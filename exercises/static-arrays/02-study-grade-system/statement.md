# Exercise 02: Student Grade Management System

## Problem Statement

<p align="justify">
Develop a program in C# that allows storing the grades of 10 students in an assessment using a one-dimensional array. The system must validate inputs, display statistics, and use object-oriented programming principles.
</p>

## Objective

<p align="justify">
Develop a program that:
</p>

1. Stores grades for 10 students in a one-dimensional array
2. Validates that each grade is between 0 and 10
3. Displays all registered grades
4. Calculates the overall average, highest grade, and lowest grade
5. Indicates how many students passed and how many failed
6. Implements a `Course` class with methods to perform the calculations

## Input Specifications

- **Input**: `grades` (array of 10 doubles) - Student grades for an evaluation

### Constraints
- Each grade must be between 0.0 and 10.0 (inclusive)
- Exactly 10 grades must be entered
- Passing grade threshold: ≥ 6.0

## Output Specifications

- **Output**: A comprehensive report containing:
  - List of all registered grades
  - Overall average
  - Highest grade
  - Lowest grade
  - Number of students who passed
  - Number of students who failed

## Example Test Cases

### Test Case 1: All Students Pass
**Input:**
```
grades = [8.5, 9.0, 7.5, 10.0, 8.0, 7.0, 9.5, 8.5, 7.5, 9.0]
```

**Output:**
```
Registered Grades: 8.5, 9.0, 7.5, 10.0, 8.0, 7.0, 9.5, 8.5, 7.5, 9.0
Overall Average: 8.45
Highest Grade: 10.0
Lowest Grade: 7.0
Students Passed: 10
Students Failed: 0
```

**Explanation:**
- All 10 grades are ≥ 6.0
- Average: (8.5 + 9.0 + 7.5 + 10.0 + 8.0 + 7.0 + 9.5 + 8.5 + 7.5 + 9.0) / 10 = 84.5 / 10 = 8.45
- Maximum value: 10.0
- Minimum value: 7.0

### Test Case 2: Mixed Results
**Input:**
```
grades = [5.5, 8.0, 4.0, 7.5, 3.5, 9.0, 6.5, 5.0, 8.5, 7.0]
```

**Output:**
```
Registered Grades: 5.5, 8.0, 4.0, 7.5, 3.5, 9.0, 6.5, 5.0, 8.5, 7.0
Overall Average: 6.45
Highest Grade: 9.0
Lowest Grade: 3.5
Students Passed: 6
Students Failed: 4
```

**Explanation:**
- Passed (≥ 6.0): 8.0, 7.5, 9.0, 6.5, 8.5, 7.0 → 6 students
- Failed (< 6.0): 5.5, 4.0, 3.5, 5.0 → 4 students
- Average: 64.5 / 10 = 6.45

### Test Case 3: Edge Cases
**Input:**
```
grades = [0.0, 10.0, 6.0, 5.9, 6.1, 0.5, 10.0, 5.0, 9.5, 8.0]
```

**Output:**
```
Registered Grades: 0.0, 10.0, 6.0, 5.9, 6.1, 0.5, 10.0, 5.0, 9.5, 8.0
Overall Average: 6.50
Highest Grade: 10.0
Lowest Grade: 0.0
Students Passed: 6
Students Failed: 4
```

**Explanation:**
- Tests boundary values (0.0, 10.0)
- Tests passing threshold boundary (5.9 fails, 6.0 passes)
- Passed: 10.0, 6.0, 6.1, 10.0, 9.5, 8.0 → 6 students
- Failed: 0.0, 5.9, 0.5, 5.0 → 4 students

## Key Concepts

<p align="justify">
This exercise focuses on:
</p>

- **Array Management**: Storing and manipulating multiple values in a one-dimensional array
- **Input Validation**: Ensuring data integrity by validating grade ranges
- **Statistical Calculations**: Computing average, maximum, and minimum values
- **Conditional Logic**: Classifying students based on passing criteria
- **Object-Oriented Programming**: Creating a `Course` class with encapsulated methods

## Approach & Hints

### Step 1: Create the Course Class

<p align="justify">
Design a `Course` class that encapsulates the grade array and provides methods for statistical calculations and analysis.
</p>

**Class Structure:**
- Field: `double[] grades` to store the 10 grades
- Method: `InputGrades()` - reads and validates grades
- Method: `DisplayGrades()` - shows all grades
- Method: `CalculateAverage()` - computes the mean
- Method: `GetHighestGrade()` - finds the maximum
- Method: `GetLowestGrade()` - finds the minimum
- Method: `CountPassedStudents()` - counts grades ≥ 6.0
- Method: `CountFailedStudents()` - counts grades < 6.0

### Step 2: Input Validation

<p align="justify">
Implement robust validation to ensure grades are within the valid range (0-10).
</p>

```csharp
public void InputGrades()
{
    for (int i = 0; i < grades.Length; i++)
    {
        bool validInput = false;
        while (!validInput)
        {
            Console.Write($"Enter grade for student {i + 1}: ");
            double grade = double.Parse(Console.ReadLine());
            
            if (grade >= 0 && grade <= 10)
            {
                grades[i] = grade;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid grade. Please enter a value between 0 and 10.");
            }
        }
    }
}
```

### Step 3: Statistical Analysis

<p align="justify">
Iterate through the array to calculate statistics. Use accumulator variables for the average and comparison logic for min/max values.
</p>

```csharp
public double CalculateAverage()
{
    double sum = 0;
    foreach (double grade in grades)
    {
        sum += grade;
    }
    return sum / grades.Length;
}
```

## Implementation Guidelines

### Recommended Structure

```csharp
namespace Exercise02.StudentGradeManagement
{
    public class Course
    {
        private double[] grades;
        
        public Course(int studentCount)
        {
            grades = new double[studentCount];
        }
        
        public void InputGrades()
        {
            // Validate and store grades
        }
        
        public void DisplayGrades()
        {
            // Show all grades
        }
        
        public double CalculateAverage()
        {
            // Return average grade
        }
        
        public double GetHighestGrade()
        {
            // Return maximum grade
        }
        
        public double GetLowestGrade()
        {
            // Return minimum grade
        }
        
        public int CountPassedStudents()
        {
            // Count grades >= 6.0
        }
        
        public int CountFailedStudents()
        {
            // Count grades < 6.0
        }
        
        public void DisplayReport()
        {
            // Show comprehensive statistics
        }
    }
    
    class Program
    {
        static void Main()
        {
            Course course = new Course(10);
            course.InputGrades();
            course.DisplayReport();
        }
    }
}
```

### Complexity Analysis

- **Time Complexity**: O(n) - Where n is the number of students (10). Each method iterates through the array once.
- **Space Complexity**: O(n) - Storage for n grades in the array.

---

*Good luck with your implementation!*
