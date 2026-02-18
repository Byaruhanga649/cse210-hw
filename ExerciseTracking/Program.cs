using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private double _duration; // in minutes

    public Activity(DateTime date, double duration)
    {
        _date = date;
        _duration = duration;
    }

    public DateTime Date { get { return _date; } }
    public double Duration { get { return _duration; } }

    public abstract double GetDistanceMiles();
    public abstract double GetDistanceKm();

    public double GetSpeedMph() => (GetDistanceMiles() / Duration) * 60;
    public double GetSpeedKph() => (GetDistanceKm() / Duration) * 60;

    public double GetPaceMinPerMile() => Duration / GetDistanceMiles();
    public double GetPaceMinPerKm() => Duration / GetDistanceKm();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_duration} min) - " +
               $"Distance {GetDistanceMiles():0.0} miles, Speed {GetSpeedMph():0.0} mph, Pace: {GetPaceMinPerMile():0.00} min per mile\n" +
               $"{_date:dd MMM yyyy} {this.GetType().Name} ({_duration} min) - " +
               $"Distance {GetDistanceKm():0.0} km, Speed {GetSpeedKph():0.0} kph, Pace: {GetPaceMinPerKm():0.00} min per km";
    }
}

class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, double duration, double distanceMiles)
        : base(date, duration)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistanceMiles() => _distanceMiles;
    public override double GetDistanceKm() => _distanceMiles / 0.62; // miles → km
}

class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, double duration, double speedMph)
        : base(date, duration)
    {
        _speedMph = speedMph;
    }

    public override double GetDistanceMiles() => (_speedMph * Duration) / 60;
    public override double GetDistanceKm() => GetDistanceMiles() / 0.62;
}

class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, double duration, int laps)
        : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistanceMiles() => _laps * LapLengthMeters / 1000 * 0.62;
    public override double GetDistanceKm() => _laps * LapLengthMeters / 1000;
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 12),
            new Swimming(new DateTime(2022, 11, 3), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine(); // extra line for readability
        }
    }
}
