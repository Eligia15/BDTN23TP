namespace projet_pop.Models
{
    public class Continent
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pays> pays { get; set; }
    }
}

