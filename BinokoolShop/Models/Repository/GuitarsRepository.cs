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
            Guitar? guitar = context.guitars.FirstOrDefault(c => c.Id == Id);
            if (guitar != null)
            {
                return guitar;
            }
            else
            {
                throw new ArgumentNullException("В базе данных нету такого товара или не правильно введенный id товара");
            }
        }

        public IQueryable<Guitar> GetGuitars()
        {
            return context.guitars;
        }
    }
}
