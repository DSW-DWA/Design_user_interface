namespace Lab1
{
    abstract class Document
    {
        private string? _recipient;
        public string? RECIPIENT
        {
            get { return _recipient; }
            set { _recipient += value; }

        }
        private string? _number { get;  }
        private string? _name { get; }
        public Document(string? number, string? officeName, string? rec)
        {
            _number = number ?? "Не указан";
            _name = officeName ?? "Не указан";
            RECIPIENT = rec ?? "Не указан"; 
        }
        public Document(){
            _number = "Не указан";
            _name = "Не указан";
            RECIPIENT = "Не указан";
        }
        public override string ToString()
        {
            Console.WriteLine($"Номер документа: {_number}");
            Console.WriteLine($"Название офисса: {_name}");
            return $"Номер документа: {_number}"+$"\nНазвание офисса: {_name}";
        }
        public virtual void AddRecipient(string? t)
        {
            if (RECIPIENT == "Не указан") RECIPIENT = t;
            RECIPIENT = RECIPIENT + ", " + t;
        }
        public virtual void Info()
        {}
    }
}