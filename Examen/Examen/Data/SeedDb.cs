using Examen.Data.Entities;

namespace Examen.Data
{
    public class SeedDb
    {
        private readonly ExamenContext _context;


        public SeedDb(ExamenContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEntrancesAsync();
            //await CheckTicketsAsync();
        }

        private async Task CheckEntrancesAsync()
        {
            if (!_context.Entrances.Any())
            {
                _context.Entrances.Add(new Entrance { Description = "Norte" });
                _context.Entrances.Add(new Entrance { Description = "Sur" });
                _context.Entrances.Add(new Entrance { Description = "Oriental" });
                _context.Entrances.Add(new Entrance { Description = "Occidental" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {

                for (int i = 1; i < 5000; i++)
                {
                    _context.Tickets.Add(new Ticket { Id = i, WasUsed = false });
                }
                await _context.SaveChangesAsync();
            }

        }

        
    }
}
