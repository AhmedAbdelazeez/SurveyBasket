

namespace SurveyBasket.Api.Contracts.Validation
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(s => s.Title)
             .NotEmpty()
             .Length(3, 1000);
        }
    }
}
