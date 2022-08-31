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
        public async Task<ActionResult> Edit(Register register)
        {
            await context.UpdateAsync(register);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            await context.DeleteAsync(id);
            return Ok();
        }
    }
}
