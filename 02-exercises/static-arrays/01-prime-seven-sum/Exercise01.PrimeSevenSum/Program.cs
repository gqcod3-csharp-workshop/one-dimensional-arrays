
namespace Exercise01.PrimeSevenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the starting value: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter the ending value: ");
            int end = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i) && i % 10 == 7)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"\nSum of prime numbers ending in 7: {sum}");
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
