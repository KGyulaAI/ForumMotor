namespace ForumMotor.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public int KategoriaId { get; set; }
        public virtual User User { get; set; }
        public virtual Kategoria Kategoria { get; set; }
        public virtual ICollection<Bejegyzes> Bejegyzesek { get; set; }
    }
}
