using System;
using System.Collections.Generic;
using System.Text;
using epam_task_1.Figures;
using epam_task_1.Enums;

namespace epam_task_1.FieldElements
{
    class Field
    {
        private Figure[,] field = new Figure[8,8];

        public Figure this[int i, int j]
        {
            get { return field[i, j]; }
            set { field[i, j] = value; }
        }

        public Field()
        {
            field[1, 0] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 1] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 2] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 3] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 4] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 5] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 6] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);
            field[1, 7] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), true, true);

            field[6, 0] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 1] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 2] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 3] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 4] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 5] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 6] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);
            field[6, 7] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), true, true);

            field[0, 0] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), true);
            field[0, 7] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), true);
            field[7, 0] = new Rook(NameEnum.Rook.ToString(), ColorEnum.White.ToString(), true);
            field[7, 7] = new Rook(NameEnum.Rook.ToString(), ColorEnum.White.ToString(), true);

            field[0, 1] = new Khight(NameEnum.Knight.ToString(), ColorEnum.Black.ToString());
            field[0, 6] = new Khight(NameEnum.Knight.ToString(), ColorEnum.Black.ToString());
            field[7, 1] = new Khight(NameEnum.Knight.ToString(), ColorEnum.White.ToString());
            field[7, 6] = new Khight(NameEnum.Knight.ToString(), ColorEnum.White.ToString());

            field[0, 2] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.Black.ToString());
            field[0, 5] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.Black.ToString());
            field[7, 2] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.White.ToString());
            field[7, 5] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.White.ToString());

            field[0, 3] = new Queen(NameEnum.Queen.ToString(), ColorEnum.Black.ToString());
            field[7, 3] = new Queen(NameEnum.Queen.ToString(), ColorEnum.White.ToString());

            field[0, 4] = new King(NameEnum.King.ToString(), ColorEnum.Black.ToString(), true);
            field[7, 4] = new King(NameEnum.King.ToString(), ColorEnum.White.ToString(), true);
        }
    }
}
