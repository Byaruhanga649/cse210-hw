using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public int Laps => _laps;

    public override double GetDistance() => Laps * 50 / 1000.0 * 0.62; // miles
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}
