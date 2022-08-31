using BookManagement;
using BookManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace InMemoryDbTest
{
    public class RegisterTest
    {
        [Fact]
        public async Task Test_Create_POST_InvalidModelStateAsync()
        {
            // Arrange
            var r = new Register()
            {
                Id = 4,
                Name = "Test Four",
                Age = 59
            };
            var mockRepo = new Mock<IRegisterRepository>();
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Register>()));
            var controller = new BookRegistController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result =await controller.CreateAsync(r);

            // Assert
            var viewResult = Assert.IsType<ActionResult>(result);
            Assert.Equal(StatusCodeResult.);
            mockRepo.Verify();
        }
    }
}
