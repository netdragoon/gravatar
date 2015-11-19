using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Canducci.Gravatar.Validation
{
    public static class Assertion
    {
        public static void EmailFormat(string Email, string Message)
        {

            if (string.IsNullOrEmpty(Email))
            {
                throw new InvalidOperationException(Message);
            }

            if (!Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                throw new InvalidOperationException(Message);
            }

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
