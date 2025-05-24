
namespace SurveyBasket.Api.Mapping
{
    public static class ContractMapping
    {
        public static PollResponse MappToResponse(this Poll poll)
        {
            return new()
            {
                Id = poll.Id,
                Description = poll.Description,
                Title = poll.Title,
            };
        }
        public static IEnumerable<PollResponse> MappToResponse(this IEnumerable<Poll> polls)
        {
            return polls.Select(MappToResponse);
        }
        public static Poll MappToPoll(this CreatePollRequest request)
        {
            return new()
            {
                Description = request.Description,
                Title = request.Title,
            };
        }
    }


}
