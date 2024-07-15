using eTickets.Models;

namespace eTickets.Services
{
    public interface IActorService
    {
        public List<Actor> GetAll();
        public Actor GetById(int id);
        public void Insert(Actor newActor);
        public void Update(int id, Actor newActor);
        public void Delete(int id);
    }
}
