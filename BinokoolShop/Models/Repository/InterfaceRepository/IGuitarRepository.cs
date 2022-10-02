using Microsoft.EntityFrameworkCore;

namespace BinokoolShop.Models.Repository.InterfaceRepository
{
    public interface IGuitarRepository
    {
        IQueryable<Guitar> GetGuitars();
        Guitar GetGuitarById(Guid Id);
        Guitar GetGuitarByName(string Name);
        void AddMoreGuitar();
    }
}
