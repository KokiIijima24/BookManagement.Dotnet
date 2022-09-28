using BookManagement.API.Models;
using BookManagement.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountRepository context;

        public AccountController(IAccountRepository appDbContext)
        {
            context = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> List()
        {
            return Ok(await context.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Details(int id)
        {
            return Ok(await context.GetByIdAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ObjectResult> CreateAsync([FromBody] Account Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await context.CreateAsync(Account);
                return Ok(result);
            }
            catch
            {
                return BadRequest(nameof(CreateAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(Account Account)
        {
            return Ok(await context.UpdateAsync(Account));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await context.DeleteAsync(id));
        }
    }
}
