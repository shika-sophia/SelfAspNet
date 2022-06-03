/*
 *@see SampleAspNetApi / SelfAspNetApi_Setting.txt
 *
 */

using SelfAspNetApi.Models;
using System.Net;
using System.Web.Http;

namespace SelfAspNetApi.Controllers
{
    public class BookController : ApiController
    {
        public Book GetBook(string id)
        {
            var db = new SelfAspNetApiDB();
            Book book = db.Book.Find(id);

            if(book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return book;
        }//GetBook()

    }//class
}
