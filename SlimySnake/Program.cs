using System;


namespace SlimySnake
{
    public class Program
    {
        // задаём две переменные для изменения окна консоли:
        static readonly int x = 69;
        static readonly int y = 9;
        static void Main(string[] args)
        {
            // отключем курсор:
            Console.CursorVisible = false;
            // задаём размер и буфер консоли:
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            // вызываем класс Menu и функцию в нём M.Present():
            Menu M = new Menu();
            M.Present();
        }
    }
}

