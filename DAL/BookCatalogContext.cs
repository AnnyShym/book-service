using BookService.DAL.Entities;
using System.Data.Entity;

namespace BookService
{
    public class BookCatalogContext: DbContext
    {

        public BookCatalogContext(string connectionString) : base(connectionString) { }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance1 = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            var instance2 = System.Data.SQLite.EF6.SQLiteProviderFactory.Instance;
        }

        public DbSet<Book> Books { get; set; }

    }
}
