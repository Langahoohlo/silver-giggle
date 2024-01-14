using baseapp.Models.Domains;

namespace baseapp.Models.ViewModels
{
    public class AddPostRequest
    {
        public string? Heading { get; set; }
        public string? PageTitle { get; set; }
        public string? ShortDescription { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string DisplayImage { get; set; } 
        public List<string> MoreImages { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool Visible { get; set; }
        public List<Guid>? TagIds { get; set; } // Assuming you want to associate tags by their Ids

        // Additional properties or validations can be added based on your requirements
    }

    public class TagsViewModel
    {
        public List<Tag>? Tags { get; set; }
    }
}