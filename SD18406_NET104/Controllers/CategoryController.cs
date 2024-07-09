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
        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        //Thêm mới 1 caegory -- điều hướng đến trang create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*
         * KHI K NÓI GÌ NÓ SẼ MẶC ĐỊNH LÀ GET
         * GET: Sư dụng để truy vấn thông tin mà k thay đổi nào ở db
         * INDEX, TÌM KIẾM,
         * POSTE: SỬ DỤNG ĐỂ GỬI DỮ LIỆU ĐẾN MÁY CHỦ NHẰM TẠO MỚI HOẶC THAY ĐỔI DỮ LIỆU
         * CREATE, DELETE, EDIT
         */
        [HttpGet]
        public IActionResult Edit(int? id)
        { 
            if(id==null || id==0)
            {
                return NotFound();
            }  
            //tìm ctegory cần sửa
            var categoryEdit = _db.Categories.Find(id);
            if(categoryEdit == null)
            {
                return NotFound();
            }
            return View(categoryEdit); 
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public IActionResult Delete(int? id) 
        //{ 
        //    var categoryDelete = _db.Categories.Find(id);
        //    return View(categoryDelete);
        //}
       
        
        [HttpGet, ActionName("Delete")]
        //trùng tên và phương thức vậy nên đổie tên và thêm actionName để nhận diện đc action
        public IActionResult DeletePost(int? id)
        {
            var categoryDelete = _db.Categories.Find(id);
            if (categoryDelete == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
