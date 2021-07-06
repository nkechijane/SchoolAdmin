using SchoolAdmin.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.Facilities
{
   // public delegate void BookAddedEventHandler(object source, BookEventArgs args);
    class LibraryCatalog
    {
        public LibraryCatalog() 
        {
            bookList = new List<Book>();
        }
        //public event BookAddedEventHandler BookAdded;

        public EventHandler<BookEventArgs> BookAdded;

        private List<Book> bookList;

        protected virtual void OnBookAdded(object source, BookEventArgs args) 
        {
            // Check if subscribers exist for this event, then raise the event
            if (BookAdded != null)
            {
                Console.WriteLine($"BookAdded Event fired. Number of subscribers: {BookAdded.GetInvocationList().Length}");
                BookAdded(this, args);
            }
            else 
            {
                Console.WriteLine("BookAdded Event fired. No subscribers found.");
            }
        
        }

        public void AddBook(Book newBook)
        {
            bookList.Add(newBook);
            OnBookAdded(this, new BookEventArgs { 
                Title = newBook.Author, 
                Author = newBook.Author, 
                TimeAdded = DateTime.Now 
            });
        }
    }

    public class BookEventArgs : EventArgs
    {
        public string Title;

        public string Author;

        public DateTime TimeAdded;
    }
}
