using epam_task_1.Figures;
using epam_task_1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.FieldElements
{
    public class FieldLogic
    {
        public void SetPawnInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is Pawn))
                throw new Exception("Эта фигура не является пешкой");
            if (nowColum == newColum)
            {
                if (Math.Abs(nowRow - newRow) == 1)
                {
                    if (field[newRow, newColum] == null)
                    {
                        field[newRow, newColum] = new Pawn(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                        field[nowRow, nowColum] = null;
                    }
                    else
                        throw new Exception("Невозможно переставить фигуру на это место");
                }
                else if (Math.Abs(nowRow - newRow) == 2 && ((Pawn)field[nowRow, nowColum]).IsFirtsMotion)
                {
                    if (newRow > nowRow)
                    {
                        if (field[newRow, newColum] == null && field[newRow - 1, newColum] == null)
                        {
                            field[newRow, newColum] = new Pawn(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                            field[nowRow, nowColum] = null;
                        }
                        else
                            throw new Exception("Невозможно переставить фигуру на это место");
                    }
                    else
                    {
                        if (field[newRow, newColum] == null && field[newRow + 1, newColum] == null)
                        {
                            field[newRow, newColum] = new Pawn(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                            field[nowRow, nowColum] = null;
                        }
                        else
                            throw new Exception("Невозможно переставить фигуру на это место");
                    }

                }
            }
            else if(Math.Abs(newColum - nowColum) == 1 && Math.Abs(newRow - nowRow) == 1)
            {
                if(field[newRow, newColum].Color != field[nowRow, nowColum].Color)
                {
                    field[newRow, newColum] = new Pawn(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
            
        }

        public void SetRookInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is Rook))
                throw new Exception("Эта фигура не является ладьёй");
            if (nowRow == newRow)
            {
                if(CheckingTheFiguresHorizontallyForRook(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
            }
            else if(nowColum == newColum)
            {
                if (CheckingTheFiguresVerticallyForRook(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");

        }

        public void SetBishopInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is Bishop))
                throw new Exception("Эта фигура не является слоном");
            if (Math.Abs(nowRow - newRow) == Math.Abs(newColum - nowColum))
            {
                if(CheckingTheFiguresForBishop(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Bishop(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }

        public void SetKnightInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is Khight))
                throw new Exception("Эта фигура не является конем");
            if((Math.Abs(nowRow - newRow) == 2 && Math.Abs(nowColum - newColum) == 1) || (Math.Abs(nowRow - newRow) == 1 && Math.Abs(nowColum - newColum) == 2))
                if ((field[newRow, newColum] == null || (field[nowRow, nowColum].Color != field[newRow, newColum].Color)))
                {
                    field[newRow, newColum] = new Khight(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }
        public void SetQueenInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is Queen))
                throw new Exception("Эта фигура не является королевой");
            if (nowRow == newRow)
            {
                if (CheckingTheFiguresHorizontallyForRook(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Queen(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else if (nowColum == newColum)
            {
                if (CheckingTheFiguresVerticallyForRook(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Queen(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else if (Math.Abs(nowRow - newRow) == Math.Abs(newColum - nowColum))
            {
                if (CheckingTheFiguresForBishop(field, nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Queen(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }

        public void SetKingInNewPosition(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (!(field[nowRow, nowColum] is King))
                throw new Exception("Эта фигура не является королём");
            if (field[newRow, newColum] == null || (field[nowRow, nowColum].Color != field[newRow, newColum].Color))
            {
                if(nowColum == newColum && Math.Abs(nowRow - newRow) == 1)
                {
                    field[newRow, newColum] = new King(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
                else if (nowRow == newRow && Math.Abs(nowColum - newColum) == 1)
                {
                    field[newRow, newColum] = new King(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
                else if(Math.Abs(nowRow - newRow) == 1 && Math.Abs(nowColum - newColum) == 1)
                {
                    field[newRow, newColum] = new King(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }

        public void SetCastling(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (((Rook)field[newRow, newColum]).IsFirstMotion && ((King)field[nowRow, nowColum]).IsFirstMotion)
            {
                if(nowRow == newRow)
                {
                    if(nowColum < newColum && field[nowRow, nowColum + 1] == null && field[nowRow, nowColum + 2] == null)
                    {
                        field[nowRow, nowColum + 2] = new King(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                        field[nowRow, newColum - 2] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                        field[nowRow, nowColum] = null;
                        field[nowRow, newColum] = null;
                    }
                    else if (nowColum > newColum && field[nowRow, nowColum - 1] == null && field[nowRow, nowColum - 2] == null && field[nowRow, nowColum - 3] == null)
                    {
                        field[nowRow, nowColum - 3] = new King(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                        field[nowRow, newColum + 2] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                        field[nowRow, nowColum] = null;
                        field[nowRow, newColum] = null;
                    }
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }
        private bool CheckingTheFiguresForBishop(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if(newColum > nowColum && newRow < nowRow)
            {
                for(int i = nowRow - 1, j = nowColum + 1; j < newColum; i--, j++)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if(newColum < nowColum && newRow < nowRow)
            {
                for (int i = nowRow - 1, j = nowColum - 1; j > newColum; i--, j--)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if (newColum < nowColum && newRow > nowRow)
            {
                for (int i = nowRow + 1, j = nowColum - 1; i > newRow; i++, j--)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if(newColum > nowColum && newRow > nowRow)
            {
                for (int i = nowRow + 1, j = nowColum + 1; i > newRow; i++, j++)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            return ((field[newRow, newColum] == null || field[nowRow, nowColum].Color != field[newRow, newColum].Color));

        }
        private bool CheckingTheFiguresVerticallyForRook(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if (nowRow < newRow)
            {
                for (int i = nowRow + 1; i < newRow; i++)
                {
                    if (field[i, nowColum] != null)
                        return false;
                }
                return ((field[newRow, newColum] == null || field[nowRow, nowColum].Color != field[newRow, newColum].Color));
            }
            else
            {
                for (int i = nowRow - 1; i < newRow; i--)
                {
                    if (field[i, nowColum] != null)
                        return false;
                }
                return ((field[newRow, newColum] == null || field[nowRow, nowColum].Color != field[newRow, newColum].Color));
            }
        }
        private bool CheckingTheFiguresHorizontallyForRook(Field field, int nowRow, int nowColum, int newRow, int newColum)
        {
            if(nowColum < newColum)
            {
                for(int i = nowColum + 1; i < newColum; i++)
                {
                    if (field[nowRow, i] != null)
                        return false;
                }
                return ((field[newRow, newColum] == null || field[nowRow, nowColum].Color != field[newRow, newColum].Color));
            }
            else
            {
                for(int i = nowColum - 1; i < newColum; i--)
                {
                    if (field[nowRow, i] != null)
                        return false;
                }
                return ((field[newRow, newColum] == null || field[nowRow, nowColum].Color != field[newRow, newColum].Color));
            }
        }
    }
}
