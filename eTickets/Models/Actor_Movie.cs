using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Actor_Movie
    {
        // Relationships
        public Movie? Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Actor? Actor { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
    }
}
