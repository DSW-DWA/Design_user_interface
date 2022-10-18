namespace Lab1
{
    class Receipt : Document
    {
        private double _cost = 0;
        public Receipt(string? number, string? name, string? man) : base(number, name, man) {  }
        public Receipt() : base() {}
        public double COST
        {
            get { if (_cost > 0) return _cost; else return 0; }
            set 
            { 
                _cost += value;
                if (_cost < 0 ) _cost = 0;
            }
        }
        public override void Info()
        {
            Console.WriteLine("Наименование документа: Рассписка");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Стоимость рассписки: " + _cost + "$");
        }

        public void AddRecipientPercent(double r)
        {
            _cost = _cost * (1 + (r / 100));
        }
    }
}