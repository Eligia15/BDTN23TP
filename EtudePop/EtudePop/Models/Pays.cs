namespace EtudePop.Models
{
    public class Pays
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Population> List_Populations { get; set; }
        public string Continent { get; set; }
    }
}
