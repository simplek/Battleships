using System.Collections.Generic;

namespace Battleships.Domain
{
    public class BattleshipsGame
    {
        private int _gridSize;

        public BattleshipsGame(int gridSize)
        {
            _gridSize = gridSize;
        }

        public GridUpdateEvent GetMoveResults(bool isPlayerGrid, int columnIndex, int rowIndex)
        {
            var fakeResult = new GridUpdate
            {
                PanelType = PanelType.Cruiser,
                ColumnIndexToUpdate = 0,
                RowIndexToUpdate = 0,
                IsPlayerGrid = true
            };

            return new GridUpdateEvent(new List<GridUpdate>{ fakeResult }, "fakestatus");
        }

        public GridUpdateEvent GetResetGameResults()
        {
            var clearResults = new List<GridUpdate>();

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    var playerGridUpdate = new GridUpdate
                    {
                        ColumnIndexToUpdate = i,
                        RowIndexToUpdate = i,
                        IsPlayerGrid = true,
                        PanelType = PanelType.Unknown
                    };

                    var computerGridUpdate = new GridUpdate
                    {
                        ColumnIndexToUpdate = i,
                        RowIndexToUpdate = i,
                        IsPlayerGrid = true,
                        PanelType = PanelType.Unknown
                    };

                    clearResults.Add(playerGridUpdate);
                    clearResults.Add(computerGridUpdate);
                }
            }

            return new GridUpdateEvent(clearResults, "Game reset.");
        }
    }
}
