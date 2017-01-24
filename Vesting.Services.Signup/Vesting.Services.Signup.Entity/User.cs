namespace Vesting.Services.Signup.Entity
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Indicates if the user wants a newsletter.
        /// </summary>
        public bool HasNewsletter { get; set; }
    }
}
