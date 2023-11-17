namespace FluentApiCompany.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Position> Positions { get; set; }
    }
}
