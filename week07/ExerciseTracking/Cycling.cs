public class Cycling : Activity
{
    private double _speed; // miles per hour

    public Cycling(string date, double length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * Length) / 60;         // distance = speed * time (hours)
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;                    // min per mile
    }
}
