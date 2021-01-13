namespace StackUnderFlow.Models
{
    public class Response
    {
      public int Id { get; set; }
      public string CreatorId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public int Votes { get; set; }
      public int QuestionId { get; set; }
      public bool IsAnswer { get; set; }
      public Profile Creator { get; set; }
    }
}