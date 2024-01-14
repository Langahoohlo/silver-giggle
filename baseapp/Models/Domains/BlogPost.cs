namespace baseapp.Models.Domains
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string? Heading { get; set; }
        public string? PageTitle { get; set; }
        public string? ShortDescription { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string? DisplayImage { get; set; }
        public List<string>? MoreImages { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool Visible { get; set; }
        public ICollection<Tag>? Tags { get; set; }

    }
}

