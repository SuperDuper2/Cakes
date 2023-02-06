using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Program
    {
        public static string descritpion = " ";
        public static int page = 0;
        public static void Entering(ConsoleKeyInfo key, int positon, int page)
        {
            SubItem forms = new SubItem();
            forms.items = new[] { "Круг - 500", "Квадрат - 500", "Прямоугольник - 500", "Сердечко - 700" };
            forms.cost = new[] { 500, 500, 500, 700 };
            SubItem sizes = new SubItem();
            sizes.items = new[]
            {
                "Маленький (Диаметр - 16 см, 8 порций) - 1000", "Обычный (Диаметр - 18 см, 10 порций) - 1200",
                "Большой (Диаметр - 28 см, 24 порций) - 2000"
            };
            sizes.cost = new[] { 1000, 1200, 2000 };
            SubItem taste = new SubItem();
            taste.items = new[]
                { "Ванильный - 100", "Шоколадный - 100", "Кармаельный - 150", "Ягодный - 200", "Кокосовый - 250" };
            taste.cost = new[] { 100, 100, 150, 200, 250 };
            SubItem amount = new SubItem();
            amount.items = new[] { "1 корж - 200", "2 коржа - 400", "3 коржа - 600", "4 коржа - 800" };
            amount.cost = new[] { 200, 400, 600, 800 };
            SubItem glaze = new SubItem();
            glaze.items = new[] { "Шоколад - 100", "Крем - 100", "Бизе - 150", "Драже - 150", "Ягоды - 200" };
            glaze.cost = new[] { 100, 100, 150, 150, 200 };
            SubItem decor = new SubItem();
            decor.items = new[] { "Шоколадная - 150", "Ягодная - 150", "Кремовая - 150" };
            decor.cost = new[] { 150, 150, 150 };
            if (page == 1)
            {
                for (; ; )
                {
                    Clear();
                    GreetingSub();
                    switch (positon)
                    {
                        case 3:
                            page = 2;
                            foreach (var item in forms.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 4:
                            page = 3;
                            foreach (var item in sizes.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 5:
                            page = 4;
                            foreach (var item in taste.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 6:
                            page = 5;
                            foreach (var item in amount.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 7:
                            page = 6;
                            foreach (var item in glaze.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 8:
                            page = 7;
                            foreach (var item in decor.items)
                            {
                                Console.Write("   ");
                                Console.WriteLine(item);
                            }
                            break;
                        case 9:
                            Console.WriteLine("Спасибо за заказ! Если хотите заказать еще, нажмите Escape");
                            string order = $"\n Заказ от {DateTime.Now}" +
                                           $"\n\t Заказ: {descritpion}" +
                                           $"\n\t Цена: {Order.cost}";
                            File.AppendAllText("C:\\Users\\Даниил Селезнев\\Desktop\\Заказ.txt", order);
                            key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Escape)
                            {
                                descritpion = " ";
                                Order.cost = 0;
                                page = 0;
                                Clear();
                                Greetings();
                            }
                            break;
                    }
                    key = Console.ReadKey(true);
                    Order.ChangePosition(key, page);
                }
            }

            if (page > 1)
            {
                page--;
                SubItem buf = default;
                if (page == 2) buf = forms;

                else if (page == 3) buf = sizes;

                else if (page == 4) buf = taste;

                else if (page == 5) buf = amount;

                else if (page == 6) buf = glaze;

                else if (page == 7) buf = decor;

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Order.ChangePosition(key, page);
                        break;
                    case ConsoleKey.DownArrow:
                        Order.ChangePosition(key, page);
                        break;
                    case ConsoleKey.Enter:
                        if (positon == 3)
                        {
                            page = 0;
                            Order.cost += buf.cost[0];
                            descritpion += buf.items[0] + ", ";
                        }
                        if (positon == 4)
                        {
                            Order.cost += buf.cost[1];
                            descritpion += buf.items[1] + ", ";
                        }
                        if (positon == 5)
                        {
                            Order.cost += buf.cost[2];
                            descritpion += buf.items[2] + ", ";
                        }
                        if (positon == 6)
                        {
                            Order.cost += buf.cost[3];
                            descritpion += buf.items[3] + ", ";
                        }

                        if (positon == 7)
                        {
                            Order.cost += buf.cost[4];
                            descritpion += buf.items[4] + ", ";
                        }

                        switch (page)
                        {
                            case 1:
                                Greetings();
                                break;
                        }
                        break;
                }
            }
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void GreetingSub()
        {
            Console.WriteLine(" Для выхода нажимте Escape" +
                              "\n Выберите пункт из меню:" +
                              "\n -----------------------");
        }

        public static void Greetings()
        {
            Clear();
            Console.WriteLine(" Заказ тортов в Пахомленд" +
                              "\n Выберите параметры торта" +
                              "\n -------------------------");
            List<string> points = new List<string>()
            {
                "1. Форма торта", "2. Размер торта", "3. Вкус коржей", "4. Количество коржей", "5. Глазурь", "6. Декор",
                "7. Конец заказа"
            };
            foreach (var item in points)
            {
                Console.Write("   ");
                Console.WriteLine(item);
            }

            Console.WriteLine($"Итоговая цена: {Order.cost}");
            Console.WriteLine($"Заказ: {descritpion}");
        }

        static void Main(string[] args)
        {
            Greetings();
            ConsoleKeyInfo key = Console.ReadKey(true);
            Order.ChangePosition(key, page);
        }
    }
}