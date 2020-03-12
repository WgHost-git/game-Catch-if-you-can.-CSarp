using System;
using System.Collections.Generic;
using System.Text;

namespace CatchMe
{
    class Menu
    {
        public static int choiceMenu { get; set; } = 0;
        private static string menu2 = "2) Загрузить последнюю игру;";
        private static string menu3 = "3) Выход.";
        private static string menu1 = "1) Играть;";

        public static void NavigatingTheMenu(ref int choice)
        {
            if (choiceMenu == 0)
            {
                Console.SetCursorPosition(20, 2);
                Console.WriteLine("Управление меню стрелочками. Выбор - ENTER.");


                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 4);
                Console.WriteLine(menu1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(20, 5);
                Console.WriteLine(menu2);
                Console.SetCursorPosition(20, 6);
                Console.WriteLine(menu3);

                choiceMenu = 1;
            }

            ConsoleKeyInfo keyMenu = Console.ReadKey(true);

            switch (keyMenu.Key)
            {
                case ConsoleKey.Enter:
                    if (choiceMenu == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        choice = 1;
                    }
                    else if (choiceMenu == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        choice = 2;
                    }
                    else if (choiceMenu == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        choice = 3;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (choiceMenu == 1)
                    {
                        choiceMenu = 3;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    else if (choiceMenu == 3)
                    {
                        --choiceMenu;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    else
                    {
                        --choiceMenu;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choiceMenu == 1)
                    {
                        ++choiceMenu;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    else if (choiceMenu == 2)
                    {
                        ++choiceMenu;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    else
                    {
                        choiceMenu = 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine(menu1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(20, 5);
                        Console.WriteLine(menu2);
                        Console.SetCursorPosition(20, 6);
                        Console.WriteLine(menu3);
                    }
                    break;
            }


        }
    }
}
