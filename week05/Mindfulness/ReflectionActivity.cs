using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What did you learn from this experience?",
        "How can you apply this lesson in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times when you showed strength and resilience.") { }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        ShowSpinner(3);

        int time = GetDuration();
        int elapsed = 0;

        while (elapsed < time)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
            elapsed += 5;
        }

        DisplayEndingMessage();
    }
}
