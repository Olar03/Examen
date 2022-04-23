namespace Examen.Data.Entities
{
    public class EntranceTicket
    {
        public int Id { get; set; }

        public Entrance Entrance { get; set; }

        public Ticket Ticket { get; set; }
    }
}
