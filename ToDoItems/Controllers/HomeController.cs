using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoItems.Models;

namespace ToDoItems.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);

            IEnumerable<ToDoItem> items = mgr.GetIncompletedItems();
            return View(items);
        }

        public ActionResult Completed()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);

            IEnumerable<ToDoItem> items = mgr.GetCompleted();
            return View(items);
        }

        public ActionResult Categories()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            return View(mgr.GetCategories());
        }

        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewCategory(string name)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            mgr.AddCategory(name);
            return Redirect("/home/categories");
        }

        public ActionResult EditCategory(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            Category category = mgr.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            mgr.UpdateCategory(category);
            return Redirect("/home/categories");
        }

        public ActionResult NewItem()
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            return View(mgr.GetCategories());
        }

        [HttpPost]
        public ActionResult SaveNewItem(ToDoItem item)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            mgr.AddToDoItem(item);
            return Redirect("/home/index");
        }

        [HttpPost]
        public ActionResult MarkAsCompleted(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);
            mgr.MarkAsCompleted(id);
            return Redirect("/home/index");
        }

        public ActionResult ByCategory(int id)
        {
            ToDoItemsManager mgr = new ToDoItemsManager(Properties.Settings.Default.ConStr);

            IEnumerable<ToDoItem> items = mgr.GetByCategory(id);
            return View(items);
        }
    }
}