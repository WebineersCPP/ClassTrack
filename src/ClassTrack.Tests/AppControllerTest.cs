
using ClassTrack.Controllers.Api;
using ClassTrack.Controllers.Web;
using ClassTrack.Models;
using ClassTrack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Xunit;

namespace ClassTrack.Tests
{
    public class AppControllerTest
    {
        [Fact]
        public void PassingTest()   // Sample test method
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()   // Sample test method
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        //Assignment 6: creating Tests (using xUnit for C#) - Ian Stodart
        [Fact]
        public void SubtractPassingTest()   // Sample test method
        {
            Assert.Equal(0, Subtract(2, 2));
        }

        [Fact]
        public void SubtractFailingTest()   // Sample test method
        {
            Assert.Equal(1, Subtract(2, 2));
        }

        int Subtract(int x, int y)
        {
            return x - y;
        }

        [Fact]
        public void Home_Controller_Redirects()
        {
            // Arrange: Create all dependencies required by method under test
            AppController controller = new AppController();

            // Act: Run method under test
            ViewResult result = controller.Home() as ViewResult;

            // Assert: Verify requirements of test were met
            // In future, if Home Controller has models to be initialized, test them here
            Assert.NotNull(result);
        }

    }
}