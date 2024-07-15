using eTickets.Models;

namespace eTickets.Services
{
    public class ProducerService : IProducerService
    {
        IProducerRepository producerRepository;
        public ProducerService(IProducerRepository producerRepository) 
        {
            this.producerRepository = producerRepository;
        }

        public List<Producer> GetAll()
        {
            return producerRepository.GetAll();
        }
        public Producer GetById(int id)
        {
            return producerRepository.GetById(id);
        }
        public void Insert(Producer newProducer)
        {
            producerRepository.Insert(newProducer);
        }
        public void Update(int id, Producer newProducer)
        {
            producerRepository.Update(id, newProducer);
        }
        public void Delete(int id)
        {
            producerRepository.Delete(id);
        }
    }
}
