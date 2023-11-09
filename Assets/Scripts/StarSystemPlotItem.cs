
public class StarSystemPlotItem : PlotItem
{
    private string _systemId;

    public string SystemID => _systemId;
    
    
    /// <summary>
    /// Location of plot item
    /// </summary>
    private int _minSystemX;
    private int _minSystemY;
    private int _maxSystemX;
    private int _maxSystemY;
    
    public StarSystemPlotItem(GameDate minDate, GameDate maxDate, string systemId, int minX, int minY, int maxX, int maxY) : base(minDate, maxDate)
    {
        _minSystemX = minX;
        _minSystemY = minY;
        _maxSystemX = maxX;
        _maxSystemY = maxY;
        _systemId = systemId;
    }
}
