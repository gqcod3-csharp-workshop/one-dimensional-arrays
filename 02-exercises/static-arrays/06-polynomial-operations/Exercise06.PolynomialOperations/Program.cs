using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise06.PolynomialOperations
{
    public class Polynomial
    {
        private double[] coefficients;
        
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null || coefficients.Length == 0)
            {
                throw new ArgumentException("Coefficients array cannot be null or empty.");
            }
            this.coefficients = coefficients;
        }
        
        public Polynomial Add(Polynomial other)
        {
            int maxLength = Math.Max(this.coefficients.Length, other.coefficients.Length);
            double[] result = new double[maxLength];
            
            for (int i = 0; i < maxLength; i++)
            {
                double coef1 = (i < this.coefficients.Length) ? this.coefficients[i] : 0;
                double coef2 = (i < other.coefficients.Length) ? other.coefficients[i] : 0;
                result[i] = coef1 + coef2;
            }
            
            return new Polynomial(result);
        }
        
        public override string ToString()
        {
            List<string> terms = new List<string>();
            
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                double coef = coefficients[i];
                
                if (coef == 0) continue;
                
                string term = "";
                
                if (coef > 0 && terms.Count > 0)
                    term += "+ ";
                else if (coef < 0)
                    term += "- ";
                
                double absCoef = Math.Abs(coef);
                if (i == 0 || absCoef != 1)
                    term += absCoef;
                else if (terms.Count == 0 && absCoef == 1)
                    term += "";
                
                if (i > 0)
                {
                    term += "x";
                    if (i > 1)
                        term += "^" + i;
                }
                
                terms.Add(term);
            }
            
            return terms.Count > 0 ? string.Join(" ", terms) : "0";
        }
    }
    
    class Program
    {
        static void Main()
        {    
            try
            {
                Console.WriteLine("\nEnter the first polynomial:");
                double[] poly1 = ReadPolynomial();
                
                Console.WriteLine("\nEnter the second polynomial:");
                double[] poly2 = ReadPolynomial();
                
                Polynomial polynomial1 = new Polynomial(poly1);
                Polynomial polynomial2 = new Polynomial(poly2);
                
                Console.WriteLine("\nPolynomial 1: " + polynomial1);
                Console.WriteLine("Polynomial 2: " + polynomial2);
                
                Polynomial sum = polynomial1.Add(polynomial2);
                Console.WriteLine("\nSum Result: " + sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        static double[] ReadPolynomial()
        {
            Console.Write("Enter the degree of the polynomial (0-10): ");
            string? degreeInput = Console.ReadLine();
            
            if (!int.TryParse(degreeInput, out int degree) || degree < 0 || degree > 10)
            {
                throw new ArgumentException("Degree must be between 0 and 10.");
            }
            
            double[] coefficients = new double[degree + 1];
            Console.WriteLine($"Enter {degree + 1} coefficients (from constant term to x^{degree}):");
            
            for (int i = 0; i <= degree; i++)
            {
                Console.Write($"  Coefficient of x^{i}: ");
                string? coefInput = Console.ReadLine();
                
                if (!double.TryParse(coefInput, out double coef))
                {
                    throw new ArgumentException("Invalid coefficient value.");
                }
                
                coefficients[i] = coef;
            }
            
            return coefficients;
        }
    }
}
