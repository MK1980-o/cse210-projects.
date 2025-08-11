public class Running : Activity
{
    private double _distance; // miles

    public Running(string date, double length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Length) * 60;  // miles per hour
    }

    public override double GetPace()
    {
        return Length / GetDistance();          // min per mile
    }
}
