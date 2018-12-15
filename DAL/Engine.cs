using BookService.DAL.Entities;
using DependencyManager.Classes;
using DependencyManager.Types;
using System.Collections.Generic;
using System.Linq;

namespace BookService.DAL
{
    public class Engine
    {

        private static Container ioc;

        static Engine()
        {
            ioc = new Container();
            ioc.Register<BookCatalogContext>(new Configuration(LifeCycle.Singleton));         
        }

        public static List<Book> GetAll()
        {
            using (var db = ioc.Resolve<BookCatalogContext>(new ConfigurationResolver(typeof(BookCatalogContext),
                new Configuration(LifeCycle.Singleton)))) {
                return db.Books.ToList<Book>();
            }
        }

        public static Book GetById(int id)
        {
            using (var db = ioc.Resolve<BookCatalogContext>(new ConfigurationResolver(typeof(BookCatalogContext),
                new Configuration(LifeCycle.Singleton)))) {
                return db.Books.FirstOrDefault(o => o.Id == id);
            }
        }

        public static void Add(int index, Book book)
        {
            using (var db = ioc.Resolve<BookCatalogContext>(new ConfigurationResolver(typeof(BookCatalogContext),
                new Configuration(LifeCycle.Singleton)))) {

                book.Id = db.Books.Count();

                db.Books.Add(book);

                db.SaveChanges();

            }
        }

        public static void Delete(int id)
        {
            using (var db = ioc.Resolve<BookCatalogContext>(new ConfigurationResolver(typeof(BookCatalogContext),
                new Configuration(LifeCycle.Singleton)))) {
                db.Books.Remove(db.Books.FirstOrDefault(o => o.Id == id));
                db.SaveChanges();
            }
        }
    
        public static void Update(int id, Book newBook)
        {
            using (var db = ioc.Resolve<BookCatalogContext>(new ConfigurationResolver(typeof(BookCatalogContext),
                new Configuration(LifeCycle.Singleton)))) {

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
