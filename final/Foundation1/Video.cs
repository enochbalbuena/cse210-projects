using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Length { get; private set; }
        private List<Comment> comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
