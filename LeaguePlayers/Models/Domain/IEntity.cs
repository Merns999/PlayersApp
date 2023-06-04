namespace LeaguePlayers.Models.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Url { get; set; }
        long Phone { get; set; }
    }
}
