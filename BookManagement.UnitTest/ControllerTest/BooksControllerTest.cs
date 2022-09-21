using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.API.Models;
using BookManagement.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookManagement.UnitTest.ControllerTest
{
    public class BooksControllerTest
    {
        [Fact]
        public async Task Test_Create_POST_InvalidModelStateAsync()
        {
            // Arrange
            var r = new Book()
            {
                ISBN = "1",
                Title = "Sample Book1",
                AccountId = 1
            };
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Book>()));
            var controller = new BooksController(mockRepo.Object);

            // Act
            var result = await controller.CreateAsync(r);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            mockRepo.Verify();
        }
    }
}
