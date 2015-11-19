
using Canducci.Gravatar.Validation;
namespace Canducci.Gravatar
{
    /// <summary>
    /// Class E-mail
    /// </summary>
    public sealed class Email : IEmail
    {
        public Email(string email)
        {
            Assertion.EmailFormat(email, "E-mail format invalid");
            Value = email;
            Hash = email.ToHash();
        }
        public string Hash { get; private set; }
        public string Value { get; private set; }
    }
}
