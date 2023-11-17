namespace FluentApiCompany.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int CompanyId {  get; set; }
        public Company Company { get; set; }
    }
}
