namespace PlayersApp.Models.Domain
{
    public class Player
    {
        public Guid     Id      { get; set; }
        public string   Name    { get; set; }
        public string   Email   { get; set; }
        public int      Rank    { get; set; }
        public string   Salary  { get; set; }
        public long     Phone   { get; set; }
        public string   Url     { get; set; }
    }
}
