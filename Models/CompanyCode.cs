using LtCodes.Helpers;
using LtCodes.Enums;
using System.Text.RegularExpressions;

namespace LtCodes.Models
{
    public class CompanyCode
    {
        public string Code { get; set; }
        public int CompanyControlNumber { get; set; }

        public CompanyCode(string code)
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

            if (!Regex.IsMatch(code, @"^[0-9]{9}$"))
            {
                validationError = ValidationErrorsEnum.Invalid;
                return false;
            }

            var regex = new Regex(@"^([0-9]{8})([0-9])$", RegexOptions.IgnoreCase);
            var match = regex.Match(code);

            if (!match.Success)
            {
                validationError = ValidationErrorsEnum.Invalid;
                return false;
            }

            // Extract the control number
            string controlNumber = match.Groups[2].Value;

            var numbersArray = code
                .Substring(0, code.Length - 1) // Remove last character (control number)
                .Select(c => int.Parse(c.ToString())) // Convert each character to an integer
                .ToArray();

            int generatedControlNumber = Helper.GetControlNumber(numbersArray);
            if (generatedControlNumber != int.Parse(controlNumber))
            {
                validationError = ValidationErrorsEnum.InvalidControlNumber;
                return false;
            }

            validationError = ValidationErrorsEnum.None;
            return true;
        }
    }
}