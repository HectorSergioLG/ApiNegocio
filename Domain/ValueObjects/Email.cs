using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record Email
    {
        private const int MaxLength = 150;
        private const string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        private Email(string value) => Value = value;

       public static Email? Create(string value)
        {
            var addr = new MailAddress(value);
            if (!(addr.Address == value))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(value)|| value.Length> MaxLength || !Regex.IsMatch(value, Pattern))
            {
                return null;
            }

            return new Email(value);
        }

        public string Value { get;}
        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
