using System.ComponentModel.DataAnnotations.Schema;

namespace projet_pop.Models
{
    public class Population
    {
        public int Id { get; set; }
        public int population { get; set; }



        public int year { get; set; }
        [ForeignKey("Pays")] public int PaysId { get; set; }
    }
}
