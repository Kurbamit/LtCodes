using LtCodes.Helpers;
using LtCodes.Enums;
using System.Text.RegularExpressions;

namespace LtCodes.Models
{
    public class PersonalCode
    {
        public string Code { get; set; }
        public int PersonControlNumber { get; set; }

        public PersonalCode(string code)
        {
            Code = code;
        }

        public bool Validate(string code, out ValidationErrorsEnum validationError)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                validationError = ValidationErrorsEnum.Empty;
                return false;
            }

            var regex = new Regex(@"^([1-6,9])([0-9]{2})([0-9]{2})([0-9]{2})[0-9]{3}([0-9])$", RegexOptions.IgnoreCase);
            var match = regex.Match(code);

            if (!match.Success)
            {
                validationError = ValidationErrorsEnum.Invalid;
                return false;
            }

            // Extract the matched groups
            string centurySex = match.Groups[1].Value;
            string yearShort = match.Groups[2].Value;
            string month = match.Groups[3].Value;
            string day = match.Groups[4].Value;
            string controlNumber = match.Groups[5].Value;

            // Determine the full year based on centurySex
            string year;
            int centurySexNumber = int.Parse(centurySex);

            if (centurySexNumber < 3)
            {
                year = $"18{yearShort}";
            }
            else if (centurySexNumber < 5)
            {
                year = $"19{yearShort}";
            }
            else if (centurySexNumber < 7)
            {
                year = $"20{yearShort}";
            }
            else
            {
                validationError = ValidationErrorsEnum.Invalid;
                return false;
            }

            // Check if the date is valid
            var fullDate = $"{year}-{month}-{day}";
            if (!DateTime.TryParse(fullDate, out DateTime validDate))
            {
                validationError = ValidationErrorsEnum.InvalidDate;
                return false;
            }


            int[] numbers = code.Select(c => int.Parse(c.ToString())).ToArray();
            PersonControlNumber = Helper.GetControlNumber(numbers);

            // Only proceed if the control number is more than 10
            if (PersonControlNumber >= 10)
            {
                PersonControlNumber = Helper.GetControlNumber(numbers, 3);
            }

            // After second check, if the control number is 10, it should be 0
            if (PersonControlNumber == 10)
            {
                PersonControlNumber = 0;
            }

            if (PersonControlNumber != int.Parse(controlNumber))
            {
                validationError = ValidationErrorsEnum.InvalidControlNumber;
                return false;
            }

            validationError = ValidationErrorsEnum.None;
            return true;
        }
    }
}