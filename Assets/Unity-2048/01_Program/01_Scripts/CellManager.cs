using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hyhy.game
{
    public class CellManager : MonoBehaviour
    {
        [SerializeField] private int row = 4;
        [SerializeField] private int col = 4;
        [SerializeField] private CellGroup Cells;

        private void Awake()
        {
            Cells.IntiCell(row, col);
        }

        public void Moveion(PlayerInput input)
        {
            if (input == PlayerInput.Right)
            {

            }
        }
    }
}
