﻿using System;
using SpaceWalk.Entities;

namespace SpaceWalk
{
    class Program
    {
        static void Main(string[] Args)
        {
            Space space = new Space(10, 20);
            Gaming game = new Gaming(false, space);
            game.PlaceCharacters();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Your mission: Get the treasure and hide (or kill them) from the guards!");
            Console.WriteLine();

            while (game.Finished == false)
            {
                Screen.PrintSpace(game.SpaceGame);
                Console.WriteLine();

                Console.WriteLine("Instructions: W = go up, D = go right, S = go down, A = go left");
                Console.Write("> ");
                char move = char.Parse(Console.ReadLine());
                game.MoveDirection(move);
                Console.Clear();
            }

        }
    }

}