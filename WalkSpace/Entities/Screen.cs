using WalkSpace.Entities.Enums;
using System;

namespace WalkSpace.Entities
{

    static class Screen
    {
        public static void PrintSpace(Space space)
        {
            for (int i = 0; i < space.Rows; i++)
            {
                Console.Write("  ");
                for (int j = 0; j < space.Columns; j++)
                {
                    PrintEntity(space, i, j);
                }
                Console.WriteLine();
            }

        }

        public static void PrintEntity(Space space, int row, int column)
        {
            if (space.ExistCh(row, column) == false)
              {
                
                if (space.IsGuardVision(row, column)[row, column])
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("  ");
                    Console.ResetColor();
                }

              }
            else
            {
                if (space.FindCh(row, column).Color == Colors.Green)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(space.FindCh(row, column) + " ");
                    Console.ResetColor();
                } else if (space.FindCh(row, column).Color == Colors.Red)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(space.FindCh(row, column) + " ");
                    Console.ResetColor();
                } else
                {
                    Console.Write(space.FindCh(row, column) + " ");
                }
            }
        }

        public static void EnemiesDown(Gaming game)
        {
            Console.WriteLine("Guards down: " + game.SpaceGame.TakePlayer().CatchedChs);
            if (game.CatchedG == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[!] You killed a guard!");
                game.CatchedG = false;
                Console.ResetColor();
            }
        }

        public static void FinalMessage(char end)
        {
            if (end == 'L')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine(" > You've got catched! D: It all ends here.");
                Console.ResetColor();
            } else if (end == 'W')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine(" > You've got the treasure! Good job :')");
                Console.ResetColor();
            }
        }

    }

}
