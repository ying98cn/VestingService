using Moq;
using NUnit.Framework;
using Vesting.Services.Signup.Business.Interface;
using Vesting.Services.Signup.Entity;
using Vesting.Services.Signup.WebClient.Controllers;
using System.Collections.Generic;
using System.Net.Http;

namespace Vesting.Services.Signup.UnitTests
{
    [TestFixture]
    public class SignupControllerTests
    {
        private Mock<ISignupRepository> _signupRepositoryMock;

        [SetUp]
        public void Initialize()
        {
            _signupRepositoryMock = new Mock<ISignupRepository>();
        }

        [TearDown]
        public void Terminate()
        {
            _signupRepositoryMock = null;
        }


        [Test]
        public void Post_ShouldCallSignupMethod()
        {
            // Assign
            var user = new User() { Fullname = "testUser", Email = "test@hotmail.com", HasNewsletter = true };
            var signupController = new SignupController(_signupRepositoryMock.Object);

            // Act
            var result = signupController.Post(user);

            // Assert
            Assert.IsTrue(result != null);
            _signupRepositoryMock.Verify(c => c.Signup(user), Times.Once());
        }

        [Test]
        public void Get_ShouldGetAllUsers()
        {
            // Assign
            _signupRepositoryMock.Setup(x => x.GetAllUsers()).Returns(GetMockUsers);
            var signupController = new SignupController(_signupRepositoryMock.Object);

            // Act
            var response = signupController.Get();

            // Assert
            Assert.IsInstanceOf(typeof(HttpResponseMessage), response);
            _signupRepositoryMock.Verify(c => c.GetAllUsers(), Times.Once());
        }

        private List<User> GetMockUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Fullname = "FirstUser", Email = "FirstUser@Performation.nl", HasNewsletter = true });
            users.Add(new User() { Fullname = "SecondUser", Email = "SecondUser@Performation.nl", HasNewsletter = false });
            users.Add(new User() { Fullname = "ThirdUser", Email = "ThirdUser@Performation.nl", HasNewsletter = true });

            return users;
        }
    }
}
