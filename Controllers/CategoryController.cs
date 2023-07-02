using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOwn.Models;
using ProjectOwn.Repository.Base;

namespace ProjectOwn.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public CategoryController(IUnitOfWork _MyUnit) 
        {
            MyUnit = _MyUnit;
        }
        //private IRepository<Category> _repository;

        private readonly IUnitOfWork MyUnit;

        //public IActionResult Index()
        //{
        //    return View(_repository.GetAll());
        //}

        public async Task<IActionResult> Index()
        {
            var OneCategory = MyUnit.Categories.SelectOne(x => x.Name == "Computers");

            var AllCategory = await MyUnit.Categories.GetAllAsync("Items");
            return View(AllCategory);
        }


        public IActionResult New()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (category.ClientFile != null)
                {
                    MemoryStream stream= new MemoryStream();
                    category.ClientFile.CopyTo(stream);
                    category.dbImage = stream.ToArray();     
                }

                MyUnit.Categories.AddOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = MyUnit.Categories.GetById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                MyUnit.Categories.UpdateOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = MyUnit.Categories.GetById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            MyUnit.Categories.DeleteOne(category);
            TempData["SuccessData"] = "The Item has been Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
