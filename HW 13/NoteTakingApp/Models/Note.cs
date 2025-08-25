namespace NoteTakingApp.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; private set; }
        public List<string> Tags { get; set; }

        public Note(string title, string text, List<string> tags)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            }

            Title = title;
            Text = text;
            Tags = tags ?? new List<string>();
            CreationDate = DateTime.Now;
        }
    }
}
