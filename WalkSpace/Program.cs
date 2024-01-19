using System;
using WalkSpace.Entities;

namespace WalkSpace
{
    class Program
    {
        static void Main(string[] Args)
        {
            Space space = new Space(10, 20);
            Gaming game = new Gaming(false, space);
            game.PlaceCharacters();

           

                while (game.Finished == false)
                {
                        Console.Clear();
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Your mission: Get the treasure and avoid (or kill) the guards!");
                        Console.WriteLine();
                        Screen.PrintSpace(game.SpaceGame);
                        Console.WriteLine();

                        Screen.EnemiesDown(game);
                        Console.WriteLine();
                        Console.WriteLine("Instructions: W = go up, D = go right, S = go down, A = go left");
                        Console.Write("> ");
                        char move = char.Parse(Console.ReadLine());
                        game.MoveDirection(move);
                    }
                    catch (MoveException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected error: " + e.Message);
                        Console.ReadLine();
                    }
                }

        }
    }

}