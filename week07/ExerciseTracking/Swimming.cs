public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MeterToMiles = 0.000621371;

    public Swimming(string date, double length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMeters * MeterToMiles;  // laps * 50 meters converted to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Length) * 60;            // mph
    }

    public override double GetPace()
    {
        return Length / GetDistance();                    // min per mile
    }
}
