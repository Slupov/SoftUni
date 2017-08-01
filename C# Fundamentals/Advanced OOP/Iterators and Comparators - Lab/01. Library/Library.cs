using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(new BookComparator());

        foreach (var book in books)
            this.books.Add(book);
    }

    private SortedSet<Book> books { get; set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private readonly IEnumerable<Book> books;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count();
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current => this.books.ToList()[this.currentIndex];

        object IEnumerator.Current => this.Current;
    }
}