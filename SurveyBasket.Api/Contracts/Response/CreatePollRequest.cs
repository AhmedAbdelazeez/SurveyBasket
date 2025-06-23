using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Api.Contracts.Response
{
    public record CreatePollRequest(
        [Required(ErrorMessage = "Required field ")]
      //  [AllowedValues("New", "old",ErrorMessage = "only allow new or old ")]

          string Title
        , string Description);

}
