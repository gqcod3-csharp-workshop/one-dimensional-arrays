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
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data array cannot be null or empty.");
            }
            this.data = data;
        }
        
        public double CalculateMean()
        {
            double sum = 0;
            foreach (double value in data)
            {
                sum += value;
            }
            return sum / data.Length;
        }
        
        public double CalculateMedian()
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
        
        public (List<double> modes, int maxFrequency) CalculateMode()
        {
            Dictionary<double, int> frequency = new Dictionary<double, int>();
            foreach (double value in data)
            {
                if (frequency.ContainsKey(value))
                    frequency[value]++;
                else
                    frequency[value] = 1;
            }
            
            int maxFreq = frequency.Values.Max();
            List<double> modes = frequency.Where(x => x.Value == maxFreq)
                                           .Select(x => x.Key)
                                           .OrderBy(x => x)
                                           .ToList();
            
            return (modes, maxFreq);
        }
        
        public double CalculateVariance(double mean)
        {
            double sumSquaredDiff = 0;
            foreach (double value in data)
            {
                double diff = value - mean;
                sumSquaredDiff += diff * diff;
            }
            return sumSquaredDiff / data.Length;
        }
        
        public double CalculateStandardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }
        
        public void DisplayReport()
        {
            Console.WriteLine("=== Statistical Analysis Report ===");
            Console.WriteLine();
            
            Console.Write("Dataset: ");
            Console.WriteLine(string.Join(", ", data));
            Console.WriteLine();
            
            double mean = CalculateMean();
            Console.WriteLine($"Mean: {mean:F2}");
            
            double median = CalculateMedian();
            Console.WriteLine($"Median: {median:F2}");
            
            var (modes, maxFreq) = CalculateMode();
            Console.Write("Mode: ");
            
            if (maxFreq == 1)
            {
                Console.WriteLine("No mode (all values are unique)");
            }
            else if (modes.Count == 1)
            {
                Console.WriteLine($"{modes[0]:F1}");
            }
            else if (modes.Count == 2)
            {
                Console.WriteLine($"{string.Join(", ", modes.Select(m => m.ToString("F1")))} (bimodal)");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", modes.Select(m => m.ToString("F1")))} (multimodal)");
            }
            
            double variance = CalculateVariance(mean);
            Console.WriteLine($"Variance: {variance:F2}");
            
            double stdDev = CalculateStandardDeviation(variance);
            Console.WriteLine($"Standard Deviation: {stdDev:F2}");
        }
    }
    
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter the number of data values: ");
                string? countInput = Console.ReadLine();
                
                if (!int.TryParse(countInput, out int count) || count <= 0)
                {
                    Console.WriteLine("Error: Please enter a valid positive number.");
                    return;
                }
                
                double[] data = new double[count];
                Console.WriteLine($"\nEnter {count} numeric values:");
                
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Value {i + 1}: ");
                    string? valueInput = Console.ReadLine();
                    
                    if (!double.TryParse(valueInput, out double value))
                    {
                        Console.WriteLine("Error: Please enter a valid numeric value.");
                        return;
                    }
                    
                    data[i] = value;
                }
                
                Console.WriteLine();
                StatisticalAnalyzer analyzer = new StatisticalAnalyzer(data);
                analyzer.DisplayReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
