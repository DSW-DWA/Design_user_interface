namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Document> list = new List<Document>();
            list.Add(new Receipt("12443", "ФСИН", "Андрей"));
            list.Add(new Invoice("23427", "ФЭС", "Aнтон"));
            list.Add(new Bill("324223", "Почта Банк", "Александр"));
            int listLength = 3;
            for (int i =0; i<3; i++)
            {
                if (list[i] is Receipt)
                {
                    Receipt receipt = (Receipt)list[i];
                    receipt.Info();
                    Console.WriteLine();
                    receipt.AddRecipientProcent(12.5);
                    receipt.AddRecipient("Артем");
                    receipt.Info();
                }
                if (list[i] is Invoice)
                {
                    Invoice invoice = (Invoice)list[i];
                    invoice.Info();
                    Console.WriteLine();
                    invoice.AddItem("Ящик бананов", 15);
                    invoice.AddItem("Ящик помидоров", 20);
                    invoice.AddItem("Ящик хлеба", 3);
                    invoice.Info();
                    Console.WriteLine();
                    invoice.DeletItem(2);
                    invoice.ChangeItemCount(1, 30);
                    invoice.AddRecipient("Семен");
                    invoice.Info();
                }
                if (list[i] is Bill)
                {
                    Bill bill = (Bill)list[i];
                    bill.Info();
                    Console.WriteLine();
                    bill.AddMoney(75);
                    bill.ProcentOfYear(3, 10.0);
                    bill.AddRecipient("Павел");
                    bill.Info();
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
            string? s = "1";
            while (s != "0")
            {
                Console.WriteLine("Возможности работы(введите цифру):\n0)Выход \n1)Добавить элемент \n2)Удалить элемент \n3)Вывести весь список \n4)Работа с объектом\n5)Поиск по списку");
                s = Convert.ToString(Console.ReadLine());
                if (s == "1")
                {
                    Console.WriteLine("Какой элемент добавить(введите цифру): 1)Рассписка 2)Накладная 3)Счет");
                    string? s1 = Console.ReadLine();
                    Console.WriteLine("Введите номер документа");
                    string? nmbr = Console.ReadLine();
                    Console.WriteLine("Введите имя офиса от которого был получен документ");
                    string? office = Console.ReadLine();
                    Console.WriteLine("Введите имя получателя");
                    string? name = Console.ReadLine();
                    if (s1 == "1") list.Add(new Receipt(nmbr, office, name));
                    if (s1 == "2") list.Add(new Invoice(nmbr, office, name));
                    if (s1 == "3") list.Add(new Bill(nmbr, office, name));
                    listLength += 1;
                }
                if (s == "2")
                {
                    Console.WriteLine("Введите номер элемента, который вы хотите удалить");
                    string? s1 = Console.ReadLine();
                    int ind = Convert.ToInt32(s1);
                    list.RemoveAt(ind - 1);
                }
                if (s == "3")
                {
                    for (int i =0; i<listLength ; i++)
                    {
                        if (list[i] is Receipt)
                        {
                            Receipt receipt = (Receipt)list[i];
                            receipt.Info();
                            Console.WriteLine();
                        } else if (list[i] is Invoice)
                        {
                            Invoice invoice = (Invoice)list[i];
                            invoice.Info();
                            Console.WriteLine();
                        } else if (list[i] is Bill)
                        {
                            Bill bill = (Bill)list[i];
                            bill.Info();
                            Console.WriteLine();
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------");
                    }
                }
                if (s == "4")
                {
                    Console.WriteLine("Введите номер элемента c котрым вы хотите работать");
                    string? tmp = Console.ReadLine();
                    int ind = Convert.ToInt32(tmp);
                    ind--;
                    var item = list[ind];
                    if (item is Receipt)
                    {
                        Receipt receipt = (Receipt)item;
                        Console.WriteLine("Что вы хотите сделать(введите цифру)? 1)Добавить получателя 2)Увеличить сумму на процент 3)Увидеть полную информацию");
                        string? s1 = Console.ReadLine();
                        if (s1 == "1")
                        {
                            Console.WriteLine("Выведите имя получателя");
                            string? s2 = Console.ReadLine();
                            receipt.AddRecipient(s2);
                        }
                        if (s1 == "2")
                        {
                            Console.WriteLine("Введите процент");
                            string? s2 = Console.ReadLine();
                            var r = Convert.ToDouble(s2);
                            receipt.AddRecipientProcent(r);
                        }
                        if (s1 == "3")
                        {
                            receipt.Info();
                        }
                    }
                    if (item is Invoice)
                    {
                        Invoice invoice = (Invoice)item;
                        Console.WriteLine("Что вы хотите сделать(введите цифру)? 1)Добавить объект в накладную 2)Удалить объект из накладной 3)Изменить колл-во объкта в накладной 4)Добавить получателя 5)Увидеть полную информацию");
                        string? s1 = Console.ReadLine();
                        if (s1 == "1")
                        {
                            Console.WriteLine("Введите название объекта");
                            string? name = Console.ReadLine();
                            Console.WriteLine("Введите колл-во объекта");
                            string? count = Console.ReadLine();
                            invoice.AddItem(name, Convert.ToInt32(count));
                        }
                        if (s1 == "2")
                        {
                            Console.WriteLine("Введите номер объекта");
                            string? t = Console.ReadLine();
                            invoice.DeletItem(Convert.ToInt32(t)-1);
                        }
                        if (s1 == "3")
                        {
                            Console.WriteLine("Введите номер объекта");
                            string? t = Console.ReadLine();
                            Console.WriteLine("Введите колл-во объекта");
                            string? t1 = Console.ReadLine();
                            invoice.ChangeItemCount(Convert.ToInt32(t) - 1, Convert.ToInt32(t1));
                        }
                        if (s1 == "4")
                        {
                            Console.WriteLine("Выведите имя получателя");
                            string? s2 = Console.ReadLine();
                            invoice.AddRecipient(s2);
                        }
                        if (s1 == "5")
                        {
                            invoice.Info();
                        }
                    }   
                    if (item is Bill)
                    {
                        Bill bill = (Bill)item;
                        Console.WriteLine("Что вы хотите сделать(введите цифру)? 1)Добавить получателя 2)Пересчитать сумму на N колл-во лет и R процент 3)Добавить деньги 4)Увидеть полную информацию");
                        string? s1 = Console.ReadLine();
                        if (s1 == "1")
                        {
                            Console.WriteLine("Выведите имя получателя");
                            string? s2 = Console.ReadLine();
                            bill.AddRecipient(s2);
                        }
                        if (s1 == "2")
                        {
                            Console.WriteLine("Введите колл-во лет");
                            string? year = Console.ReadLine();
                            Console.WriteLine("Введите процент");
                            string? pr = Console.ReadLine();
                            bill.ProcentOfYear(Convert.ToInt32(year), Convert.ToDouble(pr));
                        }
                        if (s1 == "3")
                        {
                            Console.WriteLine("Введите сумму");
                            string? mon = Console.ReadLine();
                            bill.AddMoney(Convert.ToInt32(mon));
                        }
                        if (s1 == "4")
                        {
                            bill.Info();
                        }
                    }
                }
                if (s == "5")
                {
                    Console.WriteLine("Выберите:\n1)сумма счета или стоимость \n2)Колличество итемов или интрефейсов");
                    int? r = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите значение");
                    int? tmp = Convert.ToInt32(Console.ReadLine());
                    if (r == 1)
                    {
                        for (int i =0;i <3; i++)
                        {
                            if (list[i] is Receipt)
                            {
                                Receipt receipt = (Receipt)list[i];
                                if (receipt.COST == tmp) receipt.Info();
                            }
                            if  (list[i] is Bill)
                            {
                                Bill bill = (Bill)list[i];
                                if (bill.SUM == tmp) bill.Info();
                            }
                        }
                    }
                    if (r == 2)
                    {
                        for (int i =0;i <3; i++)
                        {
                            if (list[i] is Invoice)
                            {
                                Invoice invoice = (Invoice)list[i];
                                if (invoice.NumOfItem == tmp) invoice.Info();
                            }
                            if (list[i].faceNum == tmp) {
                                if (list[i] is Invoice)
                                {
                                    Invoice invoice = (Invoice)list[i];
                                    invoice.Info();
                                } else 
                                if (list[i] is Receipt)
                                {
                                    Receipt receipt = (Receipt)list[i];
                                    receipt.Info();
                                } else 
                                if  (list[i] is Bill)
                                {
                                    Bill bill = (Bill)list[i];
                                    bill.Info();
                                }
                            };
                        }
                    }
                }
                Console.WriteLine("----------------------------------------------");
            }
        }
    }
}
