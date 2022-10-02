using BinokoolShop.Models.AppDbContext;
using BinokoolShop.Models.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace BinokoolShop.Models.Repository
{
    public class GuitarsRepository : IGuitarRepository
    {
        private readonly ApplicationDbContext context;
        public GuitarsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Guitar GetGuitar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Guitar> GetGuitars()
        {
            return context.guitars;
        }
    }
}
