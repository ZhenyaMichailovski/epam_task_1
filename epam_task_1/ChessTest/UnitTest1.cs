using epam_task_1.FieldElements;
using epam_task_1.Figures;
using epam_task_1.Enums;
using NUnit.Framework;

namespace ChessTest
{
    public class Tests
    {
        private FieldLogic fieldLogic;
        private Field field;

        [SetUp]
        public void Setup()
        {
            fieldLogic = new FieldLogic();
            
        }

        [Test]
        [TestCase(1, 1, 2, 1)]
        [TestCase(1, 1, 3, 1)]
        [TestCase(6, 1, 5, 1)]
        [TestCase(6, 1, 4, 1)]
        public void PawnMotion_WhenNothingStandsInTheWay_ThePawnMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            fieldLogic.SetPawnInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }   

        [Test]
        [TestCase(1, 1, 2, 2)]
        [TestCase(1, 1, 2, 0)]
        public void PawnMotionForBlackFigures_WhenPawnMovesOnEnemy_ThePawnMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[newRow, newCol] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.White.ToString(), false);

            fieldLogic.SetPawnInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }
        
        [Test]
        [TestCase(6, 1, 5, 2)]
        [TestCase(6, 1, 5, 0)]
        public void PawnMotionForWhiteFigures_WhenPawnMovesOnEnemy_ThePawnMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[newRow, newCol] = new Pawn(NameEnum.Pawn.ToString(), ColorEnum.Black.ToString(), false);

            fieldLogic.SetPawnInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 2, 6)]
        [TestCase(4, 4, 2, 2)]
        [TestCase(4, 4, 5, 3)]
        [TestCase(4, 4, 5, 5)]
        public void BishopMotion_WhenNothingStandsInTheWay_TheBishopMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.Black.ToString());

            fieldLogic.SetBishopInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }
        
        [Test]
        [TestCase(4, 4, 2, 6)]
        [TestCase(4, 4, 2, 2)]
        [TestCase(4, 4, 5, 3)]
        [TestCase(4, 4, 5, 5)]
        public void BishopMotion_WhenBishopMovesOnEnemy_TheBishopMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[newRow, newCol] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.White.ToString());
            field[nowRow, nowCol] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.Black.ToString());

            fieldLogic.SetBishopInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 0)]
        [TestCase(4, 4, 4, 7)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 2, 4)]
        public void RookMotion_WhenNothingStandsInTheWay_TheRookMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), false);

            fieldLogic.SetRookInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 0)]
        [TestCase(4, 4, 4, 7)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 2, 4)]
        public void RookMotion_WhenRookMovesOnEnemy_TheRookMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[newRow, newCol] = new Bishop(NameEnum.Bishop.ToString(), ColorEnum.White.ToString());
            field[nowRow, nowCol] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), false);

            fieldLogic.SetRookInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 2, 3)]
        [TestCase(4, 4, 2, 5)]
        [TestCase(4, 4, 3, 2)]
        [TestCase(4, 4, 5, 2)]
        [TestCase(4, 4, 3, 6)]
        [TestCase(4, 4, 5, 6)]
        [TestCase(3, 4, 5, 3)]
        [TestCase(3, 4, 5, 5)]
        public void KnightMotion_WhenNothingStandsInTheWay_TheKnightMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Khight(NameEnum.Knight.ToString(), ColorEnum.Black.ToString());

            fieldLogic.SetKnightInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 2, 3)]
        [TestCase(4, 4, 2, 5)]
        [TestCase(4, 4, 3, 2)]
        [TestCase(4, 4, 5, 2)]
        [TestCase(4, 4, 3, 6)]
        [TestCase(4, 4, 5, 6)]
        [TestCase(3, 4, 5, 3)]
        [TestCase(3, 4, 5, 5)]
        public void KnightMotion_WhenKnightMovesOnEnemy_TheKnightMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Khight(NameEnum.Knight.ToString(), ColorEnum.Black.ToString());
            field[nowRow, nowCol] = new Khight(NameEnum.Knight.ToString(), ColorEnum.White.ToString());

            fieldLogic.SetKnightInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 0)]
        [TestCase(4, 4, 4, 7)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 2, 4)]
        [TestCase(4, 4, 2, 6)]
        [TestCase(4, 4, 2, 2)]
        [TestCase(4, 4, 5, 3)]
        [TestCase(4, 4, 5, 5)]
        public void QueenMotion_WhenQueenMovesOnEnemy_TheQueenMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Queen(NameEnum.Queen.ToString(), ColorEnum.White.ToString());
            field[newRow, newCol] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), false);

            fieldLogic.SetQueenInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 0)]
        [TestCase(4, 4, 4, 7)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 2, 4)]
        [TestCase(4, 4, 2, 6)]
        [TestCase(4, 4, 2, 2)]
        [TestCase(4, 4, 5, 3)]
        [TestCase(4, 4, 5, 5)]
        public void QueenMotion_WhenNothingStandsInTheWay_TheQueenMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new Queen(NameEnum.Queen.ToString(), ColorEnum.White.ToString());

            fieldLogic.SetQueenInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 5)]
        [TestCase(4, 4, 4, 3)]
        [TestCase(4, 4, 3, 4)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 3, 5)]
        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 3, 3)]
        [TestCase(4, 4, 5, 3)]
        public void KingMotion_WhenNothingStandsInTheWay_TheKingMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new King(NameEnum.King.ToString(), ColorEnum.White.ToString(), false);

            fieldLogic.SetKingInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }

        [Test]
        [TestCase(4, 4, 4, 5)]
        [TestCase(4, 4, 4, 3)]
        [TestCase(4, 4, 3, 4)]
        [TestCase(4, 4, 5, 4)]
        [TestCase(4, 4, 3, 5)]
        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 3, 3)]
        [TestCase(4, 4, 5, 3)]
        public void KingMotion_WhenKingMovesOnEnemy_TheKingMustMoveToTheSpecifiedPlace(int nowRow, int nowCol, int newRow, int newCol)
        {
            field = new Field();
            field[nowRow, nowCol] = new King(NameEnum.King.ToString(), ColorEnum.White.ToString(), false);
            field[newRow, newCol] = new Rook(NameEnum.Rook.ToString(), ColorEnum.Black.ToString(), false);

            fieldLogic.SetKingInNewPosition(field, nowRow, nowCol, newRow, newCol);

            Assert.AreEqual(field[nowRow, nowCol], null);
        }
    }
}