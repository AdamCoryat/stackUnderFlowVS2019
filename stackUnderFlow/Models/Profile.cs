namespace StackUnderFlow.Models
{
  public class Profile
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }

    public bool Validate()
    {
      bool isValid = true;
      if (string.IsNullOrWhiteSpace(Name)) isValid = false;
      if (string.IsNullOrWhiteSpace(Email)) isValid = false;
    }
  }
}