using hyhy.game;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Test_CellMoveion
    {
        private CellGroup CellGroup;

        [SetUp]
        public void SetUp()
        {
            CellGroup = new CellGroup();
        }

        [TestCase(4, 1, 4)]
        [TestCase(4, 4, 16)]

        public void Test_CellArray(int col, int row, int expected)
        {
            CellGroup.IntiCell(row, col);
            Assert.AreEqual(expected, CellGroup.Child.Length);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test_OneColRight_Moveion(int rowId)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId].Value = 2;
            CellGroup.Moveion(PlayerInput.Right);
            int[] expected = new int[]
            {
                0, 0, 0, 2,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test_OneColLeft_Moveion(int rowId)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId].Value = 2;
            CellGroup.Moveion(PlayerInput.Left);
            int[] expected = new int[]
            {
                2, 0, 0,0,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }


        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 3)]
        [TestCase(1, 2)]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        public void Test_TwoColRight_Moveion(int rowId1, int rowId2)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId1].Value = 2;
            CellGroup.Child[rowId2].Value = 2;
            CellGroup.Moveion(PlayerInput.Right);
            int[] expected = new int[]
            {
                0, 0, 0, 4,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(0, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(1, 2, 3)]
        public void Test_ThreeColRight_Moveion(int rowId1, int rowId2, int rowId3)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId1].Value = 2;
            CellGroup.Child[rowId2].Value = 2;
            CellGroup.Child[rowId3].Value = 2;
            CellGroup.Moveion(PlayerInput.Right);
            int[] expected = new int[]
            {
                0, 0, 2, 4,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 3)]
        [TestCase(1, 2)]
        [TestCase(1, 3)]
        [TestCase(2, 3)]
        public void Test_TwoColLeft_Moveion(int rowId1, int rowId2)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId1].Value = 2;
            CellGroup.Child[rowId2].Value = 2;
            CellGroup.Moveion(PlayerInput.Left);
            int[] expected = new int[]
            {
                4, 0, 0, 0,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(0, 1, 2)]
        [TestCase(0, 1, 3)]
        [TestCase(1, 2, 3)]
        public void Test_ThreeColLeft_Moveion(int rowId1, int rowId2, int rowId3)
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[rowId1].Value = 2;
            CellGroup.Child[rowId2].Value = 2;
            CellGroup.Child[rowId3].Value = 2;
            CellGroup.Moveion(PlayerInput.Left);
            int[] expected = new int[]
            {
              4, 2, 0, 0,
            };

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }


        private int[] GetCellsValue(Cell[] cells)
        {
            int[] result = new int[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                result[i] = cells[i].Value;
            }
            return result;
        }
    }
}
