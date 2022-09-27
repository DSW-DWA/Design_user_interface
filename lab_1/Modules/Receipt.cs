namespace Lab1
{
    class Receipt : Document
    {
        private double cost = 100.0;
        public Receipt(string? number, string? name, string? man) : base(number, name, man) {  }
        public Receipt() : base() {}
        public double COST
        {
            get { return cost; }
            set { if (value > 0) cost = value; else cost = 100.0; }

        }
        public void Info()
        {
            Console.WriteLine("Наименование документа: Рассписка");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Стоимость рассписки: " + cost + "$");
        }

        public void AddRecipientProcent(double? r)
        {
            if ( r != null) COST = cost * (1 + (Convert.ToDouble(r) / 100));
            else COST = 0;
        }
        public override void AddRecipient(string? t)
        {
            base.AddRecipient(t);    
            Console.WriteLine("Это овверайтый вирутальный метод");
        }
    }
}