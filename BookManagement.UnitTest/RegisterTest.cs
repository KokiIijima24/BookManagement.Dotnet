using BookManagement;
using BookManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Collections.Generic;

namespace BookManagement.UnitTest
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
            var result = await controller.CreateAsync(r);

            // Assert
            var viewResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<Register>(viewResult.Value);
            Assert.Equal(4, model.Id);
            mockRepo.Verify();
        }
    }
}
