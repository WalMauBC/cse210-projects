using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void AddComment(string commenterName, string text)
    {
        Comments.Add(new Comment(commenterName, text));
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        Video video1 = new Video("Video 1", "Author 1", 120);
        Video video2 = new Video("Video 2", "Author 2", 180);

        // Adding comments
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "Nice content!");

        video2.AddComment("User3", "Awesome!");
        video2.AddComment("User4", "Interesting topic!");

        // Displaying video information
        DisplayVideoInfo(video1);
        DisplayVideoInfo(video2);
    }

    static void DisplayVideoInfo(Video video)
    {
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Length: {video.Length} seconds");
        Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in video.Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}
