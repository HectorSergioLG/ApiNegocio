using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record Password
    {
        private const int MinLength = 8;
        private const string Pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        
        private Password(string value)=>Value=value;

        public static Password? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)||value.Length<MinLength || !Regex.IsMatch(value,Pattern)) { return null; }
            return new Password(value);
        }

        public string Value { get; }
        [GeneratedRegex(Pattern)]
        private static partial Regex PasswordRegex();

    }
}
