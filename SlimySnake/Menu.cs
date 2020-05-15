using System;

namespace SlimySnake
{
    public class Menu
    {
        // задаём две переменные для изменения окна консоли:
        static readonly int x = 69;
        static readonly int y = 9;
        public void Present()
        {
            // очищаем консоль:
            Console.Clear();
            // задаём цвета консоли и букв:
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            // текст в консоли:
            Console.WriteLine(" ");
            Console.WriteLine(" █▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█▄█");
            Console.WriteLine(" █████████████████████████████▀█▀█▀█▀█▀█████████████████████████████");
            Console.WriteLine(" ████████████████████████████SLIMY SNAKE████████████████████████████");
            Console.WriteLine(" ████████████████████████████▄█▄█▄█▄█▄█▄████████████████████████████");
            Console.WriteLine(" ██■ ДЛЯ ВЫБОРА В МЕНЮ НАЖИМАЙТЕ НА НУЖНУЮ КНОПКУ ПЕРЕД ПУНКТОМ ■███");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████■ ДЛЯ ПЕРЕХОДА В ГЛАВНОЕ МЕНЮ НАЖМИТЕ ЛЮБУЮ КЛАВИШУ ■███████");
            Console.WriteLine(" █▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█▀█");
            // задаём параметр и назначаем на буковки перемещение по меню:
            ConsoleKeyInfo Choise = new ConsoleKeyInfo();
            Choise = Console.ReadKey();
            // в данном случае пользователь может нажать на пробел, выполнится if, если он нажмёт на любую другую кнопку, выполнится else, они одинаковые:
            if (Choise.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }
        public void MainMenu()
        {
            // задаём размер и буфер консоли (на всякий случай сделал, чтобы меньше глакков было, гы)
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.WriteLine("");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" █████████████████████████ Q — НАЧАТЬ ИГРУ █████████████████████████");
            Console.WriteLine(" █████████████████████████ A — УПРАВЛЕНИЕ  █████████████████████████");
            Console.WriteLine(" █████████████████████████ Z — АВТОР       █████████████████████████");
            Console.WriteLine(" █████████████████■ ДЛЯ ВЫХОДА ИЗ ИГРЫ НАЖМИТЕ ESC ■████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            // задаём параметр и назначаем на буковки перемещение по меню:
            ConsoleKeyInfo Choise = new ConsoleKeyInfo();
            Choise = Console.ReadKey();
            // задаём клавиши для перемещения по меню с вызовами функций и очищением консоли:
            if (Choise.Key == ConsoleKey.Q)
            {
                Console.Clear();
                GameMenu();
            }
            else if (Choise.Key == ConsoleKey.A)
            {
                Console.Clear();
                Upra();
            }
            else if (Choise.Key == ConsoleKey.Z)
            {
                Console.Clear();
                Author();
            }
            // если пользователь нажмёт Escape, то консоль закроется, по сути он выйдет из игры
            else if (Choise.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            // так же предусмотрено нажатие на другие клавиши, если случится, издастся звук, якобы "ошибки" и его перебросит на ту же функцию
            else
            {
                Console.Beep();
                Console.Clear();
                MainMenu();
            }
        }
        public void GameMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" █████████████████████████ Q — ЛЁГКИЙ      █████████████████████████");
            Console.WriteLine(" █████████████████████████ A — НОРМАЛЬНЫЙ  █████████████████████████");
            Console.WriteLine(" █████████████████████████ Z — СЛОЖНЫЙ     █████████████████████████");
            Console.WriteLine(" █████████████■ ДЛЯ ПЕРЕХОДА В ГЛАВНОЕ МЕНЮ НАЖМИТЕ ESC ■███████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            ConsoleKeyInfo Choise = new ConsoleKeyInfo();
            Choise = Console.ReadKey();
            if (Choise.Key == ConsoleKey.Q)
            {
                // чистим консоль, дабы меню пропало, а то достало:
                Console.Clear();
                Easy E = new Easy();
                // задаём цикл дувайл, дабы всё корректно работало:
                do
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    E.UpdateMap();
                    E.NewFood();
                    E.ClearMap();
                    E.MoveHero();
                    E.GameOver();
                } while (E.end);
            }
            else if (Choise.Key == ConsoleKey.A)
            {
                Console.Clear();
                Normal N = new Normal();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    N.UpdateMap();
                    N.NewFood();
                    N.ClearMap();
                    N.MoveHero();
                    N.GameOver();
                } while (N.end);
            }
            else if (Choise.Key == ConsoleKey.Z)
            {
                Console.Clear();
                Hard H = new Hard();
                do
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    H.UpdateMap();
                    H.NewFood();
                    H.ClearMap();
                    H.MoveHero();
                    H.GameOver();
                } while (H.end);
            }
            // возвращает в главное меню:
            else if (Choise.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();
            }
            // так же дабы не было мисскиликов или специально не сломали моё прекрасное меню
            else
            {
                Console.Beep();
                Console.Clear();
                GameMenu();
            }
        }
        public void Author()
        {
            // ну тут ясно, автор типо крутой
            Console.WriteLine("");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████■ АВТОР ИГРЫ: Бледных Данил ■███████████████████");
            Console.WriteLine(" ███████████████████■      vk.com/sukapen       ■███████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" █████████████■ ДЛЯ ПЕРЕХОДА В ГЛАВНОЕ МЕНЮ НАЖМИТЕ ESC ■███████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            ConsoleKeyInfo Choise = new ConsoleKeyInfo();
            Choise = Console.ReadKey();
            if (Choise.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.Beep();
                Console.Clear();
                Author();
            }
        }
        public void Upra()
        {
            // ну это так, чтобы было
            Console.WriteLine("");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████■ ДЛЯ УПРАВЛЕНИЯ ИСПОЛЬЗУЙТЕ СТРЕЛОЧКИ НА КЛАВИАТУРЕ ■██████");
            Console.WriteLine(" ███████■    ВАША ЦЕЛЬ - СЪЕСТЬ КАК МОЖНО БОЛЬШЕ ФРУКТОВ     ■██████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" █████████████■ ДЛЯ ПЕРЕХОДА В ГЛАВНОЕ МЕНЮ НАЖМИТЕ ESC ■███████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
            ConsoleKeyInfo Choise = new ConsoleKeyInfo();
            Choise = Console.ReadKey();
            if (Choise.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();
            }
            else
            {
                Console.Beep();
                Console.Clear();
                Upra();
            }
        }
    }
}
