using Microsoft.EntityFrameworkCore;

namespace BinokoolShop.Models.Repository.InterfaceRepository
{
    public interface IGuitarRepository
    {
        IQueryable<Guitar> GetGuitars();
        Guitar GetGuitar(Guid Id);
        void AddMoreGuitar();
    }
}
