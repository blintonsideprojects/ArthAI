public class GameDate
{
    private int Day;
    private int Month;
    private int Year;

    public GameDate(int d, int m, int y)
    {
        Day = d;
        Month = m;
        Year = y;
    }

    // TODO: Combine these methods
    public bool PastDate(GameDate compareDate)
    {
        if ((Year > compareDate.Year) ||
            (Year == compareDate.Year && Month > compareDate.Month) ||
            (Year == compareDate.Year && Month == compareDate.Month && Day > compareDate.Day))
        {
            return true;
        }

        return false;
    }
    
    // TODO: Double check logic here.
    public bool AtOrPastDate(GameDate compareDate)
    {
        if (compareDate.Year < Year)
        {
            return false;
        }

        if (compareDate.Year == Year)
        {
            if (compareDate.Month < Month)
            {
                return false;
            }

            if (compareDate.Month == Month)
            {
                if (compareDate.Day < Day)
                {
                    return false;
                }
            }

        }

        return true;
    }

    public void IncrementDay()
    {
        if (Day < 30)
        {
            Day++;
        }
        else
        {
            Day = 1;
            if (Month < 12)
            {
                Month++;
            }
            else
            {
                Month = 1;
                Year++;
            }
        }
    }
}
