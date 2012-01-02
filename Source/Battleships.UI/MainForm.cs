using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Battleships
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupGrid(dgPlayerShips);
            SetupGrid(dgComputerShips);
        }

        private void SetupGrid(DataGridView grid)
        {
            const int gridSize = 10;

            StyleGrid(grid);
            SetCellSizing(grid, gridSize);

            var gridDataSource = GetBattleshipsGrid(gridSize);

            grid.DataSource = gridDataSource;
        }

        private static DataTable GetBattleshipsGrid(int rowCount)
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
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
