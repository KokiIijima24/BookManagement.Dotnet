using BookManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookRegistController : ControllerBase
    {
        private IRegisterRepository context;

        public BookRegistController(IRegisterRepository appDbContext)
        {
            context = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> List()
        {
            return await context.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> Details(int id)
        {
            return await context.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Register register)
        {
            try
            {
                await context.CreateAsync(register);
                return Ok();
            }
            catch
            {
                return BadRequest(nameof(CreateAsync));
            }
        }

        [HttpPut]
        public Task<ActionResult> Edit(Register register)
        {
            return View();
        }

        // // POST: BookRegist/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // // GET: BookRegist/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        // // POST: BookRegist/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
