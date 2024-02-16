namespace Models
{
    public class Worker
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public string StructureUnit { get; set; }
        public uint Salary { get; set; }
        public POST Post { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime JoinToTeam { get; set; }
    }

    public enum POST
    {
        Jun,
        Middle,
        Senior
    }
}
