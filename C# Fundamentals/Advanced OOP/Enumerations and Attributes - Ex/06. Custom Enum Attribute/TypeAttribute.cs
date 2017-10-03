using System;

namespace Enums_and_Attributes_EX___01
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    internal class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}