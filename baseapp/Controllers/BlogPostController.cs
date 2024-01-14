using Azure;
using baseapp.Data;
using baseapp.Models.Domains;
using baseapp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace baseapp.Controllers
{
    public class BlogPostController : Controller
    {
        private BloggieDbContext _bloggieDbContext;

        public BlogPostController(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }

        public IActionResult GetTags()
        {
            // Assuming you have a service that fetches tags from the database
            var tags = _bloggieDbContext.Tags.ToList();

            // Create a TagsViewModel and populate the Tags property
            var viewModel = new TagsViewModel
            {
                Tags = tags
            };

            // Pass the viewModel to the view
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddPosts()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddPosts")] // Assuming this is the correct view name
        public IActionResult AddPosts(AddPostRequest model, List<AddTagRequest> tagRequests, List<IFormFile> displayImageFiles, List<IFormFile> moreImageFiles)
        {
            // Mapping add tag request to the tag domain model
            var post = new BlogPost
            {
                Id = Guid.NewGuid(),
                Heading = model.Heading,
                PageTitle = model.PageTitle,
                ShortDescription = model.ShortDescription,
                Author = model.Author,
                Content = model.Content,
                DisplayImage = model.DisplayImage,
                MoreImages = model.MoreImages,
                PublishedDate = DateTime.Now,
                Visible = model.Visible,

                Tags = tagRequests.Select(tagRequest => new Tag
                {
                    Id = Guid.NewGuid(), // Assuming Id is generated
                    Name = tagRequest.Name,
                    DisplayName = tagRequest.DisplayName
                }).ToList()
            };

            _bloggieDbContext.BlogPosts.Add(post);
            _bloggieDbContext.SaveChanges();

            // return RedirectToAction("AddPosts", new AddPostRequest());

            return View("AddPosts");
        }

        //[HttpGet]
        public IActionResult ViewPosts()
        {
            // Retrieve all blog posts from the database
            var blogPosts = _bloggieDbContext.BlogPosts.ToList();

            return View(blogPosts);
        }

        // Action to display the "DeletePost" view
        [HttpGet]
        public IActionResult DeletePost(Guid id)
        {
            // Retrieve the blog post data based on the post ID
            var post = _bloggieDbContext.BlogPosts.Find(id);

            if (post == null)
            {
                // Handle the case where the post with the given ID is not found
                return NotFound();
            }

            // Pass the id to the view
            ViewBag.PostId = id;

            return View(post);
        }

        // Action to handle the deletion of the blog post
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDeletePost(Guid id)
        {
            // Retrieve the blog post data based on the post ID
            var post = _bloggieDbContext.BlogPosts.Find(id);

            if (post == null)
            {
                // Handle the case where the post with the given ID is not found
                return NotFound();
            }

            // Perform the deletion
            _bloggieDbContext.BlogPosts.Remove(post);
            _bloggieDbContext.SaveChanges();

            return RedirectToAction("Index"); // Redirect to the list of blog posts or another appropriate action
        }
    }
}
