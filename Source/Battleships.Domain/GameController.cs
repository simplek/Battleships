using System.Collections.Generic;

namespace Battleships.Domain
{
    public class GameController
    {
        private int _gridSize;

        public GameController(int gridSize)
        {
            _gridSize = gridSize;
        }

        public List<MoveResult> ProcessMove(bool isPlayerGrid, int columnIndex, int rowIndex)
        {
            var fakeResult = new MoveResult
            {
                PanelType = PanelType.Cruiser,
                ColumnIndexToUpdate = 0,
                RowIndexToUpdate = 0,
                IsPlayerGrid = true
            };

            return new List<MoveResult>{fakeResult};
        }

        public List<MoveResult> ResetGame()
        {
            var fakeClearResults = new List<MoveResult>();

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    //
                }
            }

            return fakeClearResults;
        }
    }

    public enum PanelType
    {
        Unknown,
        Miss,
        Hit,

        // 5-length ship
        AircraftCarrier,

        // 4-length ship
        Battleship,

        // 3-length ships
        Submarine,
        Cruiser,

        // 2-length ship
        PatrolBoat
    }
}
