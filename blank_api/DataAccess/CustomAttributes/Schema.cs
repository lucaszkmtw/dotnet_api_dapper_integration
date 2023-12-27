namespace DataAccess.CustomAttributes
{


    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class SchemaAttribute : System.Attribute
    {
        public string name;

        public SchemaAttribute(string name)
        {
            this.name = name;

        }

    }
}