using System;
using System.Text.RegularExpressions;
namespace Canducci.Gravatar.Validation
{
    public static class Assertion
    {
        public static void EmailFormat(string email, string message)
        {

            if (string.IsNullOrEmpty(email))
            {
                throw new InvalidOperationException(message);
            }

            if (!IsEmail(email))
            {
                throw new InvalidOperationException(message);
            }

        }
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public static void Range(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Range(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Range(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void Range(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }
    }
}
