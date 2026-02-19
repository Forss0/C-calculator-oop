

using ASP.NET_Core_MVC_частина_1.Controllers;
using ASP.NET_Core_MVC_частина_1.Models;
using ASP.NET_Core_MVC_частина_1.Views;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Створення замітки
        var note = new Note(
            "Навчання C#",
            "Сьогодні вивчаю MVC-патерн",
            new List<string> { "C#", "MVC", "Навчання" }
        );

        var noteView = new NoteView();
        var noteController = new NoteController(note, noteView);

        noteController.ShowNote();

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;



        // Створення контакту
        var contact = new Contact(
            "Іван",
            "+380991234565",
            "+380681293457",
            "ivan@email.com",
            "Друг з університету"
        );

        var contactView = new ContactView();
        var contactController = new ContactController(contact, contactView);

        contactController.ShowContact();
    }
}