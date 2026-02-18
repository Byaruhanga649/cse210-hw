using System;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public double Distance => _distance;

    public override double GetDistance() => Distance;
    public override double GetSpeed() => (Distance / Minutes) * 60;
    public override double GetPace() => Minutes / Distance;
}
