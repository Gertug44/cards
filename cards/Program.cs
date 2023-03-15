using System;
using System.Collections.Generic;

namespace cards
{
    internal class Program
    {
        static Random r = new Random();
        static List<String> colors = new List<string>() { "R", "G", "B", "W" };
        static int MaxDignity = 10;
        static List<List<String>> distribution;
        static int CountPlayers;
        static List<String> deck;

        static void Main(string[] args)
        {
            Console.WriteLine("Для выхода из программы введите \"exit\"");
            var f = false;
            deck = new List<String>();
            for (int i = 0; i < colors.Count; i++)
            {
                for (int j = 1; j < MaxDignity + 1; j++)
                {
                    deck.Add(colors[i] + j.ToString());
                }
            }
            while (true)
            {
                if (f) break;
                var command = Console.ReadLine().Split(" ");
                switch (command[0].ToLower())
                {
                    case "start":
                        if (command.Length != 3) {
                            Console.WriteLine("Недостаточно аргументов для выполнения данной команды, их должно быть 2 после команды через пробел");
                            break;
                        }
                        var N = int.Parse(command[1]);
                        CountPlayers = int.Parse(command[2]);
                        if (N* CountPlayers > MaxDignity*colors.Count) {
                            Console.WriteLine("Всего карт 40, их не хватит на данное количество людей, выберите, пожалуйста, другие параметры");
                            break;
                        }
                        else
                        {
                            TakesCards(N, CountPlayers);
                        }
                        break;
                    case "get-cards":
                        if (command.Length != 2)
                        {
                            Console.WriteLine("Недостаточно аргументов для выполнения данной команды, должен быть 1 аргумент после команды через пробел");
                            break;
                        }
                        var C = int.Parse(command[1]);
                        if (C > CountPlayers & C < 0) {
                            Console.WriteLine("Номера игрока не найден!");
                            break;
                        }
                        foreach (var item in distribution[C - 1])
                            Console.Write(item + " ");
                        Console.WriteLine();
                        break;
                    case "exit":
                        f = true;
                        break;
                    default:
                        Console.WriteLine("Данной команды не предусмотрено");
                        break;
                }
            }
        }

        static void TakesCards(int N, int C)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                int card = r.Next(deck.Count); // случайная карта в колоде
                String temp = deck[card];
                deck[card] = deck[i];
                deck[i] = temp;
            }
            var numCard = 0;
            distribution = new List<List<String>>();
            for (int i = 0; i < CountPlayers; i++)
            {
                var cards = new List<String>();
                for (int j = 0; j < N; j++)
                {
                    cards.Add(deck[numCard]);
                    numCard++;
                }
                distribution.Add(cards);
            }
        }
    }
}
