using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services
{
    public class PollServices : IPollServices
    {
        private static readonly List<Poll> _polls =
           [
               new Poll {
                    Id = 1,
                    Name = "ahmed",
                    Descriptoin = "this is my poll"
                }
           ];

       

        public List<Poll> GetAll() => _polls;
       

        public Poll? GetById(int id) => _polls.SingleOrDefault(poll=>poll.Id==id);

        public Poll Add(Poll poll)
        {

            poll.Id = _polls.Count+1;
            _polls.Add(poll);   

           return poll;  
        }

        public bool Update(int id, Poll newPoll)
        {
            var currentpoll = GetById(id);  
            if (currentpoll is null)
                return false;
            currentpoll.Name= newPoll.Name;
            currentpoll.Descriptoin= newPoll.Descriptoin;
            return true;    
        }

        public bool Delete(int id)
        {
            var poll = GetById(id);
            if (poll is null)
                return false;
            _polls.Remove(poll);    
            return true;
        }
    }
}
