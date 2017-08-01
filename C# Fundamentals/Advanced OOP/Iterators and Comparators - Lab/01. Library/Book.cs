using System;
using System.Collections.Generic;
using System.Linq;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors.ToList();
    }

    public string Title { get; set; }
    public int Year { get; set; }
    public List<string> Authors { get; set; }

    public int CompareTo(Book other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var yearComparison = this.Year.CompareTo(other.Year);
        if (yearComparison != 0) return yearComparison;
        return string.Compare(this.Title, other.Title, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}