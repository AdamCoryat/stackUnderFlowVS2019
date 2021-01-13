namespace Stack.Models
{
    public class Catagory
    {
      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public int Questions { get; set; }
      public Profile Creator { get; set; }
    }
}