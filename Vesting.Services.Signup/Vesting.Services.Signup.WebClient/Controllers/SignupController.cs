using Vesting.Services.Signup.Business.Interface;
using Vesting.Services.Signup.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Vesting.Services.Signup.WebClient.Controllers
{
    /// <summary>
    /// The SignupController class
    /// </summary>
    public class SignupController : ApiController
    {
        /// <summary>
        /// The ISignupRepository
        /// </summary>
        private ISignupRepository _signupRepository;

        /// <summary>
        /// Initizlizes a new instance of the SignupController class.
        /// </summary>
        /// <param name="signupRepository"></param>
        public SignupController(ISignupRepository signupRepository)
        {
            _signupRepository = signupRepository;
        }

        /// <summary>
        /// The post action of the SignupController.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(User user)
        {
            try
            {
                _signupRepository.Signup(new User { Fullname = user.Fullname, Email = user.Email, HasNewsletter = user.HasNewsletter });
                return Request.CreateResponse(HttpStatusCode.OK, user.Fullname);
            }
            catch (Exception ex)
            {
                var message = string.Format("User with fullname = {0} cannot signup, {1}", user.Fullname, ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
            }
        }

        /// <summary>
        /// The GET action of the SignupController.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                var users = _signupRepository.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                var message = string.Format("Cannot find any signuped users, {0}", ex);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
    }
}