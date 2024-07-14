using eTickets.Models;

namespace eTickets.Services
{
    public class ProducerRepository : IProducerRepository
    {
        AppDbContext Context; // = new AppDbContext();
        public ProducerRepository(AppDbContext Context)
        {
            this.Context = Context;
        }
        public List<Producer> GetAll()
        {
            List<Producer> producers = Context.Producers.ToList();
            return producers;
        }
        public Producer GetById(int id)
        {
            Producer producer = Context.Producers.FirstOrDefault(x => x.Id == id);
            return producer;
        }
        public void Insert(Producer newProducer)
        {
            Context.Producers.Add(newProducer);
            Context.SaveChanges();
        }
        public void Update(int id, Producer newProducer)
        {
            Producer oldProducer = GetById(id);
            oldProducer.ProfilePictureURL = newProducer.ProfilePictureURL;
            oldProducer.FullName          = newProducer.FullName;
            oldProducer.Bio               = newProducer.Bio;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Producer producer = GetById(id);
            Context.Producers.Remove(producer);
            Context.SaveChanges();
        }
    }
}
