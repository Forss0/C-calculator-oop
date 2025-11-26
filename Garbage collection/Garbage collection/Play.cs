

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Play : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    private bool disposed = false;

    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"П'єса: {Title}, Автор: {Author}, Жанр: {Genre}, Рік: {Year}");
    }

    // Метод Dispose (для завдання 3)
    public void Dispose()
    {
        if (!disposed)
        {
            Console.WriteLine("Play.Dispose() викликано.");
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    // Деструктор (для завдання 1)
    ~Play()
    {
        Console.WriteLine("Деструктор Play викликано.");
    }
}
