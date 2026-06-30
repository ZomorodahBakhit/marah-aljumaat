using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Core.Validations
{
    public class FormValidatorResults
    {
        public bool IsValid { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public FormValidatorResults(bool isValid, List<ValidationResult> results)
        {
            IsValid = isValid;
            if (!isValid && results != null)
            {
                Errors = new Dictionary<string, List<string>>();
                foreach (var item in results)
                {
                    var message = item.ErrorMessage;
                    foreach (var memeber in item.MemberNames)
                    {
                        if (!Errors.ContainsKey(memeber))
                            Errors.Add(memeber, new List<string>());
                        Errors[memeber].Add(message ?? string.Empty);
                    }
                }
            }
        }
    }
}
