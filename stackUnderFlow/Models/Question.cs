namespace StackUnderFlow.Models
{
    public class Question
    {
      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string DateCreated { get; set; }
      public string DateClosed { get; set; }
      public string DateUpdated { get; set; }
      public int Responses { get; set; }
      public bool IsSolved { get; set; }
      public int CatagoryID { get; set; }
      public Profile Creator { get; set; }
      
    }
}