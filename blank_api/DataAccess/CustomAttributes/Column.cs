namespace DataAccess.CustomAttributes
{


    [System.AttributeUsage(System.AttributeTargets.Property |
                       System.AttributeTargets.Struct)
]
    public class ColumnAttribute : System.Attribute
    {
        public string name;

        public ColumnAttribute(string name)
        {
            this.name = name;

        }

    }
}