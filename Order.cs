using Cakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Order
    {
        public static int cost = 0;

        private static int position = 3;

        public static void ChangePosition(ConsoleKeyInfo strelka, int page, string empty = "\0\0", string arrow = "->")
        {
            Console.SetCursorPosition(0, position);
            Console.Write(arrow);
            while (strelka.Key != ConsoleKey.Enter)
            {
                strelka = Console.ReadKey(true);
                if (page == 0)
                {
                    switch (strelka.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position < 9)
                            {
                                Console.SetCursorPosition(0, position);
                                Console.Write(empty);
                                Console.SetCursorPosition(0, ++position);
                                Console.Write(arrow);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (position > 3)
                            {
                                Console.SetCursorPosition(0, position);
                                Console.Write(empty);
                                Console.SetCursorPosition(0, --position);
                                Console.Write(arrow);
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
                else if (page > 0)
                {
                    switch (strelka.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position < 7)
                            {
                                Console.SetCursorPosition(0, position);
                                Console.Write(empty);
                                Console.SetCursorPosition(0, ++position);
                                Console.Write(arrow);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (position > 3)
                            {
                                Console.SetCursorPosition(0, position);
                                Console.Write(empty);
                                Console.SetCursorPosition(0, --position);
                                Console.Write(arrow);
                            }
                            break;
                        case ConsoleKey.Escape:
                            page = 0;
                            Program.Greetings();
                            break;
                    }
                }
            }

            page++;
            Program.Entering(strelka, position, page);
        }
    }
}
