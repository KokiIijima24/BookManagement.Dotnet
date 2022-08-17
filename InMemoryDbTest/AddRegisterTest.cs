using BookManagement.Web;
using BookManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InMemoryDbTest
{
    public class AddRegisterTest
    {
        [Fact]
        public void Test_Create_POST_InvalidModelState()
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
            var controller = new RegisterController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = controller.Create(r);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
            mockRepo.Verify();
        }
    }
}
