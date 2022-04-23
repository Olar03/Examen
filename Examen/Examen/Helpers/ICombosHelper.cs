using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shooping.Helpers
{
    public interface ICombosHelper
    {

        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();

    }
}
