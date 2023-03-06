namespace Etude_population.Models
{
    public class Population
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public Pays Pays_app { get; set; }
        public int Annee { get; set; }
    }
}
