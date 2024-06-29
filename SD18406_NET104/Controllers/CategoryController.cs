using Microsoft.AspNetCore.Mvc;
using SD18406_NET104.Models;
using System.Net.WebSockets;

namespace SD18406_NET104.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDbContext _db;

        public CategoryController(CategoryDbContext db)
        {
            _db = db;
        }

        //lấy list category
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        //Thêm mới 1 caegory
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index","Category");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
