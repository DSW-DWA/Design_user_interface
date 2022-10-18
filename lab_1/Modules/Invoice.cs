namespace Lab1
{
    class Invoice : Document
    {
        
        private List<string> _itemName = new List<string> {};
        private List<int> _itemCount = new List<int> {};
        private int _numOfItem  = 0;
        public int NumOfItem 
        {
            get { if (_numOfItem < 0) return 0; else return _numOfItem;  }
        }
        public Invoice(string? number, string? name, string? man) : base(number, name, man) {}
        public Invoice() : base() {}
        public void AddItem(string name, int num)
        {
            _itemName.Add(name);
            _itemCount.Add(num);
            _numOfItem += num;
        }
        public void DeleteItem(int ind)
        {
            ind--;
            _itemName.RemoveAt(ind);
            _numOfItem -= _itemCount[ind];
            _itemCount.RemoveAt(ind);
        }
        public void ChangeItemCount(int ind, int count)
        {
            ind--;
            _numOfItem -= _itemCount[ind];
            _itemCount[ind] = count;
            _numOfItem += _itemCount[ind];
        }
        public override void Info()
        {
            Console.WriteLine("Наименование документа: Накладная");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Содержит: ");
            if (_itemName.Count == 0) Console.WriteLine("Нечего");
            else
            {
                for (int i = 0; i < _itemName.Count; i++)
                {
                    Console.WriteLine(_itemName[i] + " в колл-ве " + _itemCount[i]);
                }
            }
            Console.WriteLine($"Колл-во элементов {NumOfItem}");
        }
    }
}