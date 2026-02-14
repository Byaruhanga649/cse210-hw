using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
        "This activity will help you relax by guiding you through slow breathing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
        }

        DisplayEndingMessage();
    }
}
