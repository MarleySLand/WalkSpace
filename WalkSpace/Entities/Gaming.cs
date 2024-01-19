using System;
using System.Linq;
using System.Collections.Generic;
using WalkSpace.Entities.Enums;
namespace WalkSpace.Entities
{

    class Gaming
    {
        public bool Finished { get; set; }
        public Space SpaceGame { get; set; }
        public bool CatchedG { get; set; }
        public Gaming(bool finished, Space spacegame)
        {
            Finished = false;
            SpaceGame = new Space(spacegame.Rows, spacegame.Columns);
        }
        public void PlaceCharacters()
        {
            SpaceGame.PlaceCh(new Player(3, new Position(2, 1)), new Position(2, 1));
            SpaceGame.PlaceCh(new Guard(3, new Position(2, 14)), new Position(2, 14));
            SpaceGame.PlaceCh(new Guard(3, new Position(6, 14)), new Position(6, 14));
            SpaceGame.PlaceCh(new Guard(3, new Position(7, 17)), new Position(7, 17));
        }

        public void MoveDirection(char move)
        {
            Player p = SpaceGame.TakePlayer();
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
            else if (move == 'A')
            {
                Position posO = new Position(p.Pos.Rows, p.Pos.Columns);
                p.Pos.ChangePos(p.Pos.Rows, p.Pos.Columns - 1);
                Position posD = p.Pos;
                SpaceGame.CannotMovetTest(posD, p);
                MoveCh(posO, posD);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                throw new FormatException("[!] The movement you typed is invalid! Valid moves: W/D/S/A");
                Console.ResetColor();
            }
        }

        public void MoveCh(Position origin, Position destiny)
        {
            Player aux = SpaceGame.FindCh(origin) as Player;
            SpaceGame.RemoveCh(origin);
            if (SpaceGame.ExistCh(destiny) == true)
            {
                SpaceGame.RemoveCh(destiny);
                aux.CatchedChs++;
                CatchedG = true;
            }
            SpaceGame.PlaceCh(aux, destiny);
        }
    }

}
