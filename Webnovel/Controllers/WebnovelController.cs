using Microsoft.AspNetCore.Mvc;
using Webnovel.Database;
using Webnovel.Models;

namespace Webnovel.Controllers
{
    public class WebnovelController : Controller
    {
        private readonly ApplicationDbContext db;

        public WebnovelController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Models.Webnovel> objWebnovelList = db.Webnovels;
            return View(objWebnovelList);
        }
        //GET method to view the Create page
        public IActionResult Create()
        {
            return View();
        }

        //POST method to add the Webnovel object to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Webnovel obj)
        {
            if (obj.Name != null)
            {
                if (obj.Name.Contains("bakugo"))
                    ModelState.AddModelError("name", "Hat te meg mit csinalsz?????");
            }
            if (ModelState.IsValid)
            {

                db.Webnovels.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Webnovel created successfully";
                return RedirectToAction("/Webnovel/Index");
            }
            return View(obj);
        }

        //GET method to redirect to the Edit page
        public IActionResult Edit(int? id)
        {
            //if(id != null || id  > 0){
            //    var obj = db.Webnovels.Find(id);
            //    if(obj != null){
            //        Console.WriteLine(obj.Name);
            //        return View(obj);
            //    }
            //}
            if(id == null || id == 0){
                return RedirectToAction("Index");
            }
            var obj = db.Webnovels.Find(id);
            if(obj == null){
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //POST method to save the Edited values
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Webnovel obj){
            
            if (ModelState.IsValid)
            {

                db.Webnovels.Update(obj);
                db.SaveChanges();
                TempData["success"] = "Webnovel updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //POST method to delete a row
        public IActionResult Delete(int? id){
            if(id != null){
                var obj = db.Webnovels.Find(id);
                if(obj != null)
                {
                    db.Webnovels.Remove(obj);
                    db.SaveChanges();
                    TempData["success"] = "Webnovel deleted successfully";
                }
            }
            
            return RedirectToAction("Index");
        }


    }
}
