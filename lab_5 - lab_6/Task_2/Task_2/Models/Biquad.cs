using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace Task_2.Models
{
    public class Biquad : Quado
    {
        public Biquad() : base() {}
        public Biquad(double a, double b, double c) : base(a, b, c) { }
        public double[]? SolveBiqud()
        {
            var ans = Solve();
            var biquadAnswer = new List<double>();
            if (ans == null) return null;
            foreach (var value in ans)
            {
                if (value > 0)
                {
                    if (value == 0)
                    {
                        biquadAnswer.Add(0);
                    }
                    else
                    {
                        biquadAnswer.Add(Math.Sqrt(value));
                        biquadAnswer.Add(-1*Math.Sqrt(value));
                    }
                }
            }
            if (biquadAnswer.Count == 0) return null;
            return biquadAnswer.ToArray();
        }
        public override string ToString()
        {
            var ans = SolveBiqud();
            var str = "";
            if (ans == null) return "Нет решений";
            foreach ( var item in ans)
            {
                str += $"{Math.Round(item,3)};";
            }
            return str;
        }
    }
}
