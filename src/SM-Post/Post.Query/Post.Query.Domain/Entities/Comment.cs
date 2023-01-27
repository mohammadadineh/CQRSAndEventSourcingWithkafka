namespace Post.Query.Domain.Entities
{
    public class Comment
    {
        public Comment(Guid postId, string userName, DateTime commentDate, string text)
        {
            PostId = postId;
            UserName = userName;
            CommentDate = commentDate;
            Text = text;
            Edited = false;
        }
        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public string UserName { get; private set; }
        public DateTime CommentDate { get; set; }
        public string Text { get; private set; }
        public bool Edited { get; private set; }



        public void CommentTextChange(string text,DateTime editeDate)
        {
            Text= text;
            Edited = true;
            CommentDate = editeDate;
        }
    }
}