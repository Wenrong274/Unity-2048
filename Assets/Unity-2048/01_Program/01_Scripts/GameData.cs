using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyhy
{
    public class GameData : MonoBehaviour
    {
        [SerializeField] private int row = 4;
        [SerializeField] private int col = 4;
        [SerializeField] private int[] cells;

        private void Awake()
        {
            cells = new int[row * col];
        }

        private void Start()
        {
            InitCell();
            LogCell();
        }


        private void InitCell()
        {
            List<int> zeroCell = new List<int>();
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == 0)
                {
                    zeroCell.Add(i);
                }
            }
            int randomId = Random.Range(0, zeroCell.Count);
            cells[randomId] = 2;
        }

        private void LogCell()
        {
            string ss = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    ss += cells[i * row + j] + ", ";
                }
                ss += "\n";
            }
            Debug.Log(ss);
        }

        public void SetPlayerInput(PlayerInput input)
        {
            if (input == PlayerInput.Left)
            {

            }
        }
    }
}
