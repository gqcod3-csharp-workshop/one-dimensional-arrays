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
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(min, max + 1);
            }
        }

        public void DisplayNumbers()
        {
            Console.Write("Numbers: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public int[] GetEvenNumbers()
        {
            List<int> evens = new List<int>();
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                    evens.Add(num);
            }
            return evens.ToArray();
        }

        public int[] GetOddNumbers()
        {
            List<int> odds = new List<int>();
            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                    odds.Add(num);
            }
            return odds.ToArray();
        }

        public void SortArray()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        public (int positive, int negative, int zero) CountBySign()
        {
            int positive = 0, negative = 0, zero = 0;
            
            foreach (int num in numbers)
            {
                if (num > 0)
                    positive++;
                else if (num < 0)
                    negative++;
                else
                    zero++;
            }
            
            return (positive, negative, zero);
        }

        public void DisplayFullReport()
        {
            Console.WriteLine("\n=== Array Analysis Report ===\n");
            
            Console.Write("Original ");
            DisplayNumbers();
            
            int[] evens = GetEvenNumbers();
            Console.Write("\nEven Numbers: ");
            for (int i = 0; i < evens.Length; i++)
            {
                Console.Write(evens[i]);
                if (i < evens.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            
            int[] odds = GetOddNumbers();
            Console.Write("Odd Numbers: ");
            for (int i = 0; i < odds.Length; i++)
            {
                Console.Write(odds[i]);
                if (i < odds.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            
            SortArray();
            Console.Write("\nSorted ");
            DisplayNumbers();
            
            var (positive, negative, zero) = CountBySign();
            Console.WriteLine($"\nPositive Numbers: {positive}");
            Console.WriteLine($"Negative Numbers: {negative}");
            Console.WriteLine($"Zeros: {zero}");
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
