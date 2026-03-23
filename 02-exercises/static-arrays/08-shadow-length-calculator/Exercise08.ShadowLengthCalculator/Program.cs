using System.Globalization;

namespace Exercise08.ShadowLengthCalculator
{
    public class ShadowCalculator
    {
        private double[] heights;
        private double sunAngle;

        public ShadowCalculator(double[] heights, double sunAngle)
        {
            if (heights == null || heights.Length == 0)
                throw new ArgumentException("Heights array must have at least one element.");

            foreach (double h in heights)
            {
                if (h <= 0)
                    throw new ArgumentException("All object heights must be positive.");
            }

            if (sunAngle <= 0 || sunAngle >= 90)
            {
                string detail = sunAngle <= 0
                    ? "At 0°, the sun is at the horizon and shadow length is infinite."
                    : "At 90°, the sun is directly overhead and shadow length is zero.";
                throw new ArgumentException(
                    $"Sun angle must be between 0° and 90° (exclusive).\n{detail}");
            }

            this.heights = heights;
            this.sunAngle = sunAngle;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public double CalculateShadowLength(double height)
        {
            double angleRadians = DegreesToRadians(sunAngle);
            double tanAngle = Math.Tan(angleRadians);
            return height / tanAngle;
        }

        public double[] CalculateAllShadows()
        {
            double[] shadows = new double[heights.Length];
            for (int i = 0; i < heights.Length; i++)
            {
                shadows[i] = CalculateShadowLength(heights[i]);
            }
            return shadows;
        }

        public void DisplayResults()
        {
            double[] shadows = CalculateAllShadows();

            Console.WriteLine("=== Shadow Length Calculation ===");
            Console.WriteLine();
            Console.WriteLine($"Sun Angle: {sunAngle:F2}°");
            Console.WriteLine();
            Console.WriteLine("Object Height (m) | Shadow Length (m)");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < heights.Length; i++)
            {
                Console.WriteLine($"    {heights[i],8:F2}     |    {shadows[i],8:F2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                double[] heights = ReadHeights();

                Console.Write("\nEnter sun angle of elevation (degrees, 0 < angle < 90): ");
                string? angleInput = Console.ReadLine();

                if (!double.TryParse(angleInput, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out double sunAngle))
                {
                    throw new ArgumentException("Invalid sun angle value.");
                }

                ShadowCalculator calculator = new ShadowCalculator(heights, sunAngle);

                Console.WriteLine();
                calculator.DisplayResults();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: Invalid sun angle!");
                Console.WriteLine(ex.Message);
            }
        }

        static double[] ReadHeights()
        {
            Console.Write("\nEnter the number of objects (1-20): ");
            string? sizeInput = Console.ReadLine();

            if (!int.TryParse(sizeInput, out int size) || size < 1 || size > 20)
                throw new ArgumentException("Number of objects must be between 1 and 20.");

            double[] heights = new double[size];
            Console.WriteLine($"Enter {size} object heights in meters:");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"  Height {i + 1}: ");
                string? input = Console.ReadLine();

                if (!double.TryParse(input, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out double value) || value <= 0)
                {
                    throw new ArgumentException($"Height must be a positive number.");
                }

                heights[i] = value;
            }

            return heights;
        }
    }
}
