using BookManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web
{
    public class BookRegistController : Controller
    {

        // GET: BookRegist
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookRegist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookRegist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookRegist/Create
        [HttpPost]
        public ActionResult Create(Register register)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookRegist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookRegist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookRegist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookRegist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
