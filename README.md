# One-Dimensional Arrays in C#

<p align="justify">
A hands-on workshop focused on mastering one-dimensional arrays in C#, covering both static arrays and dynamic arrays (`List<T>`) through structured theory and practical exercises.
</p>

---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [How to Use This Repository](#how-to-use-this-repository)
- [Running an Exercise](#running-an-exercise)

---

## Prerequisites

Before cloning this repository, ensure you have the following installed:

| Tool | Minimum Version | Download |
|------|----------------|---------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 8.0 | https://dotnet.microsoft.com/download |
| [Git](https://git-scm.com/) | 2.x | https://git-scm.com/downloads |

Optionally, a C#-compatible IDE is recommended:

- [Visual Studio Code](https://code.visualstudio.com/) with the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension
- [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Visual Studio](https://visualstudio.microsoft.com/) (Windows / macOS)

---

## Getting Started

### 1. Clone the repository

```bash
git clone git@github.com:gqcod3-csharp-workshop/one-dimensional-arrays.git
```

Or via HTTPS:

```bash
git clone https://github.com/gqcod3-csharp-workshop/one-dimensional-arrays.git
```

### 2. Navigate to the project directory

```bash
cd one-dimensional-arrays
```

### 3. Verify your .NET installation

```bash
dotnet --version
```

You should see version `8.0.x` or higher.

---

## Project Structure

```
one-dimensional-arrays/
├── 01-theory/                          # Conceptual documentation
│   └── README.md                       # In-depth theory on static and dynamic arrays
│
└── 02-exercises/                       # Hands-on coding exercises
    ├── static-arrays/                  # Exercises using fixed-size arrays (T[])
    │   ├── 01-prime-seven-sum/
    │   ├── 02-study-grade-system/
    │   ├── 03-monthly-temperature-tracker/
    │   ├── 04-number-array-analyzer/
    │   ├── 05-statistical-analyzer/
    │   ├── 06-polynomial-operations/
    │   ├── 07-array-rotator/
    │   └── 08-shadow-length-calculator/
    │
    └── dynamic-arrays/                 # Exercises using resizable collections (List<T>)
        ├── 01-product-inventory-manager/
        └── 02-export-data-analyzer/
```

---

## How to Use This Repository

1. **Read the theory first** — Start with [01-theory/README.md](01-theory/README.md) to understand the core concepts behind static and dynamic arrays in C#.

2. **Work through the exercises in order** — Each exercise folder contains:
   - `statement.md` — The problem description, requirements, and expected output.
   - A `.csproj` project with a `Program.cs` starter file where you write your solution.

3. **Start with static arrays**, then move on to dynamic arrays once you are comfortable with fixed-size collections.

---

## Running an Exercise

Navigate to the exercise project directory and use the .NET CLI:

```bash
# Example: running exercise 01 from static-arrays
cd 02-exercises/static-arrays/01-prime-seven-sum/Exercise01.PrimeSevenSum
dotnet run
```

To run all exercises from the root using a specific project path:

```bash
dotnet run --project 02-exercises/static-arrays/01-prime-seven-sum/Exercise01.PrimeSevenSum
```

---

*Workshop maintained by [gqcod3-csharp-workshop](https://github.com/gqcod3-csharp-workshop).*
