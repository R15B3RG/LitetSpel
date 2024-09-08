
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class SmallGame()
{

    static void Main(string[] args)
    {
        Player player = new Player();

        Enemy enemy = new Enemy();

        SmallGame smallGame = new SmallGame();

        smallGame.Combat(player, enemy);
    }

    void Combat(Player player, Enemy enemy)
    {

        bool Combat = true;

        Console.WriteLine("Combat started!");
        Console.ReadKey();

        while (Combat)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Player HP: ");
            Console.ResetColor();
            Console.Write($" {player.PlayerHealth} |||| ");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Enemy HP: ");
            Console.ResetColor();
            Console.WriteLine($" {enemy.EnemyHealth}");

            if (player.PlayerHealth <= 0)
            {
                Console.WriteLine("Player died! Game over!");

                Console.ReadKey();
                Combat = false;

                Environment.Exit(0);
            }
            if (enemy.EnemyHealth <= 0)
            {
                Console.WriteLine("Enemy defeated! Player wins!");

                Console.ReadKey();
                Combat = false;

                Environment.Exit(0);

            }

            while (player.PlayerTurn == true)
            {

                Console.WriteLine("Player turn");

                player.PlayerAttacks(player, enemy);

                

                player.PlayerTurn = false;

                enemy.EnemyTurn = true;

                break;
            }

            while (enemy.EnemyTurn == true)
            {
                if (player.PlayerHealth <= 0)
                {
                    Console.WriteLine("Player died! Game over!");

                    Console.ReadKey();
                    Combat = false;

                    Environment.Exit(0);
                }
                if (enemy.EnemyHealth <= 0)
                {
                    Console.WriteLine("Enemy defeated! Player wins!");

                    Console.ReadKey();
                    Combat = false;

                    Environment.Exit(0);

                }

                Random random = new Random();

                int EnemyStrike = random.Next(1, 3);

                Console.WriteLine("Enemy turn");
                Console.ReadKey();

                Console.WriteLine("Enemy strikes player!");

                player.PlayerHealth -= EnemyStrike;

                Thread.Sleep(1500);

                Console.WriteLine($"Player took {EnemyStrike} damage!");
                Console.ReadKey();

                enemy.EnemyTurn = false;

                player.PlayerTurn = true;

                break;

            }

        }
    }

    public class Player()
    {
        private Player _player;

        public bool PlayerTurn = true;

        private int _playerHealth = 10;
        public int PlayerHealth
        {
            get => _playerHealth;
            set => _playerHealth = value;
        }

        internal void PlayerAttacks(Player player, Enemy enemy)
        {
            Random random = new Random();

            Console.WriteLine("1. Strike"
               +"\n 2. Heal");

            string input = Console.ReadLine();

            int PlayerStrike = random.Next(1, 3);

            int heal = random.Next(1, 5);

            while(PlayerTurn)
            {
                if (input == "1")
                {
                    Console.WriteLine("Player strikes the enemy!");

                    enemy.EnemyHealth -= PlayerStrike;

                    Thread.Sleep(1500);

                    Console.WriteLine($"Enemy took {PlayerStrike} damage!");
                 
                    Console.ReadKey();

                    break;

                }
                if (input == "2")
                {
                    Console.WriteLine("Player cast heal on self!");

                    player.PlayerHealth += heal;
                    if (player.PlayerHealth >= 10)
                    {
                        player.PlayerHealth = 10;
                    }

                    Console.WriteLine($"Player heals {heal} on self!");
                    Console.WriteLine($"Player health is {player.PlayerHealth}");
                    Console.ReadKey();

                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!");

                    input = Console.ReadLine();
                }
            }

            
        }
    }

    public class Enemy()
    {
        private Enemy _enemy;

        public bool EnemyTurn = false;

        private int _enemyHealth = 10;

        public int EnemyHealth
        {
            get => _enemyHealth;
            set => _enemyHealth = value;
        }
    }
}