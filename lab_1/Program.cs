namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Document> list = new List<Document>();
                list.Add(new Receipt("12443", "ФСИН", "Андрей"));
                list.Add(new Invoice("23427", "ФЭС", "Aнтон"));
                list.Add(new Bill("324223", "Почта Банк", "Александр"));
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
                        string? num = Console.ReadLine();
                        Console.WriteLine("Введите имя офиса от которого был получен документ");
                        string? office = Console.ReadLine();
                        Console.WriteLine("Введите имя получателя");
                        string? name = Console.ReadLine();
                        if (s1 == "1") list.Add(new Receipt(num, office, name));
                        if (s1 == "2") list.Add(new Invoice(num, office, name));
                        if (s1 == "3") list.Add(new Bill(num, office, name));
                    }
                    if (s == "2")
                    {
                        Console.WriteLine("Введите номер элемента, который вы хотите удалить");
                        string? s1 = Console.ReadLine();
                        int ind = Convert.ToInt32(s1);
                        list.RemoveAt(ind - 1);
                        Console.WriteLine($"Длинна списка теперь {list.Count()}");
                    }
                    if (s == "3")
                    {
                        for (int i = 0; i < list.Count(); i++)
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
                        }
                    }
                    if (s == "4")
                    {
                        Console.WriteLine("Введите номер элемента c котрым вы хотите работать");
                        var ind = Convert.ToInt32(Console.ReadLine()) - 1;
                        var item = list[ind];
                        if (item is Receipt)
                        {
                            Receipt receipt = (Receipt)item;
                            Console.WriteLine("Что вы хотите сделать(введите цифру)? \n1)Добавить получателя \n2)Увеличить сумму на процент \n3)Увидеть полную информацию \n4)Добавить или отнять сумму");
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
                                receipt.AddRecipientPercent(r);
                            }
                            if (s1 == "3")
                            {
                                receipt.Info();
                            }
                            if (s1 == "4")
                            {
                                Console.WriteLine("Введите сумму с + если хотите прибавить и с - если хотите отнять");
                                var s2 = Convert.ToDouble(Console.ReadLine());
                                receipt.COST = s2;
                            }
                        }
                        if (item is Invoice)
                        {
                            Invoice invoice = (Invoice)item;
                            Console.WriteLine("Что вы хотите сделать(введите цифру)? \n1)Добавить объект в накладную \n2)Удалить объект из накладной \n3)Изменить колл-во объкта в накладной \n4)Добавить получателя \n5)Увидеть полную информацию");
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
                                invoice.DeleteItem(Convert.ToInt32(t) - 1);
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
                            Console.WriteLine("Что вы хотите сделать(введите цифру)? \n1)Добавить получателя \n2)Пересчитать сумму на N колл-во лет и R процент \n3)Изменеть сумму \n4)Увидеть полную информацию");
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
                                bill.PercentOfYear(Convert.ToInt32(year), Convert.ToDouble(pr));
                            }
                            if (s1 == "3")
                            {
                                Console.WriteLine("Введите сумму с + если хотите прибавить и с - если хотите отнять");
                                string? mon = Console.ReadLine();
                                bill.ChangeMoney(Convert.ToDouble(mon));
                            }
                            if (s1 == "4")
                            {
                                bill.Info();
                            }
                        }
                    }
                    if (s == "5")
                    {
                        Console.WriteLine("Выберите:\n1)по верхней границе суммы счета или стоимости \n2)Колличество объектов в рассписке \n3)По имени получателя");
                        int? r = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите значение");
                        var tmp = Console.ReadLine();
                        if (r == 1)
                        {
                            var tmp1 = Convert.ToDouble(tmp);
                            for (int i = 0; i < list.Count(); i++)
                            {
                                if (list[i] is Receipt)
                                {
                                    Receipt receipt = (Receipt)list[i];
                                    if (receipt.COST <= tmp1) receipt.Info();
                                }
                                if (list[i] is Bill)
                                {
                                    Bill bill = (Bill)list[i];
                                    if (bill.SUM <= tmp1) bill.Info();
                                }
                            }
                        }
                        if (r == 2)
                        {
                            var tmp1 = Convert.ToInt32(tmp);
                            for (int i = 0; i < list.Count(); i++)
                            {
                                if (list[i] is Invoice)
                                {
                                    Invoice invoice = (Invoice)list[i];
                                    if (invoice.NumOfItem == tmp1) invoice.Info();
                                }
                            }
                        }
                        if (r == 3)
                        {
                            for (int i = 0; i < list.Count(); i ++)
                            {
                                if (list[i].RECIPIENT.ToLower().Contains(tmp.ToLower()))
                                {
                                    list[i].Info();
                                }
                            }
                        }
                    }
                    Console.WriteLine("----------------------------------------------");
                }
            }
            catch
            {
                Console.WriteLine("Вы ввели некорректное значение, попробуйте снова");
            }
        }
    }
}
