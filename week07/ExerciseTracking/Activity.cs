using System;

public abstract class Activity
{
    private string _date;
    private double _length;  // length in minutes

    public Activity(string date, double length)
    {
        _date = date;
        _length = length;
    }

    public string Date => _date;
    public double Length => _length;

    public abstract double GetDistance();  // miles
    public abstract double GetSpeed();     // mph
    public abstract double GetPace();      // min per mile

    public virtual string GetEmoji()
    {
        return this.GetType().Name switch
        {
            "Running" => "🏃‍♂️",
            "Cycling" => "🚴‍♀️",
            "Swimming" => "🏊‍♂️",
            _ => ""
        };
    }

    public virtual string GetSummary()
    {
        return $"{Date} {GetEmoji()} {this.GetType().Name} ({Length} min): Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
