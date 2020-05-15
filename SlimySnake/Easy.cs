using System;
using System.Collections.Generic;

namespace SlimySnake
{
    public class Easy
    {
        // параметр лист, для отображения змейки
        private List<int> snakeX = new List<int>();
        private List<int> snakeY = new List<int>();
        // невозвратная переменная булл, для завершения игры
        public bool end = true;
        // невозвратная переменная айтинг, для считывания жратвы
        private bool eating = false;
        // ещё полезные переменные:
        private int eX, eY;
        // переменная для посчёта жратвы, задаём ей нуль
        public int point = 0;
        // задаём переменные для считывая конца змейки
        private int endsnakeX, endsnakeY;
        // переменные для размера поля:
        private const int x = 10, y = 10;
        // переменные для меню, чтобы геймовер корректно отображалось
        static readonly int xg = 69;
        static readonly int yg = 9;
        private double Time = 300;
        // параметр для считывания клавишь
        ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();
        // задаём поле с помощью массива
        private string[,] mass = new string[x,y];
        // задаём символ для змейки
        char snake = 'o';
        // вводим переменные для логических операций
        int heroX, heroY, foodX, foodY;
        // ну и рандом, вся жизнь на рандоме
        Random rand = new Random();
        public Easy()
        {
            // задаём размер окна
            Console.SetWindowSize(x + 30, y + 15);
            Console.SetBufferSize(x + 30, y + 15);
            // выключаем курсор, потому что бесит
            Console.CursorVisible = false;
            // вызываем нужные нам функции:
            CompletionMap();
            Starting();
            Mapping();
        }
        private void Starting()
        {
            // спавн змейки и еды, с помощью рандома и логических операций
            do
            {
                heroX = rand.Next(0, x);
                heroY = rand.Next(0, y);
                foodX = rand.Next(0, x);
                foodY = rand.Next(0, y);
            } while (heroX == foodX || heroX == foodY || heroY == foodY || heroY == foodX);
            // добавление змейки на поле:
            snakeX.Add(heroX); 
            snakeY.Add(heroY);
            mass[snakeX[0], snakeY[0]] = snake.ToString();
            // задаем символ для еды
            mass[foodX, foodY] = "x";
        }
        private void ReversX()
        {
            // поворот змейки
            endsnakeX = snakeX[snakeX.Count - 1];
            endsnakeY = snakeY[snakeY.Count - 1];
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                snakeX[i] = snakeX[i - 1];
                snakeY[i] = snakeY[i - 1];
            }
        }
        public void CompletionMap()
        {
            // корректное отображение карты:
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    // задаём символ, в нашем случае это пустота, чтобы он занимал всё остальное поле
                    mass[i, j] = " ";
                }
            }
        }
        public void Mapping()
        {
            // отрисовка карты
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(mass[i, j]);
                }
            }
            // задаём нашей мапе зелённый цвет, чтобы глаза вырывало 
            Console.BackgroundColor = ConsoleColor.Green;
        }
        public void UpdateMap()
        {
            // так сказать рендеринг мапы
            Console.SetCursorPosition(foodY, foodX);
            Console.Write("x");
            for (int i = snakeY.Count - 1; i >= 0; --i)
            {
                Console.SetCursorPosition(snakeY[i], snakeX[i]);
                Console.Write("o");
            }
        }
        public void ClearMap()
        {
            // очистка карты, после рендеринга
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }
        public void MoveHero()
        {
            // цикл иф, для того чтобы змейка двигалась сама
            if (Console.KeyAvailable == true)
            {
                KeyInfo = Console.ReadKey();
            }
            // ну и цикл свитч, для управления
            switch (KeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (snakeX[0] > 0)
                    { ReversX(); snakeX[0]--; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (snakeY[0] > 0)
                    { ReversX(); snakeY[0]--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (snakeX[0] < x - 1)
                    { ReversX(); snakeX[0]++; }
                    break;
                case ConsoleKey.RightArrow:
                    if (snakeY[0] < y - 1)
                    { ReversX(); snakeY[0]++; }
                    break;
                default:
                    break;
            }
            Eating();
            UpdateSnake();
        }
        private void Eating()
        {
            // функция котороя считывает, что поинт был съеден
            if (eating)
            {
                Time = Time - 1;
                if (eY == endsnakeY && eX == endsnakeX)
                {
                    // подсчёт поинтов
                    point++;
                    // добавление роста змейки:
                    snakeY.Add(endsnakeY);
                    snakeX.Add(endsnakeX);
                    eating = false;
                }
            }
        }
        private void UpdateSnake()
        {
            // обновление змейки
            if (snakeY.Count == snakeX.Count)
            {
                // рендеринг мапы
                CompletionMap();
                mass[foodX, foodY] = "x";
                for (int i = 0; i < snakeX.Count; ++i)
                {
                    mass[snakeX[i], snakeY[i]] = snake.ToString();
                }
            }
        }
        public void NewFood()
        {
            // указываем скорость обновления консоли (я это так понял)
            System.Threading.Thread.Sleep(400);
            // производятся подсчёты, был ли съедем поинт
            if (snakeX[0] == foodX && snakeY[0] == foodY)
            {
                eating = true;
                eX = foodX;
                eY = foodY;
                // спавн нового поинта, с учётом рандома и отдаления от змейки
                do
                {
                    foodX = rand.Next(0, x);
                    foodY = rand.Next(0, y);
                } while (snakeX[0] == foodX || snakeX[0] == foodY || snakeY[0] == foodY || snakeY[0] == foodX);
            }
        }
        public void GameOver()
        {
            // цикл фор для логической операции, которая считывает, если змейка начнёт "заезжать" на саму себя
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                if (i > 0)
                {
                    if (snakeX[0] == snakeX[i] && snakeY[0] == snakeY[i])
                    {
                        // прекращение игры:
                        end = false;
                        // задаём цвет консоли и букв, который соответсвует меню
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        // чистим консоль
                        Console.Clear();
                        // задаём размер и буфер консоли, которые у меню
                        Console.SetWindowSize(xg + 1, yg + 1);
                        Console.SetBufferSize(xg + 1, yg + 1);
                        // геймовер:
                        Console.WriteLine("");
                        Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
                        Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
                        Console.WriteLine(" ████████████████████████■    GAME OVER    ■████████████████████████");
                        // так же здесь отображаются сколько поинтов съел игрок
                        Console.WriteLine($" ████████████████████████■    SCORE: {point}     ■████████████████████████");
                        Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
                        Console.WriteLine(" █████████████■ ДЛЯ ПЕРЕХОДА В ГЛАВНОЕ МЕНЮ НАЖМИТЕ ESC ■███████████");
                        Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
                        Console.WriteLine(" ███████████████████████████████████████████████████████████████████");
                        ConsoleKeyInfo Choise = new ConsoleKeyInfo();
                        Choise = Console.ReadKey();
                        Menu M = new Menu();
                        // ну и возвращение в главное меню
                        if (Choise.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            M.MainMenu();
                        }
                        else
                        {
                            Console.Beep();
                            Console.Clear();
                            GameOver();
                        }
                    }
                }
            }
        }
    }
}
