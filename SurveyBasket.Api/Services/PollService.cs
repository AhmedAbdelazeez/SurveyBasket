namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private readonly List<Poll> _polls =
          [new Poll()
            {
               Id = 1, Description = "addfd", Title="dsaf"
            }
          ];

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
            _polls.Add(poll);
            return poll;
        }

        public bool Delete(int id)
        {
            var poll = GetById(id);
            if (poll is null)
            {
                return false;
            }
            _polls.Remove(poll);

            return true;
        }

        public IEnumerable<Poll> GetAll() { return _polls; }


        public Poll? GetById(int id)
        {
            return _polls.SingleOrDefault(pol => pol.Id == id);
        }

        public bool Update(int id, Poll poll)
        {
            var currentPoll = GetById(id);
            if (currentPoll is null)
            {
                return false;
            }

            currentPoll.Title = poll.Title;
            currentPoll.Description = poll.Description;

            return true;
        }
    }
}
