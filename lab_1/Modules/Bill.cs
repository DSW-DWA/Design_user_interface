namespace Lab1
{
    class Bill : Document
    {
        private double _sum = 0;
        public Bill(string? number, string? name, string? rec) : base(number, name, rec) {  }
        public Bill() : base() {}
        public double SUM
        {
            get { return _sum; }
            set { _sum = value; }
        }

        public void ChangeMoney(double money)
        {
            SUM += money;
        }
        public void PercentOfYear(int years, double pr)
        {
            SUM = SUM * Math.Pow((1 + pr / 100), years); 
        }
        public override void Info()
        {
            Console.WriteLine("Наименование документа: Cчет");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Размер счета: " + SUM + "$");
        }
    }
}