using BookService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookService.DAL
{
    public static class Engine
    {

        static string connectionString = @"C:\Users\User\Documents\Visual Studio 2017\Projects\BookService\DAL\bin\Debug\bookcatalog.sqlite";

        public static List<Book> GetAll()
        {
            using (var db = new BookCatalogContext(connectionString)) {
                return db.Books.ToList<Book>();
            }
        }

        public static Book GetById(int id)
        {
            using (var db = new BookCatalogContext(connectionString)) {
                return db.Books.FirstOrDefault(o => o.Id == id);
            }
        }

        public static void Add(int index, Book book)
        {
            using (var db = new BookCatalogContext(connectionString)) {

                book.Id = db.Books.Count();

                db.Books.Add(book);

                db.SaveChanges();

            }
        }

        public static void Delete(int id)
        {
            using (var db = new BookCatalogContext(connectionString)) {
                db.Books.Remove(db.Books.FirstOrDefault(o => o.Id == id));
                db.SaveChanges();
            }
        }
    
        public static void Update(int id, Book newBook)
        {
            using (var db = new BookCatalogContext(connectionString)) {    
        
                Book book = db.Books.FirstOrDefault(o => o.Id == id);

                book.Name = newBook.Name;
                book.Author = newBook.Author;
                book.Description = newBook.Description;
                book.Price = newBook.Price;

                db.SaveChanges();

            }
        }

    }
}
