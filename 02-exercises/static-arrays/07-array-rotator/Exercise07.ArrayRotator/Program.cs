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
            if (array == null || array.Length < 3)
            {
                throw new ArgumentException("Array must have at least 3 elements.");
            }
            this.array = array;
        }
        
        public void RotateLeft(int positions)
        {
            int n = array.Length;
            positions = positions % n;
            
            if (positions == 0) return;
            
            Reverse(0, positions - 1);
            Reverse(positions, n - 1);
            Reverse(0, n - 1);
        }
        
        public void RotateRight(int positions)
        {
            int n = array.Length;
            positions = positions % n;
            
            if (positions == 0) return;
            
            RotateLeft(n - positions);
        }
        
        private void Reverse(int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }
        
        public void Display()
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
        
        public int[] GetArray()
        {
            return array;
        }
    }
    
    class Program
    {
        static void Main()
        {   
            try
            {
                int[] arr = ReadArray();
                
                int[] originalCopy = (int[])arr.Clone();
                ArrayRotator rotator = new ArrayRotator(arr);
                
                Console.Write("\nEnter rotation direction (left/right): ");
                string? direction = Console.ReadLine()?.ToLower();
                
                if (direction != "left" && direction != "right")
                {
                    throw new ArgumentException("Direction must be 'left' or 'right'.");
                }
                
                Console.Write("Enter number of positions to rotate: ");
                string? posInput = Console.ReadLine();
                
                if (!int.TryParse(posInput, out int positions) || positions < 0)
                {
                    throw new ArgumentException("Positions must be a non-negative integer.");
                }
                
                Console.Write("\nOriginal Array: ");
                DisplayArray(originalCopy);
                
                int effectivePositions = positions % arr.Length;
                Console.Write($"Rotation: {positions} positions to the {direction}");
                if (positions != effectivePositions)
                {
                    Console.Write($" (effective: {effectivePositions} positions)");
                }
                Console.WriteLine();
                
                if (direction == "left")
                {
                    rotator.RotateLeft(positions);
                }
                else
                {
                    rotator.RotateRight(positions);
                }
                
                Console.Write("Rotated Array: ");
                rotator.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        static int[] ReadArray()
        {
            Console.Write("\nEnter the number of elements (3-100): ");
            string? sizeInput = Console.ReadLine();
            
            if (!int.TryParse(sizeInput, out int size) || size < 3 || size > 100)
            {
                throw new ArgumentException("Array size must be between 3 and 100.");
            }
            
            int[] arr = new int[size];
            Console.WriteLine($"Enter {size} integers:");
            
            for (int i = 0; i < size; i++)
            {
                Console.Write($"  Element {i + 1}: ");
                string? input = Console.ReadLine();
                
                if (!int.TryParse(input, out int value))
                {
                    throw new ArgumentException("Invalid integer value.");
                }
                
                arr[i] = value;
            }
            
            return arr;
        }
        
        static void DisplayArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}
