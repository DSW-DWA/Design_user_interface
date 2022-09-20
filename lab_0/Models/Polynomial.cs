

namespace Lab1 {
    public class Polynomial
    {
        private int _maxExtent {get; set;}
        public int MaxExtent
        {
            set
            {
                if (value > 0) 
                {
                    this._maxExtent = value;
                    Monomials = new List<Monomial>();
                } 
                else this._maxExtent = 0;
            }
            get
            {
                return this._maxExtent;
            }
        }
        public Polynomial(int maxExtent){
            MaxExtent = maxExtent;
        }
        public Polynomial(int maxExtent, List<double> coefficients){
            MaxExtent = maxExtent;
            Monomials = new List<Monomial>();
            coefficients.ForEach(x => {
                Monomials.Add(new Monomial(x, Math.Max(maxExtent,0) ));
                maxExtent--;
            });
        }
        public double CalculateValue(double argument){
            double sum = 0;
            Monomials.ForEach(x => {
                sum += Math.Pow(argument,x.Extent)*x.Ratio;
            });
            return sum;
        }
        public double ReturnCoefficient(int ind){
            if (ind > (Monomials.Count -1)) return 0;
            return Monomials[ind].Ratio;
        }
        public string ReturnPolynomial() {
            string pol = "";
            Monomials.ForEach(x =>{
                string el = "";
                if (x.Ratio > 0 && pol != "") el = el + "+" + x.Ratio;
                if (x.Ratio < 0) el = el + x.Ratio;
                if (x.Extent != 0 && x.Ratio !=0) el = el + "x^" + x.Extent;
                pol = pol + el;
            });
            return pol;
        }
        public List<Monomial> Monomials { get; set; }
    }
}