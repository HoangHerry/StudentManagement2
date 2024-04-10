using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Controllers;
using Xunit;

namespace StudentManagement.Tests
{
    public class IndentityControllerTests
    {
        [Fact]
        public void Login_ReturnsViewResult()
        {
            // Arrange
            var controller = new IndentityController();

            // Act
            var result = controller.Login() as System.Web.Mvc.ViewResult;

            // Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Login_Post_InvalidUser_ReturnsViewWithError()
        {
            // Arrange
            var controller = new IndentityController();
            var user = "invalidUser";
            var password = "invalidPassword";

            // Act
            var result = controller.Login(user, password) as System.Web.Mvc.ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey(""));
        }
    }
}
