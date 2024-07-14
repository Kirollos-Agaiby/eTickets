using eTickets.Models;

namespace eTickets.Services
{
    public interface IProducerRepository
    {
        List<Producer> GetAll();
        Producer GetById(int id);
        void Insert(Producer newProducer);
        void Update(int id, Producer newProducer);
        void Delete(int id);
    }
}
