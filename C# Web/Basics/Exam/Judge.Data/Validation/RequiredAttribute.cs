using System;
using System.Collections.Generic;
using System.Text;

namespace Judge.Data.Validation
{
    public class RequiredAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
            => new System
                    .ComponentModel
                    .DataAnnotations
                    .RequiredAttribute()
                .IsValid(value);
    }
}
