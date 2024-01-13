﻿using System;
using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;
namespace WalkSpace.Entities
{

    class Gaming
    {
        public bool Finished { get; set; }
        public Space SpaceGame { get; set; }
        public Gaming(bool finished, Space spacegame)
        {
            Finished = false;
            SpaceGame = new Space(spacegame.Rows, spacegame.Columns);
        }
        public void PlaceCharacters()
        {
            SpaceGame.PlaceCh(new Player(3, new Position(8, 2)), new Position(8, 2));
        }
        public Player TakePlayer()
        {
            for (int i = 0; i < SpaceGame.Rows; i++)
            {
                for (int j = 0; j < SpaceGame.Columns; j++)
                {
                    if (SpaceGame.ExistCh(i, j) == true)
                    {
                        if (SpaceGame.FindCh(i, j).Color == Colors.Green)
                        {
                            Player p = SpaceGame.FindCh(i, j) as Player;
                            return p;
                        }
                    }
                }
            }
            return new Player(3, new Position(2, 1));
        }

        public void MoveDirection(char move)
        {
            Player p = TakePlayer();
            if (move == 'W')
            {
                Position posO = new Position(p.Pos.Rows, p.Pos.Columns);
                p.Pos.ChangePos(p.Pos.Rows - 1, p.Pos.Columns);
                Position posD = p.Pos;
                SpaceGame.CannotMovetTest(posD, p);
                MoveCh(posO, posD);
            }
            else if (move == 'D')
            {
                Position posO = new Position(p.Pos.Rows, p.Pos.Columns);
                p.Pos.ChangePos(p.Pos.Rows, p.Pos.Columns + 1);
                Position posD = p.Pos;
                SpaceGame.CannotMovetTest(posD, p);
                MoveCh(posO, posD);
            }
            else if (move == 'S')
            {
                Position posO = new Position(p.Pos.Rows, p.Pos.Columns);
                p.Pos.ChangePos(p.Pos.Rows + 1, p.Pos.Columns);
                Position posD = p.Pos;
                SpaceGame.CannotMovetTest(posD, p);
                MoveCh(posO, posD);
            }
            else
            {
                Position posO = new Position(p.Pos.Rows, p.Pos.Columns);
                p.Pos.ChangePos(p.Pos.Rows, p.Pos.Columns - 1);
                Position posD = p.Pos;
                SpaceGame.CannotMovetTest(posD, p);
                MoveCh(posO, posD);
            }
        }

        public void MoveCh(Position origin, Position destiny)
        {
            Player aux = SpaceGame.FindCh(origin) as Player;
            SpaceGame.RemoveCh(origin);
            if (SpaceGame.ExistCh(destiny) == true)
            {
                SpaceGame.CatchedChs.Add(SpaceGame.FindCh(destiny));
            }
            SpaceGame.PlaceCh(aux, destiny);
        }
    }

}
