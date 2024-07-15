using eTickets.Models;

namespace eTickets.Services
{
    public interface IProducerService
    {
        public List<Producer> GetAll();
        public Producer GetById(int id);
        public void Insert(Producer newProducer);
        public void Update(int id, Producer newProducer);
        public void Delete(int id);
    }
}
