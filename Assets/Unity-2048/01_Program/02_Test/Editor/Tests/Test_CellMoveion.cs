using hyhy.game;
using NUnit.Framework;

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

        #region Test Move Row Right or Left
        private void SetCellRowValue(Cell[] cells, int row, int firstId)
        {
            for (int i = 0; i < row; i++)
            {
                cells[firstId + i * row].Value = 2;
            }
        }

        [TestCase(PlayerInput.Left, 0)]
        [TestCase(PlayerInput.Left, 1)]
        [TestCase(PlayerInput.Left, 2)]
        [TestCase(PlayerInput.Left, 3)]
        [TestCase(PlayerInput.Right, 0)]
        [TestCase(PlayerInput.Right, 1)]
        [TestCase(PlayerInput.Right, 2)]
        [TestCase(PlayerInput.Right, 3)]
        public void TestMove_1_RorL(PlayerInput dir, int id1)
        {
            CellGroup.IntiCell(4, 4);
            SetCellRowValue(CellGroup.Child, 4, id1);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Right)
            {
                expected = new int[]
                        {
                            0, 0, 0, 2,
                            0, 0, 0, 2,
                            0, 0, 0, 2,
                            0, 0, 0, 2,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            2, 0, 0, 0,
                            2, 0, 0, 0,
                            2, 0, 0, 0,
                            2, 0, 0, 0,
                        };
            }
            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(PlayerInput.Left, 0, 1)]
        [TestCase(PlayerInput.Left, 0, 2)]
        [TestCase(PlayerInput.Left, 0, 3)]
        [TestCase(PlayerInput.Left, 1, 2)]
        [TestCase(PlayerInput.Left, 1, 3)]
        [TestCase(PlayerInput.Left, 2, 3)]
        [TestCase(PlayerInput.Right, 0, 1)]
        [TestCase(PlayerInput.Right, 0, 2)]
        [TestCase(PlayerInput.Right, 0, 3)]
        [TestCase(PlayerInput.Right, 1, 2)]
        [TestCase(PlayerInput.Right, 1, 3)]
        [TestCase(PlayerInput.Right, 2, 3)]
        public void TestMove_2_RorL(PlayerInput dir, int id1, int id2)
        {
            CellGroup.IntiCell(4, 4);
            SetCellRowValue(CellGroup.Child, 4, id1);
            SetCellRowValue(CellGroup.Child, 4, id2);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Right)
            {
                expected = new int[]
                        {
                            0, 0, 0, 4,
                            0, 0, 0, 4,
                            0, 0, 0, 4,
                            0, 0, 0, 4,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            4, 0, 0, 0,
                            4, 0, 0, 0,
                            4, 0, 0, 0,
                            4, 0, 0, 0,
                        };
            }
            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(PlayerInput.Left, 0, 1, 2)]
        [TestCase(PlayerInput.Left, 0, 1, 3)]
        [TestCase(PlayerInput.Left, 1, 2, 3)]
        [TestCase(PlayerInput.Right, 0, 1, 2)]
        [TestCase(PlayerInput.Right, 0, 1, 3)]
        [TestCase(PlayerInput.Right, 1, 2, 3)]
        public void TestMove_3_RorL(PlayerInput dir, int id1, int id2, int id3)
        {
            CellGroup.IntiCell(4, 4);
            SetCellRowValue(CellGroup.Child, 4, id1);
            SetCellRowValue(CellGroup.Child, 4, id2);
            SetCellRowValue(CellGroup.Child, 4, id3);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Right)
            {
                expected = new int[]
                        {
                            0, 0, 2, 4,
                            0, 0, 2, 4,
                            0, 0, 2, 4,
                            0, 0, 2, 4,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            4, 2, 0, 0,
                            4, 2, 0, 0,
                            4, 2, 0, 0,
                            4, 2, 0, 0,
                        };
            }
            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(PlayerInput.Left, 0, 1, 2, 3)]
        [TestCase(PlayerInput.Right, 0, 1, 2, 3)]
        public void TestMove_4_RorL(PlayerInput dir, int id1, int id2, int id3, int id4)
        {
            CellGroup.IntiCell(4, 4);
            SetCellRowValue(CellGroup.Child, 4, id1);
            SetCellRowValue(CellGroup.Child, 4, id2);
            SetCellRowValue(CellGroup.Child, 4, id3);
            SetCellRowValue(CellGroup.Child, 4, id4);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Right)
            {
                expected = new int[]
                        {
                            0, 0, 4, 4,
                            0, 0, 4, 4,
                            0, 0, 4, 4,
                            0, 0, 4, 4,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            4, 4, 0, 0,
                            4, 4, 0, 0,
                            4, 4, 0, 0,
                            4, 4, 0, 0,
                        };
            }
            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }
        #endregion

        #region Test Move Col Up or Down
        private void SetCellColValue(Cell[] cells, int col, int firstId)
        {
            for (int i = 0; i < col; i++)
            {
                cells[firstId + i].Value = 2;
            }
        }

        [TestCase(PlayerInput.Up, 0)]
        [TestCase(PlayerInput.Up, 4)]
        [TestCase(PlayerInput.Up, 8)]
        [TestCase(PlayerInput.Up, 12)]
        [TestCase(PlayerInput.Down, 0)]
        [TestCase(PlayerInput.Down, 4)]
        [TestCase(PlayerInput.Down, 8)]
        [TestCase(PlayerInput.Down, 12)]
        public void TestMove_1_UorD(PlayerInput dir, int id1)
        {
            CellGroup.IntiCell(4, 4);
            SetCellColValue(CellGroup.Child, 4, id1);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Up)
            {
                expected = new int[]
                        {
                            2, 2, 2, 2,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            2, 2, 2, 2,
                        };
            }

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }

        [TestCase(PlayerInput.Up, 0, 4)]
        [TestCase(PlayerInput.Up, 0, 8)]
        [TestCase(PlayerInput.Up, 0, 12)]
        [TestCase(PlayerInput.Up, 4, 8)]
        [TestCase(PlayerInput.Up, 4, 12)]
        [TestCase(PlayerInput.Up, 8, 12)]
        [TestCase(PlayerInput.Down, 0, 4)]
        [TestCase(PlayerInput.Down, 0, 8)]
        [TestCase(PlayerInput.Down, 0, 12)]
        [TestCase(PlayerInput.Down, 4, 8)]
        [TestCase(PlayerInput.Down, 4, 12)]
        [TestCase(PlayerInput.Down, 8, 12)]
        public void TestMove_2_UorD(PlayerInput dir, int id1, int id2)
        {
            CellGroup.IntiCell(4, 4);
            SetCellColValue(CellGroup.Child, 4, id1);
            SetCellColValue(CellGroup.Child, 4, id2);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Up)
            {
                expected = new int[]
                        {
                            4, 4, 4, 4,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            4, 4, 4, 4,
                        };
            }
            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }


        [TestCase(PlayerInput.Up, 0, 4, 8)]
        [TestCase(PlayerInput.Up, 0, 4, 12)]
        [TestCase(PlayerInput.Up, 4, 8, 12)]
        [TestCase(PlayerInput.Down, 0, 4, 8)]
        [TestCase(PlayerInput.Down, 0, 4, 12)]
        [TestCase(PlayerInput.Down, 4, 8, 12)]
        public void TestMove_3_UorD(PlayerInput dir, int id1, int id2, int id3)
        {
            CellGroup.IntiCell(4, 4);
            SetCellColValue(CellGroup.Child, 4, id1);
            SetCellColValue(CellGroup.Child, 4, id2);
            SetCellColValue(CellGroup.Child, 4, id3);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Up)
            {
                expected = new int[]
                        {
                            4, 4, 4, 4,
                            2, 2, 2, 2,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            2, 2, 2, 2,
                            4, 4, 4, 4,
                        };
            }

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }


        [TestCase(PlayerInput.Up, 0, 4, 8, 12)]
        [TestCase(PlayerInput.Down, 0, 4, 8, 12)]
        public void TestMove_4_UorD(PlayerInput dir, int id1, int id2, int id3, int id4)
        {
            CellGroup.IntiCell(4, 4);
            SetCellColValue(CellGroup.Child, 4, id1);
            SetCellColValue(CellGroup.Child, 4, id2);
            SetCellColValue(CellGroup.Child, 4, id3);
            SetCellColValue(CellGroup.Child, 4, id4);
            CellGroup.Moveion(dir);
            int[] expected = new int[4];
            if (dir == PlayerInput.Up)
            {
                expected = new int[]
                        {
                            4, 4, 4, 4,
                            4, 4, 4, 4,
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                        };
            }
            else
            {
                expected = new int[]
                        {
                            0, 0, 0, 0,
                            0, 0, 0, 0,
                            4, 4, 4, 4,
                            4, 4, 4, 4,
                        };
            }

            CollectionAssert.AreEqual(expected, GetCellsValue(CellGroup.Child));
        }
        #endregion

        #region Test Generate Cell

        [Test]
        public void Test_OneRowGenerateCell()
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.GenerateNoneCell();
            Assert.AreEqual(1, GetCellCount(CellGroup.Child));
            CellGroup.GenerateNoneCell();
            Assert.AreEqual(2, GetCellCount(CellGroup.Child));
            CellGroup.GenerateNoneCell();
            Assert.AreEqual(3, GetCellCount(CellGroup.Child));
            CellGroup.GenerateNoneCell();
            Assert.AreEqual(4, GetCellCount(CellGroup.Child));
        }

        [Test]
        public void Test_StackCellAfterGenerateCell()
        {
            CellGroup.IntiCell(4, 4);
            CellGroup.Child[0].Value = 2;
            CellGroup.Child[1].Value = 2;
            CellGroup.Moveion(PlayerInput.Left);
            CellGroup.GenerateNoneCell();
            Assert.AreEqual(2, GetCellCount(CellGroup.Child));
        }

        [Test]
        public void Test_GameOver_True()
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[0].Value = 2;
            CellGroup.Child[1].Value = 4;
            CellGroup.Child[2].Value = 8;
            CellGroup.Child[3].Value = 16;
            Assert.AreEqual(true, CellGroup.IsGameOver());
        }
        [Test]
        public void Test_GameOver_False()
        {
            CellGroup.IntiCell(4, 1);
            CellGroup.Child[0].Value = 2;
            CellGroup.Child[1].Value = 2;
            CellGroup.Child[2].Value = 2;
            CellGroup.Child[3].Value = 2;
            Assert.AreEqual(false, CellGroup.IsGameOver());
        }

        private int GetCellCount(Cell[] cells)
        {
            int result = 0;
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].Value != 0)
                    result++;
            }
            return result;
        }

        #endregion

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
