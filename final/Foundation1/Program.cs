using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("C# Programming Tutorial", "John Doe", 600);
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Clear and concise."));

            Video video2 = new Video("Learn Python in 10 Minutes", "Jane Smith", 720);
            video2.AddComment(new Comment("Dave", "Excellent content!"));
            video2.AddComment(new Comment("Eva", "Loved the examples."));
            video2.AddComment(new Comment("Frank", "Very informative."));

            Video video3 = new Video("Java Basics", "Michael Johnson", 540);
            video3.AddComment(new Comment("Grace", "Superb tutorial!"));
            video3.AddComment(new Comment("Hannah", "Thanks for the great content."));
            video3.AddComment(new Comment("Ivy", "Really enjoyed this."));

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.Name}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}
