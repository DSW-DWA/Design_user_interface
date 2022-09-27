namespace Lab1
{
    interface Paper 
    {
        void Change();
    }
    interface Pen 
    {
        void Change();
    }
    delegate void WriteSome();

    abstract class Document: Paper, Pen
    {
        private int _faceNum = 2;
        public int faceNum 
        {
            get { return _faceNum;}
            set { _faceNum = value;} 
        }
        WriteSome? writeOnPaperUsePen;
        void Writing() 
        {
            Paper newspaper = (Paper)this;
            writeOnPaperUsePen = newspaper.Change;
            writeOnPaperUsePen += Tmp;
        } 
        void Paper.Change()
        {
            Console.WriteLine("Вы что-то изменили, интерфейс Paper");
        }
        void Pen.Change() 
        {
            Console.WriteLine("Вы что-то изменили, интерфейс Pen");
        }
        private string? Recipient;
        public string? RECIPIENT
        {
            get { return Recipient; }
            set { if (value?.Length > 0) Recipient = value; else Recipient = "none"; }

        }
        public string? Man { get; }
        public string? Number { get;  }
        public string? Name { get; }
        public Document(string? number, string? officename, string? man)
        {
            Number = number;
            Name = officename;
            Man = man;
            Writing();
            if (writeOnPaperUsePen != null) writeOnPaperUsePen();
        }
        public Document(){
            Number = "Не указан";
            Name = "Не указан";
            Man = "Не указан";
            Writing();
            if (writeOnPaperUsePen != null)writeOnPaperUsePen();
        }
        public override string ToString()
        {
            Console.WriteLine($"Номер документа: {Number}");
            Console.WriteLine($"Название офисса: {Name}");
            return $"Номер документа: {Number}"+$"\nНазвание офисса: {Name}";
        }
        public virtual void AddRecipient(string? t)
        {

            if (RECIPIENT == "none") RECIPIENT = t;
            else RECIPIENT = RECIPIENT + ", " + t;
        }
        public void Tmp(){
            Console.WriteLine("Просто существует...");
        }
    }
}