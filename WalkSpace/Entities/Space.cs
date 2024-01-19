using System;
using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;

namespace WalkSpace.Entities
{

    class Space
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Character[,] SpaceW { get; set; }

        public Space(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            SpaceW = new Character[rows, columns];
        }

        public Character FindCh(int row, int column)
        {
            return SpaceW[row, column];
        }

        public Character FindCh(Position pos)
        {
            return SpaceW[pos.Rows, pos.Columns];
        }

        public void PlaceCh(Character ch, Position pos)
        {
            SpaceW[pos.Rows, pos.Columns] = ch;
        }

        public void RemoveCh(Position pos)
        {
            SpaceW[pos.Rows, pos.Columns] = null;
        }

        public bool ExistCh(Position pos)
        {
            if (FindCh(pos.Rows, pos.Columns) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistCh(int row, int column)
        {
            if (FindCh(row, column) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Player TakePlayer()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (ExistCh(i, j) == true)
                    {
                        if (FindCh(i, j).Color == Colors.Green)
                        {
                            Player p = FindCh(i, j) as Player;
                            return p;
                        }
                    }
                }
            }
            return new Player(3, new Position(2, 1));
        }

        public void CannotMovetTest(Position pos, Player plw)
        {
            if (pos.Rows > 9 || pos.Rows < 0 || pos.Columns > 19 || pos.Columns < 0) 
            {
                if (pos.Rows > 9)
                {
                    plw.Pos.ChangePos(pos.Rows - 1, pos.Columns);
                }
                else if (pos.Rows < 0)
                {
                    plw.Pos.ChangePos(pos.Rows + 1, pos.Columns);
                }
                else if (pos.Columns > 19)
                {
                    plw.Pos.ChangePos(pos.Rows, pos.Columns - 1);
                }
                else
                {
                    plw.Pos.ChangePos(pos.Rows, pos.Columns + 1);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                throw new MoveException("[!] Can't go this way!");
                Console.ResetColor();
            }
        }
    }

}