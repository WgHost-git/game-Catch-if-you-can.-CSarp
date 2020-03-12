using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CatchMe
{
    class ProgramMain
    {
        static void Main(string[] args)
        {
            Console.CursorSize = 100;           
            bool exit = true;
            int choice = 0;
            int count = 0;

            FildGame fildGame = new FildGame();
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream("save.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            do
            {
                if (choice == 0)
                {
                    Menu.NavigatingTheMenu(ref choice); // Меню
                }
                else if (choice == 1)
                {
                    while (exit)
                    {             
                        if (fildGame.gameResult == 2)
                        {
                            Console.SetCursorPosition(0, 0);

                            fildGame.PrintingARule(); // Метод вывода правил
                            fildGame.PrintField(); //Метод вывода поля на консоль

                            Console.SetCursorPosition(15, 17);
                            Console.WriteLine($"Ходит Игрок {fildGame.user}");

                            Console.SetCursorPosition(55, 17);
                            Console.WriteLine("Для выхода из игры нажмите - Escape. Игра будет сохранена.");

                            fildGame.MoveCursor(); // Метод установки курсора в поле игры

                            ConsoleKeyInfo key = Console.ReadKey(true);

                            if (key.Key == ConsoleKey.Escape)
                            {
                                break;
                            }

                            fildGame.ReplacementFiguresPlayer(key); // Метод перестановки фигур(ход игроков)
                        }
                        else if (fildGame.gameResult == 0)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(20, 5);
                            Console.WriteLine("ИГРОК 1 ВЫИГРАЛ !!!");
                            exit = false;
                        }
                        else if (fildGame.gameResult == 1)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(20, 5);
                            Console.WriteLine("ИГРОК 2 ВЫИГРАЛ !!!");
                            exit = false;
                        }
                        
                    }
                    formatter.Serialize(stream, fildGame);
                    exit = false;                 
                }
                else if (choice == 2)
                {
                    if (stream.Length == 0)
                    {
                        Console.SetCursorPosition(15, 10);
                        Console.WriteLine("Файл сохранения пуст");
                        choice = 0;
                        Menu.choiceMenu = 0;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        fildGame = (FildGame)formatter.Deserialize(stream);
                        count++;
                    }

                    choice = 1;
                }
                else if (choice == 3)
                {
                    exit = false;
                }              
            } while (exit);
           
            stream.Close();
        }
    }
}
