using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

private void BreathingAnimation(int seconds)
{
    string[] stages = { ".", "..", "...", "....", ".....", "....", "...", "..", "." };
    DateTime end = DateTime.Now.AddSeconds(seconds);
    int i = 0;

    while (DateTime.Now < end)
    {
        Console.Write($"Breathing {stages[i]}   \r");  
        System.Threading.Thread.Sleep(500);
        i = (i + 1) % stages.Length;
    }
    Console.WriteLine();
}

    public void Run()
{
    DisplayStartingMessage();

    int time = GetDuration();
    int interval = 5;  
    int elapsed = 0;

    while (elapsed < time)
    {
        Console.Write("Breathe in... ");
        BreathingAnimation(interval);

        Console.Write("Breathe out... ");
        BreathingAnimation(interval);

        elapsed += interval * 2;
    }

    DisplayEndingMessage();
    ShowProgressBar(time);  
}
}
