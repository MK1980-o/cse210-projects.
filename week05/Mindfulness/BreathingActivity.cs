using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();
        int time = GetDuration();
        int interval = 4; // breathe in/out duration
        int elapsed = 0;

        while (elapsed < time)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(interval);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountdown(interval);
            Console.WriteLine();

            elapsed += interval * 2;
        }

        DisplayEndingMessage();
    }
}
