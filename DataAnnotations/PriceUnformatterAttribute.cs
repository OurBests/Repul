using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.DataAnnotations
{
    public class PriceUnformatterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ctx)
        {
            // get the property
            var prop = ctx.ObjectType.GetProperty(ctx.MemberName);

            // get the current value (assuming it's a string property)
            var oldVal = prop.GetValue(ctx.ObjectInstance) as string;

            // create a new value, perhaps by manipulating the current one
            var newVal = oldVal.Replace(",","");

            // set the new value
            prop.SetValue(ctx.ObjectInstance, newVal);

            var intval = 0;
            if (!int.TryParse(newVal, out intval))
                return new ValidationResult("Must number");
            return ValidationResult.Success;
        }
    }
}
