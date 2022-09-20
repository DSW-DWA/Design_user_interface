using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите степень первого уровнения");
            var ex1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коэффициенты первого уровнения");
            List<double> coff1 = new List<double>();
            for (int i =0 ; i <= ex1; i++)
            {
                coff1.Add(Convert.ToDouble(Console.ReadLine()));
            }
            Polynomial pol1 = new Polynomial(ex1, coff1);

            Console.WriteLine("Введите степень второго уровнения");
            var ex2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коэффициенты второго уровнения");
            List<double> coff2 = new List<double>();
            for (int i =0 ; i <= ex2; i++)
            {
                coff2.Add(Convert.ToDouble(Console.ReadLine()));
            }
            Polynomial pol2 = new Polynomial(ex1, coff1);

            Console.WriteLine(pol1.CalculateValue(2.5));
            Console.WriteLine(pol1.ReturnCoefficient(1));
            Console.WriteLine("-------------------------");
            Console.WriteLine(pol1.ReturnPolynomial());
            Console.WriteLine(pol2.ReturnPolynomial());
            Console.WriteLine("-------------------------");
            var builder = new PolynomialBuilder();
            Console.WriteLine(builder.Sum(pol1,pol2).ReturnPolynomial());
            Console.WriteLine(builder.Sub(pol1,pol2).ReturnPolynomial());
            Console.WriteLine(builder.Mul(pol1,pol2).ReturnPolynomial());
        }
    }
}
