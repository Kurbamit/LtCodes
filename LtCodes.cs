using LtCodes.Enums;
using LtCodes.Models;

namespace LtCodes
{
    public static class LtCodes
    {
        /// <summary>
        /// Validates a Lithuanian personal code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="validationError"></param>
        /// <returns></returns>
        public static bool ValidatePersonalCode(string code, out ValidationErrorsEnum validationError)
        {
            var personalCode = new PersonalCode(code);
            return personalCode.Validate(code, out validationError);
        }

        /// <summary>
        /// Validates a Lithuanian company code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="validationError"></param>
        /// <returns></returns>
        public static bool ValidateCompanyCode(string code, out ValidationErrorsEnum validationError)
        {
            var companyCode = new CompanyCode(code);
            return companyCode.Validate(code, out validationError);
        }
    }
}