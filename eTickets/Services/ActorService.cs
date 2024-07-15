using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Services
{
    public class ActorService : IActorService
    {
        IActorRepository actorRepository;
        public ActorService(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public List<Actor> GetAll()
        {
            return actorRepository.GetAll();
        }
        public Actor GetById(int id)
        {
            return actorRepository.GetById(id);
        }
        public void Insert(Actor newActor)
        {
            actorRepository.Insert(newActor);
        }
        public void Update(int id, Actor newActor)
        {
            actorRepository.Update(id, newActor);
        }
        public void Delete(int id)
        {
            actorRepository.Delete(id);
        }
    }
}
