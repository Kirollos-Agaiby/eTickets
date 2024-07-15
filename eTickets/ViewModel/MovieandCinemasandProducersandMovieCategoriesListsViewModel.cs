using eTickets.Data;
using eTickets.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.ViewModel
{
    public class MovieandCinemaProducerMovieCategoryListsViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }
        public List<Cinema>? cinemas { get; set; }
        public List<Producer>? producers { get; set; }
        public IEnumerable<MovieCategory>? movieCategorys { get; set; }
    }
}
