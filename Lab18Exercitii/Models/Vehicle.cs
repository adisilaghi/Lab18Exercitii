namespace Lab18Exercitii.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }  
        public Manufacturer Manufacturer { get; set; }
        public List<Key> Key { get; set; }
        public TechnicalBook TechnicalBook { get; set; }
    }
}
