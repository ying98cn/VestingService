using FluentValidation;
using Vesting.Services.Signup.Entity;
using System.Text.RegularExpressions;

namespace Vesting.Services.Signup.Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// The validator on User.
        /// Validation rules:
        /// For fullname: 
        ///     User fullname is required.
        ///     User fullname cannot contain any numbers.
        /// For Email:
        ///     Email is required.
        ///     Valid email format.
        /// </summary>
        public UserValidator()
        {
            // validation on user name
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("User fullname is required.");
            RuleFor(x => x.Fullname).Must(ContainsNoNumbers).WithMessage("User fullname cannot contain any numbers.");

            // validation on email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.Email).Must(HasCorrectEmailFormat).WithMessage("Invalid email format.");
        }

        /// <summary>
        /// Checks if the input string contains any numbers.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ContainsNoNumbers(string name)
        {
            Regex fullnamePattern = new Regex(@"^[a-zA-Z ]*$");
            return fullnamePattern.IsMatch(name);
        }

        /// <summary>
        /// User regular expression to check if the email format is correct.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool HasCorrectEmailFormat(string email)
        {
            Regex emailPattern = new Regex(@"^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$");
            return emailPattern.IsMatch(email);
        }
    }
}
