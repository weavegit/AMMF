
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class RegistrationViewModel
    {
        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Please make a selection.")]
        public int TopicId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Any Questions?")]
        public string? AnyQuestions { get; set; }
        public RegistrationViewModel() { }
        public RegistrationViewModel(string firstName, string lastName, string email, string? company, string? title, string? anyQuestions)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Title = title;
            AnyQuestions = anyQuestions;
        }

        public RegistrationDto GetDto()
        {
            return new RegistrationDto(this.FirstName, this.LastName, this.Email, this.Company, this.Title, this.AnyQuestions, new Guid());
        }
    }
}
