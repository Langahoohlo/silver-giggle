using baseapp.Data;
using baseapp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using baseapp.Models.Domains;

namespace baseapp.Controllers
{
    public class AdminTagsController : Controller
    {
        private BloggieDbContext _bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;    
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest) 
        {
            // Mapping add tag request to the tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            _bloggieDbContext.Tags.Add(tag);
            _bloggieDbContext.SaveChanges();

            // var name = addTagRequest.Name;
            // var displayName = addTagRequest.DisplayName;

            return View("Add");
        }
    }
}
