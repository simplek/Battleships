using System;
using System.Collections.Generic;

namespace Battleships.Domain
{
    public class BattleshipsGame
    {
        private readonly int _gridSize;
        private int _setupMoveCount;
        private bool _preceededByStartMove;
        private int _startMoveColumnIndex;
        private int _startMoveRowIndex;

        private const int PatrolBoatsPlaced = 2;
        private const int CruiserPlaced = 5;
        private const int SubmarinePlaced = 8;
        private const int BattleShipPlaced = 12;
        private const int AircraftCarrierPlaced = 17;
        

        public BattleshipsGame(int gridSize)
        {
            _gridSize = gridSize;
            _setupMoveCount = 0;
        }

        public GridUpdateEvent GetMoveResults(bool isPlayerGrid, int columnIndex, int rowIndex)
        {
            PanelType panelResult;

            // TODO: move this logic to separate objects, it's a bit hacky as guard clauses like this
            if (_setupMoveCount < PatrolBoatsPlaced && isPlayerGrid)
            {
                panelResult = PanelType.PatrolBoat;
            }
            else if (_setupMoveCount < CruiserPlaced && isPlayerGrid)
            {
                panelResult = PanelType.Cruiser;
            }
            else if (_setupMoveCount < SubmarinePlaced && isPlayerGrid)
            {
                panelResult = PanelType.Submarine;
            }
            else if (_setupMoveCount < BattleShipPlaced && isPlayerGrid)
            {
                panelResult = PanelType.Battleship;
            }
            else if (_setupMoveCount < AircraftCarrierPlaced && isPlayerGrid)
            {
                panelResult = PanelType.AircraftCarrier;
            }
            else
            {
                return GetAttackMoveResults(isPlayerGrid, columnIndex, rowIndex);
            }

            var updateList = new List<GridUpdate>();
            string statusMessage = String.Empty;

            if (_preceededByStartMove && IsMoveValid(columnIndex, rowIndex, _startMoveColumnIndex, _startMoveRowIndex, panelResult))
            {
                var startingSpaceGridUpdate = new GridUpdate
                {
                    ColumnIndexToUpdate = columnIndex,
                    RowIndexToUpdate = rowIndex,
                    IsPlayerGrid = true,
                    PanelType = panelResult
                };

                var endingSpaceGridUpdate = new GridUpdate
                {
                    ColumnIndexToUpdate = _startMoveColumnIndex,
                    RowIndexToUpdate = _startMoveRowIndex,
                    IsPlayerGrid = true,
                    PanelType = panelResult
                };

                updateList.Add(endingSpaceGridUpdate);
                updateList.Add(startingSpaceGridUpdate);

                statusMessage = String.Empty;
            }
            else
            {
                return GetFirstPlacingMoveResult(columnIndex, rowIndex, panelResult);
            }
            
            _setupMoveCount += updateList.Count;
            return new GridUpdateEvent(updateList, statusMessage);
        }

        private bool IsMoveValid(int columnIndex, int rowIndex, int startMoveColumnIndex, int startMoveRowIndex, PanelType panelResult)
        {
            // ship length is the difference between the start and end space, not the total number of spaces
            int shipLength;

            switch (panelResult)
            {
                case PanelType.AircraftCarrier:
                    shipLength = 4;
                    break;
                case PanelType.Battleship:
                    shipLength = 3;
                    break;
                case PanelType.Submarine:
                    shipLength = 2;
                    break;
                case PanelType.Cruiser:
                    shipLength = 2;
                    break;
                case PanelType.PatrolBoat:
                    shipLength = 1;
                    break;
                default:
                    return false;
            }

            var rowDifference = Math.Abs(rowIndex - startMoveRowIndex);
            var columnDifference = Math.Abs(columnIndex - startMoveColumnIndex);

            return (rowDifference == 0 && columnDifference == shipLength) || (columnDifference == 0 && rowDifference == shipLength);
        }

        private GridUpdateEvent GetFirstPlacingMoveResult(int columnIndex, int rowIndex, PanelType panelResult)
        {
            _preceededByStartMove = true;
            _startMoveColumnIndex = columnIndex;
            _startMoveRowIndex = rowIndex;

            var summary = "Place the other end of the " + panelResult;

            return new GridUpdateEvent(new List<GridUpdate>(), summary);
        }

        private GridUpdateEvent GetAttackMoveResults(bool isPlayerGrid, int columnIndex, int rowIndex)
        {
            return new GridUpdateEvent();
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
