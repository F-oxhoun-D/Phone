namespace Phone
{
    internal class Program
    {
        const string pathSerXML = "serialize.xml";

        static void Load()
        {
            if (File.Exists(pathSerXML))
                PhoneBook.PhonesBook = Deserializer.Deserialize(pathSerXML);
        }

        static void Main()
        {
            Load();
            ShowMenu();

            bool run = true;
            int menu;

            while (run)
            {
                Console.Write("#> ");
                while (!int.TryParse(Console.ReadLine(), out menu))
                    Console.Write("Введите число: ");

                switch (menu)
                {
                    case 1:
                        PhoneHandler.Add();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Введите номер, в который нужно внести правки: ");
                        string number = string.Join("", Console.ReadLine()!.Split(" ",
                            StringSplitOptions.RemoveEmptyEntries));
                        PhoneHandler.Edit(number);
                        Console.WriteLine("Изменения внесены");
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Введите номер, который нужно удалить: ");
                        number = string.Join("", Console.ReadLine()!.Split(" ",
                            StringSplitOptions.RemoveEmptyEntries));
                        PhoneHandler.Delete(number);
                        Console.WriteLine("Номер удалён");
                        Console.WriteLine();
                        break;
                    case 4:
                        PhoneHandler.Show();
                        Console.WriteLine();
                        break;
                    case 5:
                        Serializer.Serialize(PhoneBook.PhonesBook, pathSerXML);
                        Console.WriteLine("Сеанс сохранён");
                        Console.WriteLine();
                        break;
                    case 6:
                        run = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\t Меню");
            Console.WriteLine("1. Добавить номер");
            Console.WriteLine("2. Изменить номер");
            Console.WriteLine("3. Удалить номер");
            Console.WriteLine("4. Вывести список номеров");
            Console.WriteLine("5. Сохранить сеанс");
            Console.WriteLine("6. Выход");
            Console.WriteLine();
        }
    }
}
