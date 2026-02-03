using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Very helpful video!"));
        video1.AddComment(new Comment("Bob", "Explained clearly."));
        video1.AddComment(new Comment("Charlie", "Thanks for this."));
        videos.Add(video1);

        Video video2 = new Video("OOP Basics", "Tech World", 450);
        video2.AddComment(new Comment("David", "Good introduction."));
        video2.AddComment(new Comment("Emma", "Easy to understand."));
        video2.AddComment(new Comment("Frank", "Nice examples."));
        videos.Add(video2);

        Video video3 = new Video("Abstraction in C#", "Programming Hub", 520);
        video3.AddComment(new Comment("Grace", "This helped a lot."));
        video3.AddComment(new Comment("Hannah", "Well explained."));
        video3.AddComment(new Comment("Ian", "Clear and simple."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
