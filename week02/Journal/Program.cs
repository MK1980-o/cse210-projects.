// I added a "Mood" feature to the journal entries, allowing users to record 
// their emotional state alongside the date, prompt, and response. This addresses 
// a common journaling barrier: tracking emotional health over time. 
// The mood is saved and loaded with each entry.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = -1;

        while (choice != 5)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                     Console.Write("How would you describe your mood today? ");
                    string mood = Console.ReadLine();
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        Mood = mood,
                        Prompt = prompt,
                        Response = response
                    };
                    journal.AddEntry(entry);
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    break;

                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
 