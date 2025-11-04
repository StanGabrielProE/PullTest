using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KnightVGoblin;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int knightHealth;
        int goblinHealth = Random.Shared.Next(0, 101); 

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"🎯 Goblin Health: {goblinHealth}");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        KnightHealth(out knightHealth);

        bool gameover = false;

        if (knightHealth != int.MinValue)
        {
            Start.Game();
            while (!gameover)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"🥷🏼 Knight Health: {knightHealth}");
                Console.WriteLine($"🧌 Goblin Health: {goblinHealth}");
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose your action:");
                Console.WriteLine("  1️ Attack");
                Console.WriteLine("  2️ Heal");

                userChoice(Console.ReadLine(), ref knightHealth, 10, ref goblinHealth);

                
                if (goblinHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@"
                   __   __           __        __            _   _   _ 
                   \ \ / /__  _   _  \ \      / /__  _ __   | | | | | |
                    \ V / _ \| | | |  \ \ /\ / / _ \| '_ \  | | | | | |
                     | | (_) | |_| |   \ V  V / (_) | | | | |_| |_| |_|
                     |_|\___/ \__,_|    \_/\_/ \___/|_| |_| (_) (_) (_)");
                    gameover = true;
                    break;
                }
               
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("Goblin: ");
                Atack(Random.Shared.Next(5, 16), ref knightHealth);

               
                if (knightHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"
                      ____                         ___                   _ 
                     / ___| __ _ _ __ ___   ___   / _ \__   _____ _ __  | |
                    | |  _ / _` | '_ ` _ \ / _ \ | | | \ \ / / _ \ '__| | |
                    | |_| | (_| | | | | | |  __/ | |_| |\ V /  __/ |    |_|
                     \____|\__,_|_| |_| |_|\___|  \___/  \_/ \___|_|    (_)");
                    gameover = true;
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

        }
    }

    public static void userChoice(string input, ref int myHealth, int value, ref int goblinHealth)
    {
        bool valid = int.TryParse(input, out int number);
        if (!valid) number = -1;

        switch (number)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Knight :");
                Atack(value, ref goblinHealth);
                break;
            case 2:
                Console.Write("Knight :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Heal(ref myHealth);
                break;
            default:
                myHealth -= 5;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" Invalid choice! You hurt yourself (-5 HP)");
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }

    public static void Heal(ref int health)
    {
        int heal = Random.Shared.Next(0, 8) == 3 ? 20 : 10;
        health += heal;

        if (heal == 20)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" Healed + + {heal} (Lucky boost!)");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Healed +{heal}");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Atack(int value, ref int Health)
    {
        int atack = Random.Shared.Next(0, 5) == 3 ? value * 2 : value;
        Health -= atack;

        if (atack == value * 2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"▄︻デ══━一💥 Critical Hit!! Damage dealt: {atack}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"🗡 Damage dealt: {atack}");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void KnightHealth(out int knightHealth)
    {
        Console.WriteLine(" Enter the health points for your knight:");
        string input = Console.ReadLine();

        if (input == "EXIT")
        {
            Console.WriteLine(@"
                       ⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠉⠉⠉⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣿⣿⣿⣿⡿⠋⠀⠀⣀⣤⣤⣤⣄⡀⠀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣿⣿⠟⠉⠀⠀⡠⠞⠻⢿⣿⣿⣿⣿⣦⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⡟⠁⠀⠀⠀⣼⣷⡀⠀⠀⢹⣿⣿⣿⣿⡇⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡏⠀⠀⠀⠈⢸⣿⣿⣿⣶⢞⡝⠁⠀⠉⢻⡇⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡇⠀⠀⠀⠀⠸⠿⠿⠏⠫⠋⣴⣷⣄⣀⡐⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡇⠀⠀⠀⠀⠀⣤⡄⡀⠀⠠⣾⣿⣿⠏⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡇⠀⣠⡀⠀⠀⠻⣿⣷⣦⠀⠛⠋⠁⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣧⣾⣿⣧⡀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⣠⣿⣿⠿⣿⣿⣿⡿⠿⢿⣿⣿⡿⢿⣿⠿⢿⣿⠿⣿⡿⢿
                       ⣿⣿⣿⣿⣿⣧⣄⣀⡤⠀⠀⠀⠀⠀⣼⣿⣿⣿⠀⣿⣿⣟⠀⢤⣀⣿⡿⠀⠈⣿⡇⠘⡏⠀⢻⠃⣸
                       ⡯⠻⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⢙⣿⣿⣿⠀⣿⣿⡿⠶⣤⠈⡿⠁⠘⠀⠘⣿⡀⠁⣦⠘⢀⣿
                       ⡇⠀⠀⠙⡿⣿⣿⡃⠀⠀⠀⠀⠀⠀⠺⣿⣿⣿⣀⣿⣿⣷⣄⣁⣤⣃⣰⣿⣿⣀⣸⣇⣠⣿⣄⣸⣿
                       ⡇⠀⠀⠀⠀⠀⠈⠃⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣶⣶⣄⣀⡀⠀⠀⢠⠄⠀⠀⠀⠀⢠⣿⣿⣿⣿⣉⠉⢉⡉⠉⣿⡏⠉⣿⡿⠉⠹⣿⣉⠉⢉⣻⣿
                       ⡟⣹⣾⣵⣿⣿⡶⢠⣻⣠⣴⣀⠀⠀⠠⢿⣿⣿⣿⣿⠀⢸⡇⠀⠉⠁⠀⣿⠃⠰⠀⢻⣿⠀⢸⣿⣿
                       ⣿⣿⣿⣿⣿⡿⡠⢌⣺⣷⣿⣿⡷⠀⠀⢊⣿⣿⣿⣿⠀⢸⡇⠀⣿⡇⠀⠇⢠⣶⣦⠀⢿⠀⢸⣿⣿
                       ⣿⣿⣿⣿⣫⣾⢀⣴⡿⣿⢿⣿⠃⠀⠀⠀⢼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣿⢿⡿⢿⣶⣿⣟⡿⣣⣾⠟⠀⡄⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣟⢵⡿⠗⣹⣿⣿⣪⢾⡿⣿⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡿⢇⢡⡆⣿⡷⢋⣴⣿⠷⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣷⢬⣊⠇⢣⣾⠟⢋⣁⠄⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⠿⣿⣿⡈⢀⡴⠋⠀⣀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣷⣽⣿⣇⠈⠀⡤⠜⠋⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡇⢱⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡟⢸⡿⢟⣵⣯⠀⠀⠑⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⡇⢊⣴⣿⣋⠇⠂⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣷⢟⣽⡽⡞⡜⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
                       ⣿⣿⡿⢣⢡⠁⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            knightHealth = int.MinValue;
        }
        else
        {
            while (!int.TryParse(input, out knightHealth))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid input! Please enter a number between 0–100 or type EXIT to quit.");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" All set! Prepare for battle!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}