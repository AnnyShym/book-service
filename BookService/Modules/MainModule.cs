using Nancy;
using Nancy.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using BookService.DAL.Entities;

namespace BookService.Modules
{
    public class MainModule : NancyModule
    {
        public MainModule() : base("/")
        {

            Get["api/v.1.0/"] = _ => "Simple Book Catalog";
            Get["api/v.1.0/books"] = _ => DAL.Engine.GetAll();
            Get["api/v.1.0/books/{id}"] = parameters => DAL.Engine.GetById(parameters.id);

            Post["api/v.1.0/books/{id}"] = parameters =>
            {

                Book book = this.Bind<Book>();
                HttpStatusCode statusCode = HttpStatusCode.NoContent;

                if (book.Id == 0 && book.Name == null && book.Author == null 
                    && book.Description == null && book.Price == 0) {
                    DAL.Engine.Delete(parameters.id);
                }
                else {
                    if (DAL.Engine.GetById(parameters.id) == null) {
                        DAL.Engine.Add(parameters.id, book);
                        statusCode = HttpStatusCode.Created;
                    }
                    else {
                        DAL.Engine.Update(parameters.id, book);
                    }
                }

                return statusCode;

            };

        }
    }
}