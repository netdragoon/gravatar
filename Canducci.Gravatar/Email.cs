using Canducci.Gravatar.Validation;
namespace Canducci.Gravatar
{    
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
        public static IEmail Parse(string value)
        {
            return new Email(value);
        }
        public static bool TryParse(string value, out IEmail email)
        {
            if (Assertion.IsEmail(value))
            {
                email = new Email(value);
                return true;
            }
            email = null;
            return false;
        }
    }
}
