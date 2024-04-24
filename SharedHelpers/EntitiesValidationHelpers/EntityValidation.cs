using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.EntitiesValidationHelpers
{
    public static class EntityValidation
    { 
        public static void ModelValidation(object obj)
        {
            if(obj is null) throw new ArgumentNullException(nameof(obj));
            ValidationContext context= new ValidationContext(obj);
            List<ValidationResult> result= new List<ValidationResult>();
            bool isValid=Validator.TryValidateObject(obj, context, result);
            if (!isValid)
            {
                var errors = result.Select(x => x.ErrorMessage);
                string errorMessages = string.Join("\n", errors);
                throw new ArgumentException(errorMessages);
            }
        }
    }
}
