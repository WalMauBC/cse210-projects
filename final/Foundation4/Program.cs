using System;

class Program
{
    static void Main()
    {
        // Create activities
        Activity runningActivity = new RunningActivity("03 Nov 2022", 30, 3.0);
        Activity cyclingActivity = new CyclingActivity("03 Nov 2022", 45, 15);
        Activity swimmingActivity = new SwimmingActivity("03 Nov 2022", 60, 20);

        // Create list of activities
        Activity[] activities = { runningActivity, cyclingActivity, swimmingActivity };

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

class Activity
{
    private string date;
    private int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class does not calculate distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class does not calculate speed
    }

    public virtual double GetPace()
    {
        return 0; // Base class does not calculate pace
    }

    public virtual string GetSummary()
    {
        return $"{date} - {GetType().Name} ({minutes} min)";
    }
}

class RunningActivity : Activity
{
    private double distance;

    public RunningActivity(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

class CyclingActivity : Activity
{
    private double distance;

    public CyclingActivity(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

class SwimmingActivity : Activity
{
    private int laps;

    public SwimmingActivity(string date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / minutes) * 60;
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}
