using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVC_частина_1.Models
{
    internal class Note
    {

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; private set; }
        public List<string> Tags { get; set; }

        public Note(string title, string text, List<string> tags)
        {
            Title = title;
            Text = text;
            Tags = tags;
            CreatedDate = DateTime.Now;
        }
    }
}
