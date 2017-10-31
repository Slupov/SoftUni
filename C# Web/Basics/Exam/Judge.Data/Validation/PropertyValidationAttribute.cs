using System;

namespace Judge.Data.Validation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
