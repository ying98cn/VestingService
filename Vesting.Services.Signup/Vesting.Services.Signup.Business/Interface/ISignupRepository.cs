using System.Collections.Generic;
using Vesting.Services.Signup.Entity;

namespace Vesting.Services.Signup.Business.Interface
{
    /// <summary>
    /// The Signup Repository.
    /// </summary>
    public interface ISignupRepository
    {
        /// <summary>
        /// Sign up a user.
        /// </summary>
        /// <param name="user"></param>
        void Signup(User user);

        /// <summary>
        /// Gets all signed up users in the repository.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();
    }
}
