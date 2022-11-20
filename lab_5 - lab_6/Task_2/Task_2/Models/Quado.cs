using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models
{
    public class Quado
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double d { get {  return (B * B) + (-4 * A * C); } }

        public Quado() 
        { 
            A = 1; 
            B = 1; 
            C = 1; 
        }
        public Quado(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public virtual double[]? Solve()
        {
            if (d < 0) return null ;
            if (d == 0) return new double[] {(-1*B / (2 * A))};

            double x1 = (-1*B + Math.Sqrt(d)) / (2 * A);
            double x2 = (-1*B - Math.Sqrt(d)) / (2 * A);
            return new double[] { x1, x2 };
        }
        public override string ToString()
        {
            var ans = Solve();
            if (ans == null) return "Нет решений";
            if (ans.Count() == 1) return $"{ans[0]}";
            return $"{Math.Round(ans[0],3)}; {Math.Round(ans[1],3)}";
        }
    }
}
