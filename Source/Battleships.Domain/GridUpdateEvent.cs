using System.Collections.Generic;

namespace Battleships.Domain
{
    public class GridUpdateEvent
    {
        public List<GridUpdate> GridUpdates { get; set; }
        public string Summary { get; set; }

        public GridUpdateEvent(List<GridUpdate> gridUpdates, string summary)
        {
            GridUpdates = gridUpdates;
            Summary = summary;
        }
    }
}