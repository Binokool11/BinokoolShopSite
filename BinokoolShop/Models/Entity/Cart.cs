namespace BinokoolShop.Models.Entity
{
    public class Cart
    {
        /// <summary>
        /// Список текущих гитар
        /// </summary>
        public List<CartLine> ListCurrentGuitar = new List<CartLine> ();
        public int Id { get; set; }
        /// <summary>
        /// Добавить в корзину элемент
        /// </summary>
        /// <param name="guitar">Гитара</param>
        /// <param name="quantity">Количество</param>
        public void AddItem(Guitar guitar, int quantity)
        {
            if (guitar == null) { throw new ArgumentNullException(); }
            
            CartLine? line = ListCurrentGuitar.Where(c => guitar.ItemId == c.Guitar?.ItemId).FirstOrDefault();

            if (line == null)
            {
                ListCurrentGuitar.Add(new CartLine { Guitar = guitar, Quantity = quantity });
            }
            else
            {
                line.Quantity++;
            }
        }


        /// <summary>
        /// Удалить все элементы в корзине
        /// </summary>
        public void Remove()
        {
            ListCurrentGuitar.Clear();
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return ListCurrentGuitar;
        }

  
    }


    /// <summary>
    /// Товар выбранный пользователем 
    /// </summary>
    public class CartLine
    {
        /// <summary>
        /// Выбранный товар
        /// </summary>
        public Guitar? Guitar { get; set; }  
        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }
        public override string ToString()
        {
            return Guitar.Name; 
        }
    }

    
}
