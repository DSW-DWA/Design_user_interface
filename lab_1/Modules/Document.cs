using System.Diagnostics.Contracts;
using System.Reflection.Emit;
namespace Lab1
{
    delegate void Create();
    abstract class Document : IPen, IPaper
    {
        private string? _recipient;
        public string? RECIPIENT
        {
            get { return _recipient; }
            set { _recipient += value; }

        }
        private void _create() => Console.WriteLine("Вы создали документ");
        private void _doSmt() => Console.WriteLine("Что-то делает");
        public int LoveScale { get; set; }
        private string? _number { get;  }
        private string? _name { get; }
        public Document(string? number, string? officeName, string? rec)
        {
            _number = number ?? "Не указан";
            _name = officeName ?? "Не указан";
            RECIPIENT = rec ?? "Не указан"; 
            Create doc = _create;
            doc();
        }
        public Document(){
            _number = "Не указан";
            _name = "Не указан";
            RECIPIENT = "Не указан";
            Create doc = _create;
            doc();
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
            RECIPIENT = ", " + t;
        }
        public virtual void Info()
        {}

        public void WriteSomething(string smt)
        {
            Console.WriteLine($"Вы написали {smt}, ручкой на листке");
        }

        public void DestroyPaper()
        {
            Console.WriteLine("Вы порвали листок");
        }
        
        public void DestroyPen()
        {
            Console.WriteLine("Вы сломали ручку");
        }
    }
}