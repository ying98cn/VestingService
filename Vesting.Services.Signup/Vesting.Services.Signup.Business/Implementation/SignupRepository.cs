using FluentValidation;
using Vesting.Services.Signup.Business.Helper;
using Vesting.Services.Signup.Business.Interface;
using Vesting.Services.Signup.Business.Validation;
using Vesting.Services.Signup.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace Vesting.Services.Signup.Business.Implementation
{
    /// <summary>
    /// The Signup Repository.
    /// </summary>
    public class SignupRepository : ISignupRepository
    {
        /// <summary>
        /// Sign up a user.
        /// </summary>
        /// <param name="user"></param>
        public void Signup(User user)
        {
            var userValidator = new UserValidator();
            userValidator.ValidateAndThrow(user);

            var path = FileHelper.GetRepositoryFilePath();
            try
            {
                using (StreamWriter fileWriter = new StreamWriter(path, true))
                {
                    fileWriter.WriteLine(string.Format("{0},{1},{2}", user.Fullname, user.Email, user.HasNewsletter));
                    fileWriter.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("It went wrong when writing daba to the text file {0}, {1}", path, ex));
            }

        }

        /// <summary>
        /// Gets all signed up users in the repository.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            var path = FileHelper.GetRepositoryFilePath();
            try
            {
                using (StreamReader fileReader = new StreamReader(path))
                {
                    while (fileReader.Peek() >= 0)
                    {
                        string str;
                        string[] strArray;
                        str = fileReader.ReadLine();

                        strArray = str.Split(',');
                        User currentUser = new User();
                        currentUser.Fullname = strArray[0];
                        currentUser.Email = strArray[1];
                        currentUser.HasNewsletter = bool.Parse(strArray[2]);

                        users.Add(currentUser);
                    }

                    fileReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("It went wrong when reading daba from the text file {0}, {1}", path, ex));
            }

            return users;
        }
    }
}
