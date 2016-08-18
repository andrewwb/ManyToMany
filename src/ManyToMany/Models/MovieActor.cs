using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManyToMany.Models
{
    public class MovieActor
    {
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
    }
}
