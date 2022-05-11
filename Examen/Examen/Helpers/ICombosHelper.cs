using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Helpers
{
    public interface ICombosHelper
    {

        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();

    }
}
