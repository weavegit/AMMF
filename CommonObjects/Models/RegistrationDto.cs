
namespace Common.Entities
{
    public class RegistrationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? Company { get; set; }

        public string? Title { get; set; }

        public string? AnyQuestions { get; set; }

        public Guid SelectedTopicId { get; set; }

        public RegistrationDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
        public RegistrationDto(string firstName, string lastName, string email, string? company, string? title, string? anyQuestions, Guid selectedTopicId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Title = title;
            AnyQuestions = anyQuestions;
            SelectedTopicId = selectedTopicId;
        }
    }
}
