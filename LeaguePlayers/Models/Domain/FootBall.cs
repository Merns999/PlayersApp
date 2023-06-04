namespace LeaguePlayers.Models.Domain
{
    public class FootBall : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public long Phone { get; set; }
        public string Foot { get; set; }
        public int Rank { get; set; }
        public string Salary { get; set; }
        public int Goals { get; set; }
    }
}
