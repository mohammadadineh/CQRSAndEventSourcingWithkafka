﻿namespace Post.Query.Domain.Entities
{
    public class Comment
    {
        public Comment(string userName, DateTime commentDate, string text)
        {
            UserName = userName;
            CommentDate = commentDate;
            Text = text;
        }
        public Guid Id { get;private set; }
        public string UserName { get;private set; }
        public DateTime CommentDate { get; set; }
        public string Text { get; set; }
        public bool Edited { get;private set; }
    //    public Guid PostId { get; set; }
    }
}