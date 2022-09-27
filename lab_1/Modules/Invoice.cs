namespace Lab1
{
    class Invoice : Document
    {
        
        private List<string> itemName = new List<string> {};
        private List<int> itemCount = new List<int> {};
        private int _numOfItem  = 0;
        public int NumOfItem 
        {
            get { return _numOfItem; }
            set { if (value >= 0) _numOfItem = value; else _numOfItem = 0;} 
        }
        public Invoice(string? number, string? name, string? man) : base(number, name, man) {}
        public Invoice() : base() {}
        
        public void Info()
        {
            Console.WriteLine("Наименование документа: Накладная");
            ToString();
            Console.WriteLine("Получитель: " + RECIPIENT);
            Console.WriteLine("Содержит: ");
            if (itemName.Count == 0) Console.WriteLine("Нечего");
            else
            {
                for (int i = 0; i < itemName.Count; i++)
                {
                    Console.WriteLine(itemName[i] + " в колл-ве " + itemCount[i]);
                }
            }
        }
        public void AddItem(string? name,int num)
        {
            if (name != null) itemName.Add(name);
            itemCount.Add(num);
            NumOfItem ++;
        }
        public void DeletItem(int ind)
        {
            ind--;
            itemName.RemoveAt(ind);
            itemCount.RemoveAt(ind);
            NumOfItem --;
        }
        public void ChangeItemCount(int ind, int count)
        {
            ind--;
            itemCount[ind] = count;
        }
        public override void AddRecipient(string? t)
        {
            base.AddRecipient(t);    
        }
        
    }
}