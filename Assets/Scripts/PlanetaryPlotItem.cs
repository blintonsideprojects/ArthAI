public class PlanetaryPlotItem : PlotItem
{
    /// <summary>
    /// Planet id where the plot item occurs
    /// </summary>
    private string _planetId;

    /// <summary>
    /// Location of plot item
    /// </summary>
    private int _minPlanetX;
    private int _minPlanetY;
    private int _maxPlanetX;
    private int _maxPlanetY;

    public string PlanetID => _planetId;

    public PlanetaryPlotItem(GameDate minDate, GameDate maxDate, string planetId, int minX, int minY, int maxX, int maxY) : base(minDate, maxDate)
    {
        _minPlanetX = minX;
        _minPlanetY = minY;
        _maxPlanetX = maxX;
        _maxPlanetY = maxY;
        _planetId = planetId;
    }
}
