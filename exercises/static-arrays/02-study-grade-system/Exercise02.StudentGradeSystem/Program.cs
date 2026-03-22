namespace Exercise02.StudentGradeSystem
{
    public class Course
    {
        private double[] grades;
        private const double PassingGrade = 6.0;

        public Course(int studentCount)
        {
            grades = new double[studentCount];
        }

        public void InputGrades()
        {
            Console.WriteLine($"=== Grade Input System ===\n");
            
            for (int i = 0; i < grades.Length; i++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    double grade;
                    Console.Write($"Enter grade for student {i + 1}: ");
                    
                    if (double.TryParse(Console.ReadLine(), out grade))
                    {
                        if (grade >= 0 && grade <= 10)
                        {
                            grades[i] = grade;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade. Please enter a value between 0 and 10.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a numeric value.\n");
                    }
                }
            }
        }

        public void DisplayGrades()
        {
            Console.Write("Registered Grades: ");
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write(grades[i]);
                if (i < grades.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public double CalculateAverage()
        {
            double sum = 0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return sum / grades.Length;
        }

        public double GetHighestGrade()
        {
            double highest = grades[0];
            foreach (double grade in grades)
            {
                if (grade > highest)
                    highest = grade;
            }
            return highest;
        }

        public double GetLowestGrade()
        {
            double lowest = grades[0];
            foreach (double grade in grades)
            {
                if (grade < lowest)
                    lowest = grade;
            }
            return lowest;
        }

        public int CountPassedStudents()
        {
            int count = 0;
            foreach (double grade in grades)
            {
                if (grade >= PassingGrade)
                    count++;
            }
            return count;
        }

        public int CountFailedStudents()
        {
            int count = 0;
            foreach (double grade in grades)
            {
                if (grade < PassingGrade)
                    count++;
            }
            return count;
        }

        public void DisplayReport()
        {
            Console.WriteLine("\n=== Grade Report ===\n");
            
            DisplayGrades();
            Console.WriteLine($"Overall Average: {CalculateAverage():F2}");
            Console.WriteLine($"Highest Grade: {GetHighestGrade():F1}");
            Console.WriteLine($"Lowest Grade: {GetLowestGrade():F1}");
            Console.WriteLine($"Students Passed: {CountPassedStudents()}");
            Console.WriteLine($"Students Failed: {CountFailedStudents()}");
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
