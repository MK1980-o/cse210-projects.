using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Exploring Zimbabwe", "Tariro Moyo", 300);
        video1.AddComment(new Comment("Blessing", "Amazing places!"));
        video1.AddComment(new Comment("Tawanda", "Love the culture."));
        video1.AddComment(new Comment("Nyasha", "Great video quality."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How to Cook Sadza", "Chef Tino", 420);
        video2.AddComment(new Comment("John", "Delicious!"));
        video2.AddComment(new Comment("Mercy", "My favorite meal."));
        video2.AddComment(new Comment("Chenai", "Well explained."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Victoria Falls Tour", "Travel Africa", 560);
        video3.AddComment(new Comment("Peter", "Breathtaking!"));
        video3.AddComment(new Comment("Sarah", "On my bucket list."));
        video3.AddComment(new Comment("Musa", "Thanks for sharing!"));
        videos.Add(video3);

        // Display video info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
