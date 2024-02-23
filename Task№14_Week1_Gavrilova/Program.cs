using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размер квадрата (нечетное число): ");
        int N = Convert.ToInt32(Console.ReadLine());
        if (N % 2 == 0)
        {
            Console.WriteLine("Вы ввели четное число");

        }
        else
        {
            int[,] grid = new int[N, N]; // Создаем квадрат NхN

            int center = N / 2;
            grid[center, center] = 1; // Зараженная центральная клетка

            int infectionTime = 6;
            int immunityTime = 4;

            Console.WriteLine("Введите интервал времени: ");
            int timeInterval = Convert.ToInt32(Console.ReadLine());

            for (int t = 0; t < timeInterval; t++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            if (t < infectionTime)
                            {
                                if (i > 0 && grid[i - 1, j] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i - 1, j] = 1; // Заразить клетку сверху

                                if (i < N - 1 && grid[i + 1, j] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i + 1, j] = 1; // Заразить клетку снизу

                                if (j > 0 && grid[i, j - 1] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i, j - 1] = 1; // Заразить клетку слева

                                if (j < N - 1 && grid[i, j + 1] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i, j + 1] = 1; // Заразить клетку справа
                            }
                            else if (t >= infectionTime && t < infectionTime + immunityTime)
                            {
                                grid[i, j] = 2; // Невосприимчивая к инфекции клетка
                            }
                            else
                            {
                                grid[i, j] = 0; // Здоровая клетка
                            }
                        }
                    }
                }

                Console.WriteLine($"Шаг {t}:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (grid[i, j] == 1)
                            Console.Write("[X]"); // Зараженная клетка
                        else if (grid[i, j] == 2)
                            Console.Write("[I]"); // Невосприимчивая к инфекции
                        else
                            Console.Write("[ ]"); // Здоровая клетка
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

    }
}