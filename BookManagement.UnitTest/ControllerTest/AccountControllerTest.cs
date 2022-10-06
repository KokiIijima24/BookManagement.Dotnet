using BookManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;
using BookManagement.API.Repository;

namespace BookManagement.UnitTest
{
    public class AccountTest
    {
        [Fact]
        public async Task Test_Create_POST_InvalidModelStateAsync()
        {
            // Arrange
            var r = new Account()
            {
                Id = 4,
                //Name = "Test Four",
                Age = 59
            };
            var mockRepo = new Mock<IAccountRepository>();
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Account>()));
            var controller = new AccountController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await controller.CreateAsync(r);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            mockRepo.Verify();
        }
    }
}
