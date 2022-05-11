using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Data;

namespace Examen.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly ExamenContext _context;

        public CombosHelper(ExamenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync()
        {
            List<SelectListItem> list = await _context.Entrances.Select(e => new SelectListItem
            {
                Text = e.Description,
                Value = $"{e.Id}"
            })
                           .OrderBy(e => e.Text)
                           .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Entrada...]",
                Value = "0"
            });

            return list;
        }

       
    }
}
