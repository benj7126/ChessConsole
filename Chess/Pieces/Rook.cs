﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    internal class Rook : Piece
    {
        public override List<Vector> getAttack(Vector selfPos, ref Piece[,] board)
        {
            List<Vector> tosend = new List<Vector>();
            for (int d = 0; d < 4; d++) // for all direction
            {
                for (int m = 1; m < 8; m++) // for max movement
                {
                    Vector thisPos = posFromData(selfPos, d, m);
                    if (-1 < thisPos.x && thisPos.x < 8 && -1 < thisPos.y && thisPos.y < 8)
                    {
                        if (board[thisPos.x, thisPos.y].isWhite != isWhite || board[thisPos.x, thisPos.y].DisplayName == ' ')
                            tosend.Add(thisPos);

                        if (board[thisPos.x, thisPos.y].DisplayName != ' ')
                            break;
                    }
                }
            }
            return tosend;
        }

        public override List<Vector> getMovement(Vector selfPos, ref Piece[,] board)
        {
            return getAttack(selfPos, ref board);
        }

        private Vector posFromData(Vector selfPos, int d, int m)
        {
            if (d == 0)
            {
                return new Vector(selfPos.x + m, selfPos.y);
            }
            else if (d == 1)
            {
                return new Vector(selfPos.x - m, selfPos.y);
            }
            else if (d == 2)
            {
                return new Vector(selfPos.x, selfPos.y + m);
            }
            else
            {
                return new Vector(selfPos.x, selfPos.y - m);
            }
        }

        public Rook(bool color)
        {
            DisplayName = 'R';
            isWhite = color; // true means that the piece is whte, otherewise its black
        }
    }
}