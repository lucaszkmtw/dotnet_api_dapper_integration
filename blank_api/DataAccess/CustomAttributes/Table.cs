namespace DataAccess.CustomAttributes
{


    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class TableAttribute : System.Attribute
    {
        public string name;

        public TableAttribute(string name)
        {
            this.name = name;

        }
      
    }
}