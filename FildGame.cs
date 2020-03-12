using System;
using System.Collections.Generic;
using System.Text;

namespace CatchMe
{
    [Serializable]
    public class FildGame
    {
        public int cursorX { get; private set; } = 43;
        public int cursorY { get; private set; } = 23;
        public int fieldX { get; private set; } = 6;
        public int fieldY { get; private set; } = 5;
        public int user { get; private set; } = 1;
        public bool spacebar { get; private set; } = false;
        public int tempX { get; private set; } = 0;
        public int tempY { get; private set; } = 0; 
        public int gameResult { get; private set; } = 2;

        private char[,] field = {
                { '.' , '.' , '.' , '.', '.' , '.' , '.' , '.' , '.' , '.' , '.' , '.', '.' },
                { '.' , '.' , '.' , '.', '.' , '[' , ' ' , ']' , '.' , '.' , '.' , '.', '.' },
                { '.' , '.' , '[' , ' ', ']' , '[' , ' ' , ']' , '[' , ' ' , ']' , '.', '.' },
                { '.' , '.' , '[' , ' ', ']' , '[' , '*' , ']' , '[' , ' ' , ']' , '.', '.' },
                { '.' , '.' , '[' , 'X', ']' , '[' , ' ' , ']' , '[' , 'X' , ']' , '.', '.' },
                { '.' , '.' , '.' , '.', '.' , '[' , 'X' , ']' , '.' , '.' , '.' , '.', '.' },
                { '.' , '.' , '.' , '.', '.' , '.' , '.' , '.' , '.' , '.' , '.' , '.', '.' }
            };

        public void MoveCursor() // Метод установки курсора в игровую область
        {
            Console.SetCursorPosition(cursorX, cursorY);
        }
        public void PrintingARule()   // Метод вывода правил
        {
            Console.WriteLine();
            Console.Write("\t");
            Console.WriteLine(new string('-', 108));
            Console.WriteLine($"\t| Игрок1 - фигура 'X';{new string(' ', 85)}|");
            Console.WriteLine($"\t| Игрок2 - фигура '*';{new string(' ', 85)}|");
            Console.WriteLine($"\t| Управление - стрелочками на клавиатуре;{new string(' ', 66)}|");
            Console.WriteLine($"\t| Взять фигуру - кнопка Пробел (SpaceBar);{new string(' ', 65)}|");
            Console.WriteLine($"\t| Поставить фигуру - кнопка Интер (Enter);{new string(' ', 65)}|");
            Console.WriteLine($"\t|{new string(' ', 106)}|");
            Console.WriteLine($"\t|\t\tПравила.{new string(' ', 83)}|");
            Console.WriteLine($"\t| 1) Фигуры первого игрока могут двигаться только вверх (с двух верхних боковых клеток по диагонали);{new string(' ', 6)}|");
            Console.WriteLine($"\t| 2) Фигурка второго игрока может двигаться вверх-вниз-влево-вправо и с самой верхней позиции по диагонали;|");
            Console.WriteLine($"\t| 3) Нельзя делать ход на уже занятую клетку;{new string(' ', 62)}|");
            Console.WriteLine($"\t| 4) Первым всегда ходит первый игрок;{new string(' ', 69)}|");
            Console.WriteLine($"\t| 5) Игра заканчивается, если фигура второго игрока окажется ниже всех фигур первого игрока,{new string(' ', 15)}| \n" +
                              $"\t|    либо у него не будет возможности сделать ход. {new string(' ', 55)} |");
            Console.Write("\t");
            Console.WriteLine(new string('-', 108));
        }
        public void PrintField() //Метод вывода поля на консоль
        {
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(37, 18 + i);

                for (int j = 0; j < 13; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void MovingAroundTheField(ConsoleKeyInfo key) // Метод передвижения по полю
        {
            Console.SetCursorPosition(cursorX, cursorY);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:

                    if (field[fieldY, fieldX] == 'X' && field[fieldY - 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY - 1, fieldX] == '*')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY - 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY - 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY - 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY - 1, fieldX] == '*')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY - 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY - 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY--;
                        cursorY--;
                        field[fieldY, fieldX] = ' ';
                    }
                    PrintField();
                    break;

                case ConsoleKey.DownArrow:

