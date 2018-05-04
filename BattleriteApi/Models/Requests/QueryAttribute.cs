using System;

namespace Rocket.Battlerite
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class QueryAttribute : Attribute
    {
        public QueryAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}