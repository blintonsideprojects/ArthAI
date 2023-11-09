public class PlotItem
{
    /// <summary>
    /// Date range for this plot item
    /// </summary>
    private GameDate _minDate;
    private GameDate _maxDate;
    private bool _plotItemComplete;

    public PlotItem(GameDate minDate, GameDate maxDate)
    {
        _minDate = minDate;
        _maxDate = maxDate;
        _plotItemComplete = false;
    }
    public virtual bool InitiatePlotItem()
    {
        return _minDate.AtOrPastDate(ArthAI.Instance.CurrentDate) && !_maxDate.PastDate(ArthAI.Instance.CurrentDate) &&
               !_plotItemComplete;
    }

    public void CompletePlotItem()
    {
        _plotItemComplete = true;
    }
}
