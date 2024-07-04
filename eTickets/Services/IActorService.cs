using eTickets.Models;

namespace eTickets.Services
{
    // CRUD Operations ProtoType [Create - Read - Update - Delete]
    public interface IActorService
    {
        List<Actor> GetAll();
        Actor GetById(int id);
        void Insert(Actor newActor);
        void Update(int id, Actor newActor);
        void Delete(int id);
    }
}
