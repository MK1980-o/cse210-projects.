using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "What are things you're grateful for today?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you list the good things in your life.") { }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        Console.WriteLine("You will begin in:");
        ShowCountdown(5);

        int time = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(time);
        List<string> items = new List<string>();

        while (DateTime.Now < end)
        {
            Console.Write(">> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
