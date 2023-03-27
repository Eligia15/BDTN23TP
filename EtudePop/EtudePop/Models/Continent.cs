namespace EtudePop.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pays> List_Pays { get; set; }
    }
}
