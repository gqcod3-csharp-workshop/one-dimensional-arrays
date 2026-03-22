namespace Exercise03.MonthlyTemperatureTracker
{
    public class TemperaturaMes
    {
        private double[] temperatures;
        private const int DaysInMonth = 31;
        private const double MinTemp = -10.0;
        private const double MaxTemp = 45.0;

        public TemperaturaMes()
        {
            temperatures = new double[DaysInMonth];
        }

        public void GenerateRandomTemperatures()
        {
            Random random = new Random();
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = Math.Round(random.NextDouble() * (MaxTemp - MinTemp) + MinTemp, 1);
            }
        }

        public void DisplayTemperatures()
        {
            Console.WriteLine("\n=== Daily Temperatures ===");
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.Write($"{temperatures[i]:F1}");
                if (i < temperatures.Length - 1)
                    Console.Write(", ");
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        public double CalculateAverage()
        {
            double sum = 0;
            foreach (double temp in temperatures)
            {
                sum += temp;
            }
            return sum / temperatures.Length;
        }

        public int CountAboveAverage()
        {
            double average = CalculateAverage();
            int count = 0;
            foreach (double temp in temperatures)
            {
                if (temp > average)
                    count++;
            }
            return count;
        }

        public int[] SearchTemperature(double targetTemp)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                if (Math.Abs(temperatures[i] - targetTemp) < 0.01)
                {
                    positions.Add(i);
                }
            }
            return positions.ToArray();
        }

        public void DisplayReport()
        {
            Console.WriteLine("\n=== Monthly Temperature Report ===");
            DisplayTemperatures();
            
            double average = CalculateAverage();
            Console.WriteLine($"\nAverage Temperature: {average:F2}°C");
            Console.WriteLine($"Days Above Average: {CountAboveAverage()}");
        }

        public void SearchAndDisplay(double searchTemp)
        {
            int[] positions = SearchTemperature(searchTemp);
            
            Console.WriteLine($"\n=== Search Results ===");
            if (positions.Length > 0)
            {
                Console.Write($"Temperature {searchTemp:F1}°C found at position(s): ");
                for (int i = 0; i < positions.Length; i++)
                {
                    Console.Write(positions[i]);
                    if (i < positions.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Temperature {searchTemp:F1}°C not found");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TemperaturaMes month = new TemperaturaMes();
            month.GenerateRandomTemperatures();
            month.DisplayReport();

            Console.Write("\nEnter temperature to search: ");
            double searchTemp;
            
            if (double.TryParse(Console.ReadLine(), out searchTemp))
            {
                month.SearchAndDisplay(searchTemp);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
