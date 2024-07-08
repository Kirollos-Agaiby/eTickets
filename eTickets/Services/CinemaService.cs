using eTickets.Models;

namespace eTickets.Services
{
    public class CinemaService : ICinemaService
    {
        AppDbContext Context; // new AppDbContext();
        public CinemaService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public List<Cinema> GetAll()
        {
            List<Cinema> cinemas = Context.Cinemas.ToList();
            return cinemas;
        }
        public Cinema GetById(int id)
        {
            Cinema cinema = Context.Cinemas.FirstOrDefault(x => x.Id == id);
            return cinema;
        }
        public void Insert(Cinema newCinema)
        {
            Context.Cinemas.Add(newCinema);
            Context.SaveChanges();
        }
        public void Update(int id, Cinema newCinema)
        {
            Cinema odlCinema = GetById(id);
            odlCinema.Logo        = newCinema.Logo;
            odlCinema.Name        = newCinema.Name;
            odlCinema.Description = newCinema.Description;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Cinema cinema = GetById(id);
            Context.Cinemas.Remove(cinema);
            Context.SaveChanges();
        }
    }
}
