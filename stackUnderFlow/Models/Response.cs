namespace StackUnderFlow.Models
{
    public class Response
    {
      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public int? Votes { get; set; }
      public int? QuestionId { get; set; }
      public bool? IsAnswer { get; set; }
      public Profile Creator { get; set; }
    
    public bool Validate()
    {
      bool isValid = true;
      if (string.IsNullOrWhiteSpace(CreatorId)) isValid = false;
      if (string.IsNullOrWhiteSpace(Title)) isValid = false;
      if (string.IsNullOrWhiteSpace(Description)) isValid = false;
      if (Votes == null) isValid = false;
      if (QuestionId == null) isValid = false;
      if (IsAnswer == null) isValid = false;
      if (Creator == null) isValid = false;
      return isValid;
    }
    }
}