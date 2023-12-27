namespace DataAccess.CustomAttributes
{


    [System.AttributeUsage(System.AttributeTargets.Property |
                       System.AttributeTargets.Struct)
]
    public class ClassModelAttribute : System.Attribute
    {
        public string name;

        public ClassModelAttribute(string name)
        {
            this.name = name;

        }

    }
}