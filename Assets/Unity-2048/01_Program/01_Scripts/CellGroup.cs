using System.Linq;
using UnityEngine;

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
        }

        private void MoveRight()
        {
            for (int colNum = 0; colNum < col; colNum++)
            {
                int start = col * colNum;
                int end = start + row;
                int count = 0;
                Cell[] cel = new Cell[row];
                for (int i = end - 1; i >= start; i--)
                {
                    cel[count++] = currnetCells[i];

                }
                RowStackCell(cel);
                RowBubbleSortZore(cel);
            }
        }

        private void MoveLeft()
        {
            for (int colNum = 0; colNum < col; colNum++)
            {
                int start = col * colNum;
                int end = start + row;
                int count = 0;
                Cell[] cel = new Cell[row];

                for (int i = start; i < end; i++)
                {
                    cel[count++] = currnetCells[i];
                }

                RowStackCell(cel);
                RowBubbleSortZore(cel);
            }
            ShowLog();

        }

        private void RowStackCell(Cell[] cell)
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

        private void RowBubbleSortZore(Cell[] cell)
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
            }
            Debug.Log(s);
        }
    }
}
