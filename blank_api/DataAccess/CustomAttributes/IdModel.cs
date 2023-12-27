//a custom attribute BugFix to be assigned to a class and its members
[AttributeUsage(
   AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]

public class IdModel : System.Attribute
{
  
  
    private string id;
    public string sequence;

    public IdModel(string id)
    {
       
       
        this.id = id;
    }
   
   
    public string Id
    {
        get
        {
            return id;
        }
    }
    public string Sequence
    {
        get
        {
            return sequence;
        }
        set
        {
            sequence = value;
        }
    }
}