using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        private const int MaxLength = 10;
        private const string Pattern = @"^\d{10}$"; // Expresión regular para validar un número de teléfono de 10 dígitos

        private PhoneNumber(string value) => Value = value;
        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)|| value.Length != MaxLength|| !Regex.IsMatch(value, Pattern))
            {return null; // Retorna null si el valor no cumple con las reglas de validación
            }
            return new PhoneNumber(value);
        }

        public string Value { get; }
        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();

    }
}
