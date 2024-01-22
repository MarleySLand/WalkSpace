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

        public bool ValidPos(Position pos)
        {
            if (pos.Rows > 9 || pos.Rows < 0 || pos.Columns > 19 || pos.Columns < 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidPos(int rows, int columns)
        {
            if (rows > 9 || rows < 0 || columns > 19 || columns < 0)
            {
                return false;
            }
            return true;
        }

        public bool ExistCh(Position pos)
        {
            if (ValidPos(new Position(pos.Rows, pos.Columns)) == false)
            {
                return false;
            }
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
            if (ValidPos(new Position(row, column)) == false)
            {
                return false;
            }

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

        public bool[,] IsGuardVision(int row, int column)
        {
            Position pos = new Position(row, column);
            bool validPos1 = false , validPos2 = false, validPos3 = false, validPos4 = false;
            bool[,] mat = new bool[Rows, Columns];

            if (ValidPos(pos.Rows, pos.Columns + 1))
            {
                validPos1 = true;
            }
            if (ValidPos(pos.Rows, pos.Columns + 2))
            {
                validPos2 = true;
            }
            if (ValidPos(pos.Rows, pos.Columns + 3))
            {
                validPos3 = true;
            }
            if (ValidPos(pos.Rows, pos.Columns + 4))
            {
                validPos4 = true;
            }

            if (validPos1 == true)
            {
                if (ExistCh(pos.Rows, pos.Columns + 1) && FindCh(pos.Rows, pos.Columns + 1).Color == Colors.Red)
                {
                    mat[pos.Rows, pos.Columns] = true;
                }
            }
            if (validPos2 == true)
            {
                if (ExistCh(pos.Rows, pos.Columns + 2) && FindCh(pos.Rows, pos.Columns + 2).Color == Colors.Red)
                {
                    mat[pos.Rows, pos.Columns] = true;
                }
            }
            if (validPos3 == true)
            {
                if (ExistCh(pos.Rows, pos.Columns + 3) && FindCh(pos.Rows, pos.Columns + 3).Color == Colors.Red)
                {
                    mat[pos.Rows, pos.Columns] = true;
                }
            }
            if (validPos4 == true)
            {
                if (ExistCh(pos.Rows, pos.Columns + 4) && FindCh(pos.Rows, pos.Columns + 4).Color == Colors.Red)
                {
                    mat[pos.Rows, pos.Columns] = true;
                }
            }
            return mat;
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