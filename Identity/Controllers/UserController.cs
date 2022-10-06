using System.Collections.Generic;
using System.Linq;
using Identity.DTOs;
using Identity.Models;
using Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly
        ApplicationDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger
          , ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("list")]
        public IEnumerable<UserDto> GetUsers()
        {
            return _dbContext.Users.Select(_ =>
            new UserDto()
            {
                Id = _.Id,
                Iamge = null
            });
        }
    }
}