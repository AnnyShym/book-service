namespace BookService.DAL.Interfaces
{
    public interface IBook
    {
        int Id { get; }
        string Name { get; }
        string Author { get; }
        string Description { get; }
        int Price { get; }
    }
}
