using eTickets.Models;

namespace eTickets.Services
{
    public class CinemaService : ICinemaService
    {
        ICinemaRepository cinemaRepository;
        public CinemaService(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }


        public List<Cinema> GetAll()
        {
            List<Cinema> cinemas = cinemaRepository.GetAll();
            return cinemas;
        }
        public Cinema GetById(int id)
        {
            Cinema cinema = cinemaRepository.GetById(id);
            return cinema;
        }
        public void Insert(Cinema newCinema)
        {
            cinemaRepository.Insert(newCinema);
        }
        public void Update(int id, Cinema newCinema)
        {
            cinemaRepository.Update(id, newCinema);
        }
        public void Delete(int id)
        {
            cinemaRepository.Delete(id);
        }
    }
}
