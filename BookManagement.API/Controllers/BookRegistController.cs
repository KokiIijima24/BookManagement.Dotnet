using BookManagement.API.Models;
using BookManagement.API.Repository;
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
            return Ok(await context.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> Details(int id)
        {
            return Ok(await context.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Register register)
        {
            try
            {
                var result = await context.CreateAsync(register);
                return Ok(result);
            }
            catch
            {
                return BadRequest(nameof(CreateAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Register register)
        {
            return Ok(await context.UpdateAsync(register));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await context.DeleteAsync(id));
        }
    }
}
