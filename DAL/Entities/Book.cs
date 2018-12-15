using BookService.DAL.Interfaces;

namespace BookService.DAL.Entities
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
