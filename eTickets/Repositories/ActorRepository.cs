using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Services
{
    // CRUD Operations [Create - Read - Update - Delete]
    public class ActorRepository : IActorRepository
    {
        AppDbContext Context;// = new AppDbContext();
        public ActorRepository(AppDbContext Context)
        {
            this.Context = Context;
        }
        public List<Actor> GetAll()
        {
            List<Actor> actors = Context.Actors.ToList();
            return actors;
        }
        public Actor GetById(int id)
        {
            Actor actor = Context.Actors.FirstOrDefault(x => x.Id == id);
            return actor;
        }
        public void Insert(Actor newActor)
        {
            Context.Actors.Add(newActor);
            Context.SaveChanges();
        }
        public void Update(int id, Actor newActor)
        {
            Actor oldActor = GetById(id);
            oldActor.ProfilePictureURL = newActor.ProfilePictureURL;
            oldActor.FullName          = newActor.FullName;
            oldActor.Bio               = newActor.Bio;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Actor actor = GetById(id);
            Context.Actors.Remove(actor);
            Context.SaveChanges();
        }
    }
}
