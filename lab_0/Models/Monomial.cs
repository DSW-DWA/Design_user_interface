namespace Lab0
{
    public class Monomial
    {
        public Monomial()
        {
            Ratio = 1;
            Extent = 0;
        }
        public Monomial(double ratio, int extent)
        {
            Ratio = ratio;
            Extent = extent;
        }
        public double Ratio { get; set; }
        
        private int _extent { get; set; }
        public int Extent
        {
            get
            {
                return this._extent;
            }
            set
            {
                if (value > 0) this._extent = value; else this._extent = 0;
            }
        }
    }
}