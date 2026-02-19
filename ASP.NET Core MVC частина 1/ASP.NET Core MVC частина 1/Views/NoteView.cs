using ASP.NET_Core_MVC_частина_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Views
{
    internal class NoteView
    {
        public void DisplayNote(Note note)
        {
            Console.WriteLine("===== ЗАМІТКА =====");
            Console.WriteLine($"Назва: {note.Title}");
            Console.WriteLine($"Текст: {note.Text}");
            Console.WriteLine($"Дата створення: {note.CreatedDate}");
            Console.WriteLine("Теги: " + string.Join(", ", note.Tags));
            Console.WriteLine();
        }
    }
}
