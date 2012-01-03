using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Battleships.Domain;

namespace Battleships
{
    public partial class MainForm : Form
    {
        private BattleshipsGame _battleshipsGame;
        private const bool IsPlayerGrid = true;
        const int GridSize = 10;

        public MainForm()
        {
            InitializeComponent();
            SetupGrid(dgPlayerShips);
            SetupGrid(dgComputerShips);

            _battleshipsGame = new BattleshipsGame(GridSize);
        }

        private void SetupGrid(DataGridView grid)
        {
            StyleGrid(grid);
            SetCellSizing(grid, GridSize);

            var gridDataSource = GetEmptyGridView(GridSize);

            grid.DataSource = gridDataSource;
        }

        private static DataTable GetEmptyGridView(int rowCount)
        {
            var playerGrid = new DataTable();

            for (int i = 0; i < rowCount; i++)
            {
                playerGrid.Columns.Add(new DataColumn("Column" + i, typeof (string)));
            }

            for (int i = 0; i < rowCount; i++)
            {
                playerGrid.Rows.Add(
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty
                    );
            }
            return playerGrid;
        }

        private static void SetCellSizing(DataGridView computerShips, int rowCount)
        {
            // TODO: set width programmatically
            computerShips.RowTemplate.MinimumHeight = computerShips.Height/rowCount;
        }

        private void StyleGrid(DataGridView grid)
        {
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;

            grid.ScrollBars = ScrollBars.None;
            grid.BorderStyle = BorderStyle.None;

            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void UpdateGrids(GridUpdate result)
        {
            var gridToUpdate = result.IsPlayerGrid
                ? dgPlayerShips
                : dgComputerShips;
            
            try
            {
                var cellToUpdate = gridToUpdate.Rows[result.RowIndexToUpdate].Cells[result.ColumnIndexToUpdate];
                cellToUpdate.Value = ConvertToDisplayValue(result.PanelType);
            }
            catch (Exception)
            {
                throw new ApplicationException
                    ("The game controller indicated that a certain grid space should be updated, " 
                    + "but this space does not exist on the game board.");
            }
        }

        private string ConvertToDisplayValue(PanelType panelType)
        {
            // TODO: do cooler things than a string display
            string convertedResult;

            switch (panelType)
            {
                case PanelType.Unknown:
                    convertedResult = String.Empty;
                    break;
                case PanelType.Miss:
                    convertedResult = "-";
                    break;
                case PanelType.Hit:
                    convertedResult = "X";
                    break;
                case PanelType.AircraftCarrier:
                    convertedResult = "A";
                    break;
                case PanelType.Battleship:
                    convertedResult = "B";
                    break;
                case PanelType.Submarine:
                    convertedResult = "S";
                    break;
                case PanelType.Cruiser:
                    convertedResult = "C";
                    break;
                case PanelType.PatrolBoat:
                    convertedResult = "P";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("panelType");
            }

            return convertedResult;
        }

        private void dgPlayerShips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: test that clicks aren't too rapid
            // TODO: pub/sub controller + form control

            GridUpdateEvent results = _battleshipsGame.GetMoveResults(IsPlayerGrid, e.ColumnIndex, e.RowIndex);

            UpdateBy(results);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // TODO: confirm dialog

            var results = _battleshipsGame.GetResetGameResults();
            UpdateBy(results);
        }

        private void UpdateBy(GridUpdateEvent results)
        {
            foreach (var result in results.GridUpdates)
            {
                UpdateGrids(result);
            }

            lblStatus.Text = results.Summary;
        }
    }
}
