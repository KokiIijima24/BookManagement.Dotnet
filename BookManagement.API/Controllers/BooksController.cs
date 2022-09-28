using BookManagement.API.Models;
using BookManagement.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookRepository context;

        public BooksController(IBookRepository appDbContext)
        {
            context = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> List()
        {
            return Ok(context.ListAsync(""));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Details(string isbn)
        {
            return Ok(await context.GetByIdAsync(isbn));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Book Book)
        {
            try
            {
                var result = await context.CreateAsync(Book);
                return Ok(result);
            }
            catch
            {
                return BadRequest(nameof(CreateAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Book book)
        {
            return Ok(await context.UpdateAsync(book));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(string isbn)
        {
            return Ok(await context.DeleteAsync(isbn));
        }
    }
}
