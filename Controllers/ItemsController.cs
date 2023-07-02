using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectOwn.Date;
using ProjectOwn.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectOwn.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        public ItemsController(AppDbContext db , Microsoft.AspNetCore.Hosting.IHostingEnvironment host)
        {
                _db = db;
            _host = host;
        }

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _host;

        private readonly AppDbContext _db;
        public IActionResult Index()
        {
           IEnumerable<Items> ItemsList = _db.Items.Include(c=>c.Category).ToList();
            return View(ItemsList);
        }

        public IActionResult New()
        {
            createSelectList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Items items)
        {
            if (items.Price >= 1000){
                ModelState.AddModelError("price", "Please Input The Little Number");
            }
            if (items.Name=="100")
            {
                ModelState.AddModelError("Name", "Name can`t be 100");
            }
        
            if(ModelState.IsValid) 
            {
                string fileName = string.Empty;
                if (items.ClientFile != null)
                {
                    string myUpLoad = Path.Combine(_host.WebRootPath,"images");
                    fileName = items.ClientFile.FileName;
                    string fullPath=Path.Combine(myUpLoad,fileName);
                    items.ClientFile.CopyTo(new FileStream(fullPath,FileMode.Create));
                    items.ImagesPath = fileName;

                }

            _db.Items.Add(items);
            _db.SaveChanges();
            TempData["SuccessData"] = "The Item has been Added Successfully";
                return RedirectToAction("Index",items);
            }
            else
            {
                return View(items);
            }

        }

        public void createSelectList(int SelectId =1 )
        {
            List<Category> categories = new List<Category>
            {new Category {Id=1 ,Name="Select Category"}, 
             new Category {Id=2 ,Name="Computers"},
             new Category {Id=3 ,Name="Mobiles"},
             new Category {Id=4 ,Name="Electric Machines"}
            };
            SelectList listItems = new SelectList(categories, "Id", "Name", SelectId);
            ViewBag.Category = listItems;
        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id==0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Items items)
        {
            if (items.Price >= 1000)
            {
                ModelState.AddModelError("price", "Please Input The Little Number");
            }
            if (items.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can`t be 100");
            }

            if (ModelState.IsValid)
            {
                _db.Items.Update(items);
                _db.SaveChanges();
                TempData["SuccessData"] = "The Item has been Updated Successfully";
                return RedirectToAction("Index", items);
            }
            else
            {
                return View(items);
            }

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);

            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Items items)
        {
                _db.Items.Remove(items);
                _db.SaveChanges();
                TempData["SuccessData"] = "The Item has been Deleted Successfully";
            return RedirectToAction("Index", items);
        }

    }
}
