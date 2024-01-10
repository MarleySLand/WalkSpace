using System;
using System.Linq;
using System.Collections.Generic;
using SpaceWalk;

namespace SpaceWalk.Entities
{

    class Space
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Character[,] SpaceW { get; set; }
        public List<Character> CatchedChs { get; set; }

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
    }

}