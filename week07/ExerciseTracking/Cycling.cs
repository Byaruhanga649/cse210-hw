using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public double Speed => _speed;

    public override double GetDistance() => (Speed * Minutes) / 60;
    public override double GetSpeed() => Speed;
    public override double GetPace() => 60 / Speed;
}