                    if (field[fieldY, fieldX] == 'X' && field[fieldY + 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY + 1, fieldX] == '*')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY + 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY + 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY + 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY + 1, fieldX] == '*')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY + 1, fieldX] == 'X')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY + 1, fieldX] == ' ')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldY++;
                        cursorY++;
                        field[fieldY, fieldX] = ' ';
                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX - 3] == ' ' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX - 3] == '*' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX - 3] == 'X' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY, fieldX - 3] == ' ' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY, fieldX - 3] == 'X' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX - 3] == '*' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX - 3] == 'X' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX - 3] == ' ' && field[fieldY, fieldX - 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX -= 3;
                        cursorX -= 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    break;

                case ConsoleKey.RightArrow:

                    if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX + 3] == ' ' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX + 3] == '*' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == 'X' && field[fieldY, fieldX + 3] == 'X' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = 'X';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY, fieldX + 3] == ' ' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    else if (field[fieldY, fieldX] == '*' && field[fieldY, fieldX + 3] == 'X' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = '*';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX + 3] == '*' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = '*';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX + 3] == 'X' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = 'X';
                    }
                    else if (field[fieldY, fieldX] == ' ' && field[fieldY, fieldX + 3] == ' ' && field[fieldY, fieldX + 2] != '.')
                    {
                        field[fieldY, fieldX] = ' ';
                        fieldX += 3;
                        cursorX += 3;
                        field[fieldY, fieldX] = ' ';
                    }
                    break;
            }

        }
        public void ReplacementFiguresPlayer(ConsoleKeyInfo key) // Метод перестановки фигур(ход игроков)
        {
            if (user == 1)
            {
                MovingAroundTheField(key); // Метод передвижения по полю

                if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] == 'X' && spacebar == false
                    && field[fieldY - 1, fieldX] != '*')
                {
                    field[fieldY, fieldX] = ' ';
                    tempX = fieldX;
                    tempY = fieldY;
                    spacebar = true;
                }
                else if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] != 'X' && spacebar == false)
                {
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("Вы не взяли фигуру 'X' для перемещения.");
                    System.Threading.Thread.Sleep(1300);
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("                                                                                 ");
                }
                else if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] == 'X' && spacebar == false
                    && field[fieldY - 1, fieldX] == '*')
                {
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("Вы не можете пойти данной фигурой 'X'.");
                    System.Threading.Thread.Sleep(1300);
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("                                                                                 ");
                }

                if (spacebar)
                {
                    if (key.Key == ConsoleKey.Enter && tempY - 1 == fieldY && tempX == fieldX && tempY - 1 != '*')
                    {
                        field[fieldY, fieldX] = 'X';
                        spacebar = false;
                        user = 2;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY + 1 == fieldY && tempX - 3 == fieldX
                        && field[fieldY, fieldX] != 'X' && field[fieldY, fieldX] != '*'
                        && tempX == 9 && tempY == 2)
                    {
                        field[fieldY, fieldX] = 'X';
                        spacebar = false;
                        user = 2;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY + 1 == fieldY && tempX + 3 == fieldX
                        && field[fieldY, fieldX] != 'X' && field[fieldY, fieldX] != '*'
                        && tempX == 3 && tempY == 2)
                    {
                        field[fieldY, fieldX] = 'X';
                        spacebar = false;
                        user = 2;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(5, 27);
                        Console.WriteLine("Сюда невозможно установить эту фигуру. Внимательней ознакомтесь с правилами игры.");
                        System.Threading.Thread.Sleep(1300);
                        Console.SetCursorPosition(5, 27);
                        Console.WriteLine("                                                                                 ");
                    }
                }
            }
            else if (user == 2)
            {
                MovingAroundTheField(key); // Метод передвижения по полю

                if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] == '*' && spacebar == false
                    && field[fieldY + 1, fieldX] != ' ' && field[fieldY - 1, fieldX] != ' ' && field[fieldY, fieldX + 3] != ' '
                    && field[fieldY, fieldX - 3] != ' ' && fieldX != 6 && fieldY != 1)
                {
                    gameResult = 0;
                }
                else if (key.Key == ConsoleKey.Spacebar && tempX == 6 && fieldY == 1 && field[fieldY, fieldX] == '*' && spacebar == false
                    && field[fieldY + 1, fieldX] != ' ' && field[fieldY + 1, fieldX + 3] != ' ' && field[fieldY + 1, fieldX - 3] != ' ')
                {
                    gameResult = 0;
                }
                else if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] == '*' && spacebar == false)
                {
                    field[fieldY, fieldX] = ' ';
                    tempX = fieldX;
                    tempY = fieldY;
                    spacebar = true;
                }
                else if (key.Key == ConsoleKey.Spacebar && field[fieldY, fieldX] != '*' && spacebar == false)
                {
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("Вы не взяли фигуру '*' для перемещения.");
                    System.Threading.Thread.Sleep(1300);
                    Console.SetCursorPosition(5, 27);
                    Console.WriteLine("                                                                                 ");
                }

                if (spacebar)
                {
                    if (key.Key == ConsoleKey.Enter && tempX == 6 && tempY == 1 && tempY + 1 == fieldY
                        && field[fieldY, fieldX] != 'X' && tempX - 3 == fieldX)
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempX == 6 && tempY == 1 && tempY + 1 == fieldY
                        && field[fieldY, fieldX] != 'X' && tempX + 3 == fieldX)
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY - 1 == fieldY && tempX == fieldX && field[fieldY, fieldX] != 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY + 1 == fieldY && tempX == fieldX && field[fieldY, fieldX] != 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY == fieldY && tempX - 3 == fieldX && field[fieldY, fieldX] != 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter && tempY == fieldY && tempX + 3 == fieldX && field[fieldY, fieldX] != 'X')
                    {
                        field[fieldY, fieldX] = '*';
                        spacebar = false;
                        user = 1;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.SetCursorPosition(5, 27);
                        Console.WriteLine("Сюда невозможно установить эту фигуру. Внимательней ознакомтесь с правилами игры.");
                        System.Threading.Thread.Sleep(1300);
                        Console.SetCursorPosition(5, 27);
                        Console.WriteLine("                                                                                 ");
                    }
                }
                CheckForVictory();
            }
        }
        public void CheckForVictory()    // Проверка на победу
        {
            char[] starX = new char[4];
            int count = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (field[i, j] == 'X' || field[i, j] == '*')
                    {
                        starX[count] = field[i, j];
                        count++;
                    }
                }
            }

            if (starX[3] == '*')
            {
                gameResult = 1;
            }
        }
    }
}
