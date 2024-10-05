using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services
{
    public interface IPollServices
    {
        List<Poll> GetAll();
        Poll? GetById(int id);

        Poll Add(Poll newPoll);

        bool Update(int id,Poll newPoll);  
        bool Delete(int id);  
    }
}
