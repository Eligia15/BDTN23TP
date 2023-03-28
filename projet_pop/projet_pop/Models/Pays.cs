using System.ComponentModel.DataAnnotations.Schema;

namespace projet_pop.Models
{
    public class Pays
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public ICollection<Population> populations { get; set; }
        [ForeignKey("Continent")] public int ContinentId { get; set; }
    }
}
