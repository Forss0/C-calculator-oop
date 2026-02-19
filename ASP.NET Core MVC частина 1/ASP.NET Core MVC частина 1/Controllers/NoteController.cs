using ASP.NET_Core_MVC_частина_1.Models;
using ASP.NET_Core_MVC_частина_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Controllers
{
    internal class NoteController
    {
        private Note _note;
        private NoteView _view;

        public NoteController(Note note, NoteView view)
        {
            _note = note;
            _view = view;
        }

        public void UpdateTitle(string title)
        {
            _note.Title = title;
        }

        public void ShowNote()
        {
            _view.DisplayNote(_note);
        }
    }
}