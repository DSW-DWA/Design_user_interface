namespace Lab1
{
    public class PolynomialBuilder
    {
        public Polynomial Sum(Polynomial p1, Polynomial p2)
        {
            var pAnswer = p1.MaxExtent >= p2.MaxExtent ? p1: p2;
            var pHelp = p1.MaxExtent < p2.MaxExtent ? p1: p2;
            pAnswer.Monomials.ForEach(x => 
            {
                var tmp = pHelp.Monomials.Where(xx => xx.Extent == x.Extent).ToList();
                tmp.ForEach(xx => x.Ratio += xx.Ratio);
            });
            return pAnswer;
        }
        public Polynomial Sub(Polynomial p1, Polynomial p2)
        {
            var pAnswer = p1.MaxExtent >= p2.MaxExtent ? p1: p2;
            var pHelp = p1.MaxExtent < p2.MaxExtent ? p1: p2;
            pAnswer.Monomials.ForEach(x => 
            {
                var tmp = pHelp.Monomials.Where(xx => xx.Extent == x.Extent).ToList();
                tmp.ForEach(xx => x.Ratio -= xx.Ratio);
            });
            return pAnswer;
        }
        public Polynomial Mul(Polynomial p1, Polynomial p2)
        {
            var pAnswer = new Polynomial(p1.MaxExtent*p2.MaxExtent);
            p1.Monomials.ForEach(x => p2.Monomials.ForEach(xx => 
            {
                if (pAnswer.Monomials.Where(xxx => xxx.Extent == xx.Extent*x.Extent).Count() > 0) 
                {
                    pAnswer.Monomials.Where(xxx => xxx.Extent == xx.Extent*x.Extent).Select(v => v.Ratio+=xx.Ratio*x.Ratio);
                } 
                else 
                {
                    pAnswer.Monomials.Add(new Monomial(xx.Ratio*x.Ratio,xx.Extent*x.Extent));
                }
            }));
            return pAnswer;
        }
    }
}