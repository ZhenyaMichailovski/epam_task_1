using epam_task_1.Figures;
using epam_task_1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.FieldElements
{
    class FieldLogic
    {
        private Field field = new Field();


        public void SetPawnInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
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

        public void SetRookInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
            if(nowRow == newRow)
            {
                if(CheckingTheFiguresHorizontallyForRook(nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
            }
            else if(nowColum == newColum)
            {
                if (CheckingTheFiguresVerticallyForRook(nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Rook(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color, false);
                    field[nowRow, nowColum] = null;
                }
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");

        }

        public void SetBishopInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
            if(Math.Abs(nowRow - newRow) == Math.Abs(newColum - nowColum))
            {
                if(CheckingTheFiguresForBishop(nowRow, nowColum, newRow, newColum))
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

        public void SetKnightInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
            if((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null)
            {
                field[newRow, newColum] = new Khight(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                field[nowRow, nowColum] = null;
            }
            else
                throw new Exception("Невозможно переставить фигуру на это место");
        }
        public void SetQueenInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
            if (nowRow == newRow)
            {
                if (CheckingTheFiguresHorizontallyForRook(nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Queen(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else if (nowColum == newColum)
            {
                if (CheckingTheFiguresVerticallyForRook(nowRow, nowColum, newRow, newColum))
                {
                    field[newRow, newColum] = new Queen(field[nowRow, nowColum].Name, field[nowRow, nowColum].Color);
                    field[nowRow, nowColum] = null;
                }
                else
                    throw new Exception("Невозможно переставить фигуру на это место");
            }
            else if (Math.Abs(nowRow - newRow) == Math.Abs(newColum - nowColum))
            {
                if (CheckingTheFiguresForBishop(nowRow, nowColum, newRow, newColum))
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

        public void SetKingInNewPosition(int nowRow, int nowColum, int newRow, int newColum)
        {
            if((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null)
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

        public void SetCastling(int nowRow, int nowColum, int newRow, int newColum)
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
        private bool CheckingTheFiguresForBishop(int nowRow, int nowColum, int newRow, int newColum)
        {
            if(newColum > nowColum && newRow < nowRow)
            {
                for(int i = nowRow, j = nowColum; j < newColum; i--, j++)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if(newColum < nowColum && newRow < nowRow)
            {
                for (int i = nowRow, j = nowColum; j > newColum; i--, j--)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if (newColum < nowColum && newRow > nowRow)
            {
                for (int i = nowRow, j = nowColum; i > newRow; i++, j--)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            else if(newColum > nowColum && newRow > nowRow)
            {
                for (int i = nowRow, j = nowColum; i > newRow; i++, j++)
                {
                    if (field[i, j] != null)
                        return false;
                }
            }
            return ((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null);

        }
        private bool CheckingTheFiguresVerticallyForRook(int nowRow, int nowColum, int newRow, int newColum)
        {
            if (nowRow < newRow)
            {
                for (int i = nowRow; i < nowRow; i++)
                {
                    if (field[i, nowColum] != null)
                        return false;
                }
                return ((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null);
            }
            else
            {
                for (int i = nowRow; i < nowRow; i--)
                {
                    if (field[i, nowColum] != null)
                        return false;
                }
                return ((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null);
            }
        }
        private bool CheckingTheFiguresHorizontallyForRook(int nowRow, int nowColum, int newRow, int newColum)
        {
            if(nowColum < newColum)
            {
                for(int i = nowColum; i < newColum; i++)
                {
                    if (field[nowRow, i] != null)
                        return false;
                }
                return ((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null);
            }
            else
            {
                for(int i = nowColum; i < newColum; i--)
                {
                    if (field[nowRow, i] != null)
                        return false;
                }
                return ((field[nowRow, nowColum].Color != field[newRow, newColum].Color) || field[newRow, newColum] == null);
            }
        }
    }
}
