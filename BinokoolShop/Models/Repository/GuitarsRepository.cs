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
        public Guitar GetGuitarById(Guid Id)
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
        public Guitar GetGuitarByName(string Name) 
        { 
            Guitar? guitar = context.guitars.FirstOrDefault(c => c.Name == Name);
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

        public void AddMoreGuitar()
        {
            context.guitars.Add(
                new Guitar
                {
                    Id = Guid.NewGuid(),
                    Price = 100.0M,
                    ShortText = "Гитара для начинающих",
                    LongText = "Посредственная гитара",
                    Name = "Cort",
                    IsAvaible = true,
                    Count = 10,
                    Img = "~/img/Cort.jpg"
                });
            context.guitars.Add(
                new Guitar
                {
                    Id = Guid.NewGuid(),
                    Price = 1800.0M,
                    ShortText = "Гитара из массива",
                    LongText = "Суперская гитара из массива кедра",
                    Name = "Crafter",
                    IsAvaible = true,
                    Count = 20,
                    Img = "~/img/Crafter.jpg"
                });
            context.guitars.Add(
                new Guitar
                {
                    Id = Guid.NewGuid(),
                    Price = 5100.0M,
                    ShortText = "Электрогитара от известной компании",
                    LongText = "Электроитара Gibson, котороя идеально подойдет для жёстких металюг",
                    Name = "Gibson",
                    IsAvaible = true,
                    Count = 5,
                    Img = "~/img/Gibson_Sg.jpg"
                });
            context.guitars.Add(
                new Guitar
                {
                    Id = Guid.NewGuid(),
                    Price = 99.9M,
                    ShortText = "Электрогитара от известной компании",
                    LongText = "Электроитара Gibson, котороя идеально подойдет для жёстких металюг",
                    Name = "Gibson",
                    IsAvaible = true,
                    Count = 10,
                    Img = "~/img/Gibson_BG.jpg"
                });
            context.SaveChanges();
        }
    }
}
