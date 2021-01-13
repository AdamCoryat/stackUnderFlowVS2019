namespace StackUnderFlow.Models
{
    public class Catagory
    {
    public Catagory()
    {
    }
    public Catagory(int id)
    {
      Id = id;
    }

      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public int? Questions { get; set; }
      public Profile Creator { get; set; }

    public bool Validate()
    {
      bool isValid = true;
      if (string.IsNullOrWhiteSpace(CreatorId)) isValid = false;
      if (string.IsNullOrWhiteSpace(Title)) isValid = false;
      if (Questions == null) isValid = false;
      if (Creator == null) isValid = false;
      return isValid;
    }

    }
}