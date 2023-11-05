using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace hyhy.game
{
    [System.Serializable]
    public class Cell
    {
        public int Value = 0;
    }

    [System.Serializable]
    public class CellGroup
    {
        [SerializeField] private int row;
        [SerializeField] private int col;
        [SerializeField] private Cell[] currnetCells;

        public Cell[] Child
        {
            get
            {
                return currnetCells;
            }
        }

        public void IntiCell(int row, int col)
        {
            this.row = row;
            this.col = col;
            currnetCells = new Cell[row * col];
            for (int i = 0; i < currnetCells.Length; i++)
            {
                currnetCells[i] = new Cell();
            }
        }

        public bool IsGameOver()
        {
            Queue<Cell[]> q = new Queue<Cell[]>();

            for (int i = 0; i < col; i++)
            {
                Cell[] c = new Cell[row];
                for (int j = 0; j < row; j++)
                {
                    c[j] = currnetCells[i * col + j];
                }
                q.Enqueue(c);
            }

            for (int i = 0; i < row; i++)
            {
                Cell[] c = new Cell[col];
                for (int j = 0; j < col; j++)
                {
                    c[j] = currnetCells[row + col * i];
                }
                q.Enqueue(c);
            }

            while (q.Count > 0)
            {
                int temp = 0;
                Cell[] curCell = q.Dequeue();
                for (int i = 0; i < curCell.Length; i++)
                {
                    if (curCell[i].Value == 0 || temp == curCell[i].Value)
                        return false;
                    temp = curCell[i].Value;
                }
            }
            return true;
        }

        public void GenerateNoneCell()
        {
            List<Cell> NoneList = new List<Cell>();
            for (int i = 0; i < currnetCells.Length; i++)
            {
                if (currnetCells[i].Value == 0)
                {
                    NoneList.Add(currnetCells[i]);
                }
            }

            if (NoneList.Count > 0)
            {
                int RdId = UnityEngine.Random.Range(0, NoneList.Count);
                NoneList[RdId].Value = 2;
            }
        }

        public void Moveion(PlayerInput direction)
        {
            if (direction == PlayerInput.Right)
            {
                MoveRight();
            }
            else if (direction == PlayerInput.Left)
            {
                MoveLeft();
            }
            else if (direction == PlayerInput.Up)
            {
                MoveUp();
            }
            else if (direction == PlayerInput.Down)
            {
                MoveDown();
            }
        }

        private void MoveRight()
        {
            for (int colNum = 0; colNum < col; colNum++)
            {
                int start = col * colNum;
                int end = start + row;
                Cell[] cel = new Cell[row];
                for (int i = end - 1; i >= start; i--)
                {
                    cel[end - 1 - i] = currnetCells[i];

                }
                StackCell(cel);
                BubbleSortZore(cel);
            }
        }

        private void MoveLeft()
        {
            for (int colNum = 0; colNum < col; colNum++)
            {
                int start = col * colNum;
                int end = start + row;
                Cell[] cel = new Cell[row];
                for (int i = start; i < end; i++)
                {
                    cel[i - start] = currnetCells[i];
                }
                StackCell(cel);
                BubbleSortZore(cel);
            }
        }

        private void MoveUp()
        {
            for (int rowNum = 0; rowNum < row; rowNum++)
            {
                Cell[] cel = new Cell[col];
                for (int i = 0; i < col; i++)
                {
                    cel[i] = currnetCells[rowNum + col * i];
                }
                StackCell(cel);
                BubbleSortZore(cel);
            }
        }

        private void MoveDown()
        {
            for (int rowNum = 0; rowNum < row; rowNum++)
            {
                Cell[] cel = new Cell[col];
                for (int i = col - 1; i >= 0; i--)
                {
                    cel[col - 1 - i] = currnetCells[rowNum + col * i];

                }

                StackCell(cel);
                BubbleSortZore(cel);
            }
        }

        private void StackCell(Cell[] cell)
        {
            int prvVal = 0;
            int prvId = 0;

            for (int i = 0; i < cell.Length; i++)
            {
                if (cell[i].Value == 0)
                    continue;

                if (prvVal == cell[i].Value)
                {
                    cell[prvId].Value = 0;
                    cell[i].Value *= 2;
                    prvId = 0;
                    prvVal = 0;
                }
                else
                {
                    prvId = i;
                    prvVal = cell[i].Value;
                }
            }
        }

        private void BubbleSortZore(Cell[] cell)
        {
            int nonZeroIndex = 0;

            for (int i = 0; i < cell.Length; i++)
            {
                if (cell[i].Value != 0)
                {
                    var temp = cell[i].Value;
                    cell[i].Value = cell[nonZeroIndex].Value;
                    cell[nonZeroIndex].Value = temp;
                    nonZeroIndex++;
                }
            }
        }

        private void ShowLog()
        {
            string s = "";
            for (int i = 0; i < currnetCells.Length; i++)
            {
                s += currnetCells[i].Value + ", ";
                if (i % col == col - 1)
                    s += "\n";
            }
            Debug.Log(s);
        }
    }
}
