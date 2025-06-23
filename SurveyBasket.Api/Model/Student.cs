using SurveyBasket.Api.Validation;

namespace SurveyBasket.Api.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [MinAge(15, ErrorMessage = "invalied date of birth ")]
        public DateTime? dateofbirth { get; set; }
    }
}
