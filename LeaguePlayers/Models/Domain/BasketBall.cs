namespace LeaguePlayers.Models.Domain
{
    public class BasketBall : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public long Phone { get; set; }
        public string Hand { get; set; }
        public int Rank { get; set; }
        public string Salary { get; set; }
        public int Shots { get; set; }
    }
}
