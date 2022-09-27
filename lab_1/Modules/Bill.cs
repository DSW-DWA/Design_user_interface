namespace Lab1
{
    class Bill : Document
    {
        private double sumOfBill = 0;
        public Bill(string? number, string? name, string? man) : base(number, name, man) {  }
        public Bill() : base() {}
        public double SUM
        {
            get { return sumOfBill; }
            set { sumOfBill = value; }
        }

        public void AddMoney(int money)
        {
            if (money < 15) Console.WriteLine("мин. сумма взноса 15$");
            else SUM += money;
        }
        public void Info()
        {
            Console.WriteLine("Наименование документа: Cчет");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Размер счета: " + SUM + "$");
        }
        public void ProcentOfYear(int years, double pr)
        {
            SUM = SUM * Math.Pow((1 + pr / 100), years); 
        }
        public override void AddRecipient(string? t)
        {
            base.AddRecipient(t);    
        }

    }
}