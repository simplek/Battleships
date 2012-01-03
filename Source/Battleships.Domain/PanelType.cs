namespace Battleships.Domain
{
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