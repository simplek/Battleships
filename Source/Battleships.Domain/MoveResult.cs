namespace Battleships.Domain
{
    public class MoveResult
    {
        public PanelType PanelType { get; set; }
        public bool IsPlayerGrid { get; set; }

        public int RowIndexToUpdate { get; set; }
        public int ColumnIndexToUpdate { get; set; }
    }
}