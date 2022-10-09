using BinokoolShop.Models;

namespace BinokoolShop.ViewModel
{
    public class GuitarsViewModel
    {
        public IEnumerable<Guitar> guitars { get; set; }    
        public string Category { get; set; }
    }
}
