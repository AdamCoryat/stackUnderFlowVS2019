using System;

namespace StackUnderFlow.Models
{
    public class Question
    {
      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTimeOffset? DateCreated { get; set; }
      public DateTimeOffset? DateClosed { get; set; }
      public DateTimeOffset? DateUpdated { get; set; }
      public int? Responses { get; set; }
      public bool? IsSolved { get; set; }
      public int? CatagoryID { get; set; }
      public Profile Creator { get; set; }
      
      public bool Validate()
    {
      bool isValid = true;
      if (string.IsNullOrWhiteSpace(CreatorId)) isValid = false;
      if (string.IsNullOrWhiteSpace(Title)) isValid = false;
      if (string.IsNullOrWhiteSpace(Description)) isValid = false;
      if (DateCreated == null) isValid = false;
      if (Responses == null) isValid = false;
      if (IsSolved == null) isValid = false;
      if (CatagoryID == null) isValid = false;
      if (Creator == null) isValid = false;
      return isValid;
    }
    }
}